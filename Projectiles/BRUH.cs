using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			Texture2D texture = mod.GetTexture("Projectiles/BRUH_effect");
			Vector2 origin = new Vector2(texture.Width*0.5f, texture.Height*0.5f);
			spriteBatch.Draw(texture, projectile.Center-Main.screenPosition, null, color, projectile.rotation, origin, 1f, SpriteEffects.None, 0);
            return base.PreDraw(spriteBatch, lightColor);
			
        }
    }
}
		
			