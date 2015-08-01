using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class GearSlotInfo : PCItemInfo
    {
        public byte SlotID = 0;

        public bool ActiveSlot = false;

        public new void Write(Stream stream)
        {
            // write PCItemInfo
            base.Write(stream);

            // write SlotID
            stream.WriteByte(this.SlotID);

            // write ActiveSlot
            stream.WriteByte(BitConverter.GetBytes(this.ActiveSlot)[0]);
        }
    }
}
