using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace tree.Projectiles 
{    
    public class BRUH : ModProjectile 
    {	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BRUH");
		}
        public override void SetDefaults()
        {
			projectile.timeLeft = 4000;
			projectile.width = 48;
			projectile.height = 26;
			projectile.penetrate = 1;
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
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return base.TileCollideStyle(ref width, ref height, ref fallThrough);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			if (projectile.ai[0] == -1)
			{
				Player player = Main.player[projectile.owner];
				Main.spriteBatch.End();
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Main.GameViewMatrix.ZoomMatrix);
				int shader = GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye);
				GameShaders.Armor.GetSecondaryShader(shader, player).Apply(null);
			}
			Texture2D texture = mod.GetTexture("Projectiles/BRUH_effect");
			Vector2 origin = new Vector2(texture.Width*0.5f, texture.Height*0.5f);
			spriteBatch.Draw(texture, projectile.Center-Main.screenPosition, null, color, projectile.rotation, origin, 1f, SpriteEffects.None, 0);
            return base.PreDraw(spriteBatch, lightColor);
			
        }
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (projectile.ai[0] == -1)
			{
				Main.spriteBatch.End();
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
			}
		}
	}
}
		
			