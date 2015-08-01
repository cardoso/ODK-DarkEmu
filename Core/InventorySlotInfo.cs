using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class InventorySlotInfo : PCItemInfo
    {
        byte InventoryX, InventoryY;

        public new void Write(Stream stream)
        {
            // write PCItemInfo
            base.Write(stream);

            // write InventoryX & InventoryY
            stream.WriteByte(InventoryX);
            stream.WriteByte(InventoryY);
        }
    }
}
