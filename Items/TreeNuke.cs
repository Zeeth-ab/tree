using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using tree.Projectiles;

namespace tree.Items
{
	public class TreeNuke : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Nukey Wukey"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("boom boom b1tch");
		}

		public override void SetDefaults() 
		{
			item.damage = 10000;
			item.ranged = true;
			item.width = 132;
			item.height = 204;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 100;
			item.value = Item.sellPrice(1, 1, 0, 0);
			item.rare = ItemRarityID.LightPurple;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.noMelee = true;
			item.shoot = ModContent.ProjectileType<TreeNukeProj>();
			item.shootSpeed = 20;
			item.consumable = true;
			item.maxStack = 999;
			item.noUseGraphic = true;
		}

		

        public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.Next(10) < 5) return false;
			return true;
        }
    }
}