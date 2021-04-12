using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace tree.Projectiles 
{    
    public class BabyBearHead : ModProjectile 
    {	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("A sad little baby bear's head");
		}
        public override void SetDefaults()
        {
			projectile.aiStyle = 1;
			projectile.timeLeft = 4000;
			projectile.width = 55;
			projectile.height = 51;
			projectile.penetrate = -1;
			projectile.friendly = false;
			projectile.hostile = true;
		}
		
		public override void AI()
		{
			
		}
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 30;
			height = 30;
			return base.TileCollideStyle(ref width, ref height, ref fallThrough);
		}
		
	}
}
		
			