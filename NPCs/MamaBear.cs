using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace tree.NPCs
{
	public class MamaBear : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mama Bear");
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.GoblinPeon);
			aiType = NPCID.GoblinScout; //better than doing zombies due to night time - day time ai
			npc.lifeMax = 10000;
			npc.damage = 150;
			npc.width = 230;
			npc.height = 438;
			npc.defense = 0;
			npc.value = 100000;
			animationType = 0;
			Main.npcFrameCount[npc.type] = 6;
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
				if (npc.frame.Y >= 6 * frame)
				{
					npc.frame.Y = 0;
				}
			}
		}
		float ai2 = 0;
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
			ai2++;
			if(ai2 >= 540)
            {
				Vector2 distance = npc.Center - player.Center;
				distance = distance.SafeNormalize(Vector2.Zero);
				distance *= -8f;
				int damage2 = npc.damage / 2;
				if (Main.expertMode)
				{
					damage2 = (int)(damage2 / Main.expertDamage);
				}
				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					for(int i = 0; i < 7; i++)
                    {
						Vector2 velo = distance;
						Vector2 ShootSpeed = new Vector2(velo.X + Main.rand.Next(-3, 4), velo.Y + Main.rand.Next(-3, 4)).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-8, 9)));
						Projectile.NewProjectile(npc.Center.X, npc.position.Y + 50, ShootSpeed.X, ShootSpeed.Y, mod.ProjectileType("BabyBearHead"), damage2, 2f, Main.myPlayer);
					}
				}
				Main.PlaySound(15, (int)(npc.Center.X), (int)(npc.Center.Y), 0, 1.25f);
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MamaGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MamaGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MamaGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MamaGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MamaGore5"), 1f);
			}
			else
			{
				for (int i = 0; i < damage / (float)npc.lifeMax * 50.0; i++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 53, (float)hitDirection, -1f, 0, new Color(), 0.8f);
				}
			}
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