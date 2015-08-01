using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    public class NicknameInfo
    {
        public ushort ID;

        public NicknameType Type;

        public string Text;

        public ushort Index;

        public NicknameInfo()
        {
            this.ID = 0;
            this.Type = NicknameType.NICK_NONE;
            this.Text = "";
            this.Index = 0;
        }

        public void Write(ref NetworkStream stream)
        {
            // write id & type
            stream.Write(BitConverter.GetBytes(this.ID), 0, 2);
            stream.WriteByte((byte)this.Type);

            // handle type & write necessary data
            switch(this.Type)
            {
                case NicknameType.NICK_NONE:
                    break;
                case NicknameType.NICK_BUILT_IN:
                case NicknameType.NICK_QUEST:
                case NicknameType.NICK_FORCED:
                case NicknameType.NICK_QUEST_2:
                {
                    stream.Write(BitConverter.GetBytes(this.Index), 0, 2);
                    break;
                }
                case NicknameType.NICK_CUSTOM_FORCED:
                case NicknameType.NICK_CUSTOM:
                {
                    stream.WriteByte((byte)this.Text.Length);

                    byte[] txt = Encoding.ASCII.GetBytes(this.Text);

                    stream.Write(txt, 0, txt.Length);

                    break;
                }
            }
        }
    }
}
