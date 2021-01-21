using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace tree.NPCs
{
	public class BabyBear : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baby Bear");
		}
		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.GoblinPeon);
			aiType = NPCID.GoblinScout; //better than doing zombies due to night time - day time ai
			npc.lifeMax = 200;
			npc.damage = 50;
			npc.width = 60;
			npc.height = 92;
			npc.defense = 0;
			animationType = 0;
			npc.value = 1000;
			Main.npcFrameCount[npc.type] = 4;
			//banner = npc.type;
			//bannerItem = ItemType<ExampleItemBanner>();
		}
		float ai1 = 0;
		public override void FindFrame(int frameHeight)
        {
			int frame = frameHeight;
			ai1 += 1f * (0.5f + 0.5f * Math.Abs(npc.velocity.X));
			if (ai1 >= 5f)
			{
				ai1 -= 5f;
				npc.frame.Y += frame;
				if (npc.frame.Y >= 4 * frame)
				{
					npc.frame.Y = 0;
				}
			}
		}
		public override void AI()
		{
			npc.spriteDirection = - npc.direction;
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BearGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BearGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BearGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BearGore4"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BearGore5"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BearGore6"), 1f);
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
			return ZoneForest ? 2f : 0; //0.1f spawn chance while in the snow biome, 0 spawn chance while not
		}
		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Acorn, Main.rand.Next(2) + 1);
			if(Main.rand.Next(100) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreeLaser"), 1);
		}
	}
}