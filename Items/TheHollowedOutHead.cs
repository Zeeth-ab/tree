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
			item.defense = 11;
		}
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hollowed Out Head of the Lorax");
			Tooltip.SetDefault("This smells\nIncreases damage by 15%, decreases mana cost by 15%, increases maximum mana by 100\nthis is definitely balanced");
		}
		public override void UpdateEquip(Player player)
		{
			player.allDamage += .15f;
			player.manaCost -= .15f;
			player.statManaMax2 += 100;
		}
		
	}
}