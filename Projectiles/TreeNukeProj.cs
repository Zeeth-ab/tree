using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace tree.Projectiles 
{    
    public class TreeNukeProj : ModProjectile 
    {	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nukey Wukey");
		}
        public override void SetDefaults()
        {
			projectile.aiStyle = 1;
			projectile.timeLeft = 4000;
			projectile.width = 132;
			projectile.height = 204;
			projectile.penetrate = -1;
			projectile.friendly = false;
		}
        public override bool? CanHitNPC(NPC target)
        {
			float Distance = Vector2.Distance(projectile.Center, target.Center);
			return Distance < 320 && projectile.timeLeft < 3;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			if (projectile.timeLeft > 3) projectile.timeLeft = 3;
            return false;
        }
        public override void AI()
		{
			
		}
        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 1000; i++)
			{
				Vector2 circular = new Vector2(Main.rand.Next(1, 30), 0).RotatedBy(Main.rand.NextFloat(6.28f));
				Dust dust = Dust.NewDustDirect(projectile.Center, 0, 0, 6);
				dust.scale += 3;
				dust.velocity *= 3;
				dust.velocity += circular;
				dust.noGravity = true;
			}
			int explosionRadius = 20;
			int minTileX = (int)(projectile.Center.X / 16f - (float)explosionRadius);
			int maxTileX = (int)(projectile.Center.X / 16f + (float)explosionRadius);
			int minTileY = (int)(projectile.Center.Y / 16f - (float)explosionRadius);
			int maxTileY = (int)(projectile.Center.Y / 16f + (float)explosionRadius);
			if (minTileX < 0)
			{
				minTileX = 0;
			}
			if (maxTileX > Main.maxTilesX)
			{
				maxTileX = Main.maxTilesX;
			}
			if (minTileY < 0)
			{
				minTileY = 0;
			}
			if (maxTileY > Main.maxTilesY)
			{
				maxTileY = Main.maxTilesY;
			}
			bool canKillWalls = false;
			for (int x = minTileX; x <= maxTileX; x++)
			{
				for (int y = minTileY; y <= maxTileY; y++)
				{
					float diffX = Math.Abs((float)x - projectile.Center.X / 16f);
					float diffY = Math.Abs((float)y - projectile.Center.Y / 16f);
					double distance = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
					if (distance < (double)explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].wall == 0)
					{
						canKillWalls = true;
						break;
					}
				}
			}
			for (int i = minTileX; i <= maxTileX; i++)
			{
				for (int j = minTileY; j <= maxTileY; j++)
				{
					float diffX = Math.Abs((float)i - projectile.Center.X / 16f);
					float diffY = Math.Abs((float)j - projectile.Center.Y / 16f);
					double distanceToTile = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
					if (distanceToTile < (double)explosionRadius)
					{
						bool canKillTile = true;
						if (Main.tile[i, j] != null && Main.tile[i, j].active())
						{
							canKillTile = true;
							if (Main.tileDungeon[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 88 || Main.tile[i, j].type == 21 || Main.tile[i, j].type == 26 || Main.tile[i, j].type == 107 || Main.tile[i, j].type == 108 || Main.tile[i, j].type == 111 || Main.tile[i, j].type == 226 || Main.tile[i, j].type == 237 || Main.tile[i, j].type == 221 || Main.tile[i, j].type == 222 || Main.tile[i, j].type == 223 || Main.tile[i, j].type == 211 || Main.tile[i, j].type == 404)
							{
								canKillTile = false;
							}
							if (!Main.hardMode && Main.tile[i, j].type == 58)
							{
								canKillTile = false;
							}
							if (!TileLoader.CanExplode(i, j))
							{
								canKillTile = false;
							}
							if (canKillTile)
							{
								
								WorldGen.KillTile(i, j, false, false, false);
								if (!Main.tile[i, j].active() && Main.netMode != 0)
								{
									NetMessage.SendData(17, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
								}
							}
						}
						if (canKillTile)
						{
							for (int x = i - 1; x <= i + 1; x++)
							{
								for (int y = j - 1; y <= j + 1; y++)
								{
									if (Main.tile[x, y] != null && Main.tile[x, y].wall > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].wall))
									{
										WorldGen.KillWall(x, y, false);
										if (Main.tile[x, y].wall == 0 && Main.netMode != NetmodeID.SinglePlayer)
										{
											NetMessage.SendData(MessageID.TileChange, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
										}
									}
								}
							}
						}
					}
				}
			}

		}
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 30;
			height = 30;
			return base.TileCollideStyle(ref width, ref height, ref fallThrough);
		}
		
	}
}
		
			