using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class TreeSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("TreeSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("tree sword go swoosh");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.melee = true;
			item.width = 128;
			item.height = 128;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 50;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("IansMom");
			item.shootSpeed = 8;
		}

		
	}
}