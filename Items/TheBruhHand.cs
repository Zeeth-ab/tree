using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class TheBruhHand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Bruh Hand"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is illegal");
		}

		public override void SetDefaults() 
		{
			item.damage = 69;
			item.magic = true;
			item.width = 45;
			item.height = 120;
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
			item.mana = 20;
			item.shootSpeed = 9;
			Item.staff[item.type] = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TreeLaser", 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float Yoffset = -40;
			if(speedX < 0)
            {
				Yoffset *= -1;
            }
			Vector2 offset = new Vector2(100, Yoffset).RotatedBy(new Vector2(speedX, speedY).ToRotation());
			position += offset;
			for (int i = 0; i < 10; i++)
            {

				Vector2 ShootSpeed = new Vector2(speedX + Main.rand.Next(-5, 6), speedY + Main.rand.Next(-5, 6)).RotatedBy(MathHelper.ToRadians(Main.rand.Next(-20, 21)));
				Projectile.NewProjectile(position.X, position.Y, ShootSpeed.X, ShootSpeed.Y, mod.ProjectileType("BRUH"), damage, knockBack, player.whoAmI);
			}

			return false;

        }
	}
}