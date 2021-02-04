using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	[AutoloadEquip(EquipType.Head)]
	
	public class TheHollowedOutHead : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 24;
            item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Green;
			item.defense = 3;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hollowed Out Head of the Lorax");
			Tooltip.SetDefault("This smells");
		}
		public override void UpdateEquip(Player player)
		{
			
		}
		
	}
}