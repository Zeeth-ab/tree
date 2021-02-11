using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class Thneed_p2 : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 80;
			item.height = 62;
            item.value = Item.sellPrice(5, 0, 40, 1);
			item.rare = 1;
			item.defense = 2;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thneed Part 2");
			Tooltip.SetDefault("");
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("Thneed") && head.type == mod.ItemType("TheHollowedOutHead");
        }
		public override void UpdateEquip(Player player)
		{

		}
		public override void AddRecipes()
		{
			
		}

	}
}