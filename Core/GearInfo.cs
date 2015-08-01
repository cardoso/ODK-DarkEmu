using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class GearInfo
    {
        //byte ListNum;
        public List<GearSlotInfo> GearSlotInfoList;

        public GearInfo()
        {
            this.GearSlotInfoList = new List<GearSlotInfo>();
        }

        public void Write(Stream stream)
        {
            // write GearSlotInfoList
            stream.WriteByte((byte)this.GearSlotInfoList.Count);

            foreach (GearSlotInfo gsi in GearSlotInfoList)
            {
                gsi.Write(stream);
            }
        }
    }
}
