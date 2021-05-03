using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class Beagle : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Beagle"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("this isnt animal abuse");
		}

		public override void SetDefaults() 
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 332;
			item.height = 196;
			item.useTime = 5;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.value = Item.sellPrice(1, 1, 1, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("BabyLaser");
			item.shootSpeed = 20;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-16, 47);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float Yoffset = 0;
			if (speedX < 0)
			{
				Yoffset *= -1;
			}
			Vector2 offset = new Vector2(284, Yoffset).RotatedBy(new Vector2(speedX, speedY).ToRotation());
			position += offset;
			
			return true;
		}
	}
}