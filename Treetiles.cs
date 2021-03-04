using Terraria;
using Terraria.ModLoader;
using tree.Items;

namespace tree
{
    public class Treetiles : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
            if (!fail)
            {
                Player player = Main.LocalPlayer;
                if (player.HeldItem.type == ModContent.ItemType<TheLorAxe>())
                {
                    i *= 16;
                    j *= 16;
                    NPC.NewNPC(i, j, mod.NPCType("TheLorax"));
                }
            }
        }
    }


}