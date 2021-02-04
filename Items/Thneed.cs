using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	[AutoloadEquip(EquipType.Body)]
	public class Thneed : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 40;
			item.height = 62;
            item.value = Item.sellPrice(0, 1, 20, 0);
			item.rare = 2;
			item.defense = 4;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thneed");
			Tooltip.SetDefault("I feel like I have seen this somewhere... It gives me chills");
		}
		public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == mod.ItemType("TheHollowedOutHead");
		}
		public override void UpdateArmorSet(Player player)
		{
			
			player.setBonus = "";
			
		}
		
		public override void UpdateEquip(Player player)
		{
			
		}

	}
}