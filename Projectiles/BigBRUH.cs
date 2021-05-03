using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace tree.Projectiles 
{    
    public class BigBRUH : ModProjectile 
    {	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BRUH Moment");
		}
        public override void SetDefaults()
        {
			projectile.timeLeft = 4000;
			projectile.width = 194;
			projectile.height = 108;
			projectile.penetrate = 10;
			projectile.friendly = true;
		}
		Color color = Color.White;
		bool runOnce = false;
		public override void AI()
		{
			if(!runOnce)
            {
				runOnce = true;
				color = new Color(Main.rand.Next(256), Main.rand.Next(256), Main.rand.Next(256));
            }
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[projectile.owner] = 0;
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			Player player = Main.player[projectile.owner];
			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);
			int shader = GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye);
			GameShaders.Armor.GetSecondaryShader(shader, player).Apply(null);
			Texture2D texture = mod.GetTexture("Projectiles/BigBRUH_Effect");
			Vector2 origin = new Vector2(texture.Width*0.5f, texture.Height*0.5f);
			spriteBatch.Draw(texture, projectile.Center-Main.screenPosition, null, color, projectile.rotation, origin, 1f, SpriteEffects.None, 0);
            return base.PreDraw(spriteBatch, lightColor);
			
        }
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Main.spriteBatch.End();
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
		}
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
			width = 40;
			height = 40;
            return base.TileCollideStyle(ref width, ref height, ref fallThrough);
        }
        public override void Kill(int timeLeft)
        {
			if (projectile.owner == Main.myPlayer)
			{
				int max = 120;
				for (int i = 0; i < max; i++)
				{
					float rand = Main.rand.NextFloat(0.25f, 1.5f);
					Vector2 direction = new Vector2(1, 0).RotatedBy(MathHelper.ToRadians(360f / max * i));
					Projectile.NewProjectile(projectile.Center, direction * rand * 8f, mod.ProjectileType("BRUH"), (int)(projectile.damage * 0.33f), projectile.knockBack, projectile.owner, -1);
				}
			}
			Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 14, 0.6f);
			for (int i = 0; i < 40; i++)
			{
				Vector2 circularLocation = new Vector2(10, 0);
				resetVector2(ref circularLocation, i);
				int dust = Dust.NewDust(new Vector2(projectile.Center.X - 4, projectile.Center.Y - 3), 0, 0, 242);
				Main.dust[dust].velocity = circularLocation;
				Main.dust[dust].velocity *= 2f*2;
				Main.dust[dust].scale *= 7f*1.5f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye), Main.player[projectile.owner]);

				resetVector2(ref circularLocation, i);
				dust = Dust.NewDust(new Vector2(projectile.Center.X - 4, projectile.Center.Y - 3), 0, 0, 242);
				Main.dust[dust].velocity = circularLocation;
				Main.dust[dust].velocity *= 4f*2;
				Main.dust[dust].scale *= 6f*1.5f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye), Main.player[projectile.owner]);

				resetVector2(ref circularLocation, i);
				dust = Dust.NewDust(new Vector2(projectile.Center.X - 4, projectile.Center.Y - 3), 0, 0, 242);
				Main.dust[dust].velocity = circularLocation;
				Main.dust[dust].velocity *= 6.5f*2;
				Main.dust[dust].scale *= 5f*1.5f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye), Main.player[projectile.owner]);

				resetVector2(ref circularLocation, i);
				dust = Dust.NewDust(new Vector2(projectile.Center.X - 4, projectile.Center.Y - 3), 0, 0, 242);
				Main.dust[dust].velocity = circularLocation;
				Main.dust[dust].velocity *= 10f*2;
				Main.dust[dust].scale *= 4f*1.5f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].shader = GameShaders.Armor.GetSecondaryShader(GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye), Main.player[projectile.owner]);
			}
		}
		public void resetVector2(ref Vector2 loc, int i)
		{
			loc = new Vector2(10, 0).RotatedBy(MathHelper.ToRadians(i * 9));
			loc.X += Main.rand.Next(-5, 6);
			loc.Y += Main.rand.Next(-5, 6);
			loc *= 0.1f;
		}
	}
}
		
			