using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class InventoryInfo
    {
        public byte Width = 0xc8;
        public byte Height = 0xcd;

        public List<InventorySlotInfo> InventorySlotInfoList;

        public InventoryInfo()
        {
            InventorySlotInfoList = new List<InventorySlotInfo>();
        }

        public void Write(Stream stream)
        {
            // write width & height
            stream.WriteByte(this.Width);
            stream.WriteByte(this.Height);

            // write InventorySlotInfoList
            stream.WriteByte((byte)this.InventorySlotInfoList.Count);

            foreach(InventorySlotInfo isi in this.InventorySlotInfoList)
            {
                isi.Write(stream);
            }
        }
    }
}
