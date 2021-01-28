using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tree.Items
{
	public class LoraxTreasureBag : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Treasure Bag"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Right click to open");
		}

		public override void SetDefaults() 
		{
			
			item.width = 32;
			item.height = 32;
            item.maxStack = 30;
			item.value = Item.sellPrice(0, 0, 0, 1);
			item.rare = ItemRarityID.Purple;
            item.expert = true;
			
		}
        public override int BossBagNPC => mod.NPCType("TheLorax");
        public override bool CanRightClick()
        {
            return true;
        }
        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("BruhHand"));
            player.QuickSpawnItem(ItemID.Wood, Main.rand.Next(500, 1000));
            int rand = Main.rand.Next(3);
            if (rand == 0 || Main.rand.Next(10) == 0)
                player.QuickSpawnItem(mod.ItemType("TreeSword"));

            if (rand == 1 || Main.rand.Next(10) == 0)
                player.QuickSpawnItem(mod.ItemType("TreeBow"));

            if (rand == 2 || Main.rand.Next(10) == 0)
                player.QuickSpawnItem(mod.ItemType("TreeGun"));
        }
    }
}