using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tree.Projectiles 
{    
    public class IansMom : ModProjectile 
    {	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ian's mom");
		}
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.VortexBeaterRocket);
            aiType = ProjectileID.VortexBeaterRocket; 
			projectile.alpha = 255;
			projectile.timeLeft = 4000;
			projectile.extraUpdates = 3;
			projectile.width = 4;
			projectile.height = 4;
			projectile.penetrate = 1;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.player[projectile.owner].statLife += 2;
			Main.player[projectile.owner].HealEffect(2);
			projectile.Kill();
		}
		int counter = 0;
		public override void AI()
		{
			projectile.alpha = 255;
			counter++;
			if(counter >= 10)
			{
				int num1 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 2, 2, 3);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].velocity *= 0.1f;	
			}
		}
	}
}
		
			