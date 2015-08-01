using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class ExtraInfo
    {
        public List<ExtraSlotInfo> ExtraSlotInfoList;

        public ExtraInfo()
        {
            ExtraSlotInfoList = new List<ExtraSlotInfo>();
        }

        public void Write(Stream stream)
        {
            // write ExtraSlotInfoList
            stream.WriteByte((byte)this.ExtraSlotInfoList.Count);

            foreach (ExtraSlotInfo esi in this.ExtraSlotInfoList)
            {
                esi.Write(stream);
            }
        }
    }
}
