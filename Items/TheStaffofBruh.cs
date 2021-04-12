using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class TheStaffofBruh : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Staff of Bruh"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("a firm handshake for a firm weapon");
		}

		public override void SetDefaults() 
		{
			item.damage = 150;
			item.magic = true;
			item.width = 159;
			item.height = 158;
			item.useTime = 90;
			item.useAnimation = 90;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1;
			item.value = Item.sellPrice(5, 0, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("BigBRUH");
			item.mana = 100;
			item.shootSpeed = 12;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TheBruhHand", 1);
			recipe.AddIngredient(null, "TheHollowedOutHead", 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 offset = new Vector2(100, 0).RotatedBy(new Vector2(speedX, speedY).ToRotation());
			position += offset;
			return true;
        }
	}
}