using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace tree.NPCs
{
	public class TheLorax : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Daddy Lorax");
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.GoblinPeon);
			aiType = NPCID.GoblinScout; //better than doing zombies due to night time - day time ai
			npc.lifeMax = 5000;
			npc.damage = 100;
			npc.width = 196;
			npc.height = 228;
			npc.defense = 0;
			npc.value = 100000;
			animationType = 0;
			Main.npcFrameCount[npc.type] = 10;
			npc.boss = true;
			bossBag = mod.ItemType("LoraxTreasureBag");
			//banner = npc.type;
			//bannerItem = ItemType<ExampleItemBanner>();
		}
		float ai1 = 0;
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * bossLifeScale * 0.7f) + 1;
			npc.damage = (int)(npc.damage * 0.8f);
		}
		public override void FindFrame(int frameHeight)
		{
			int frame = frameHeight;
			Player player = Main.player[npc.target];
			ai1 += 1f * (0.5f + 0.5f * Math.Abs(npc.velocity.X));
			if (ai1 >= 5f)
			{
				ai1 -= 5f;
				npc.frame.Y += frame;
				if (npc.frame.Y >= 10 * frame)
				{
					npc.frame.Y = 0;
				}
				if(npc.frame.Y == 8*frame)
                {
					Vector2 Center = npc.Center + new Vector2(-22 * npc.spriteDirection, -78);
					for (int i = 0; i < 2; i++)
                    {
						if (i == 1) Center = npc.Center + new Vector2(-48 * npc.spriteDirection, -70);
						Vector2 direction = Center - player.Center;
						direction = direction.SafeNormalize(new Vector2(1, 0)) * -6;
						int damage = npc.damage / 4;
						if (Main.expertMode)
						{
							damage = (int)(damage / Main.expertDamage);
						}
						if (Main.netMode != NetmodeID.MultiplayerClient)
							Projectile.NewProjectile(Center.X, Center.Y, direction.X, direction.Y, ProjectileID.DeathLaser, damage, 69, Main.myPlayer);
					}
				}
			}
			if (npc.frame.Y >= 7 * frame && npc.frame.Y <= 9 * frame) npc.velocity *= 0.1f;
		}
		float ai2 = 0;
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			ai2++;
			if(ai2 >= 900)
            {
				NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("BabyBear"));
				ai2 -= 180;
            }
			npc.TargetClosest(true); //helps override running away during day time
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (var i = 0; i < 30; ++i)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 53, 2.5f * (float)hitDirection, -2.5f, 0, new Color(), 1f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheLoraxGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheLoraxGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheLoraxGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheLoraxGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheLoraxGore5"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TheLoraxGore6"), 1f);
			}
			else
			{
				for (int i = 0; i < damage / (float)npc.lifeMax * 50.0; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 53, (float)hitDirection, -1f, 0, new Color(), 0.8f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			Player player = spawnInfo.player;
			bool ZoneForest = !player.ZoneDesert && !player.ZoneCorrupt && !player.ZoneDungeon && !player.ZoneDungeon && !player.ZoneHoly && !player.ZoneMeteor && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneCrimson && !player.ZoneGlowshroom && !player.ZoneUndergroundDesert && (player.ZoneDirtLayerHeight || player.ZoneOverworldHeight) && !player.ZoneBeach;
			return ZoneForest ? 0f : 0; //0.1f spawn chance while in the snow biome, 0 spawn chance while not
		}
		
        public override void BossLoot(ref string name, ref int potionType)
        {
			potionType = ItemID.HealingPotion;
			if (Main.expertMode) npc.DropBossBags();
			else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Wood, Main.rand.Next(250) + 250);
				int rand = Main.rand.Next(3);
				if (rand == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreeSword"), 1);
				if (rand == 1)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreeBow"), 1);
				if (rand == 2)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreeGun"), 1);
			}
        }
	}
}