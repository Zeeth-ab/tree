using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class BruhHand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lorax Hand"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("whoa why do you have the lorax's hand bruh");
		}

		public override void SetDefaults() 
		{
			
			item.width = 62;
			item.height = 26;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 69, 0, 0);
			item.rare = ItemRarityID.Purple;
            item.expert = true;
			
		}

	}
}