using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using tree.Items;

namespace tree
{
    public class Treetiles : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Tile tile = Main.tile[i, j];
            base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
            if (!fail)
            {
                Player player = Main.LocalPlayer;
                if (player.HeldItem.type == ModContent.ItemType<TheLorAxe>() && tile.type == TileID.Trees && !NPC.AnyNPCs(mod.NPCType("TheLorax")))
                {
                    i *= 16;
                    j *= 16;
                    NPC.NewNPC(i, j, mod.NPCType("TheLorax"));
                }
            }
        }
    }


}