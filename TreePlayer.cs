using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using tree.Projectiles;

namespace tree
{
	public class TreePlayer : ModPlayer
	{
		public int treesOnHit = 0;
        public override void ResetEffects()
        {
            treesOnHit = 0;
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            base.OnHitByProjectile(proj, damage, crit);
            releaseTrees();
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            base.OnHitByNPC(npc, damage, crit);
            releaseTrees();
        }
        public void releaseTrees()
        {
            for(int i=0; i<treesOnHit; i++)
            {
                Vector2 Center = player.Center + new Vector2(0, -900);
                Vector2 Circle = new Vector2(Main.rand.NextFloat(2, 8), 0).RotatedBy(MathHelper.ToRadians(Main.rand.Next(360)));
                Circle.Y += 4;
                Projectile.NewProjectile(Center, Circle, ModContent.ProjectileType<treeProjectile>(), 50, 10, player.whoAmI);
            }
        }
    }
}