using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class TreeBow : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("TreeSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Tree Bow go Woosh");
		}

		public override void SetDefaults() 
		{
			item.damage = 420420;
			item.ranged = true;
			item.width = 24;
			item.height = 60;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 420;
			item.value = Item.sellPrice(1, 1, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = 10;
			item.shootSpeed = 5;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.Next(10) < 5) return false;
			return true;
        }
    }
}