using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace tree.Projectiles 
{    
    public class treeProjectile : ModProjectile 
    {	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fatty Tree");
		}
        public override Color? GetAlpha(Color lightColor)
        {
			return Color.White;
        }
        public override void SetDefaults()
        {
			projectile.CloneDefaults(1);
			projectile.timeLeft = 255;
			projectile.width = 76;
			projectile.height = 142;
			projectile.penetrate = 3;
			projectile.friendly = true;
			aiType = 1;
			projectile.tileCollide = false;
			projectile.alpha = 0;
			
		}
		
		public override void AI()
		{
			projectile.alpha++;
		}
       
    }
}
		
			