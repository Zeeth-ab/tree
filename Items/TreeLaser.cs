using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class TreeLaser : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Magic Acorn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Acorn go bzzzzzzzzzzzzz");
		}

		public override void SetDefaults() 
		{
			item.damage = 25;
			item.magic = true;
			item.width = 64;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.value = Item.sellPrice(1, 4, 2, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("IansDad");
			item.mana = 9;
			item.shootSpeed = 6;
			Item.staff[item.type] = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Acorn, 99);
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