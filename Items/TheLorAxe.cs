using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class TheLorAxe : ModItem
	{	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Lor-Axe");
			Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            item.damage = 5;
            item.melee = true;  
            item.width = 44;   
            item.height = 30;   
            item.useStyle = 1;
			item.useTurn = true;
            item.useTime = 18;
            item.useAnimation = 18;
			item.axe = 35;
			item.knockBack = 2.5f;
			item.value = Item.sellPrice(0, 3, 1, 0);
            item.rare = ItemRarityID.LightRed;
			item.UseSound = SoundID.Item1;
			item.tileBoost = 3;
			item.autoReuse = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				int num = Main.rand.Next(3);
				int type;
				if (num == 0)
				{
					type = 263;
				}
				else
				{
					if (num == 1)
					{
						type = 235;
					}
					else
					{
						type = 130;
					}
				}
				int num1 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, type, player.direction * 2, 0f, 150, default(Color), 1.3f);
				Main.dust[num1].velocity *= 0.2f;
				Main.dust[num1].noGravity = true;
			}
			base.MeleeEffects(player, hitbox);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 100);
			recipe.AddIngredient(ItemID.TissueSample, 10);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 100);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
