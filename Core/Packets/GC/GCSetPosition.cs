﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Core
{
    /*enum Directions 
{ 
	LEFT ,
	LEFTDOWN ,
	DOWN ,
	RIGHTDOWN ,
	RIGHT ,
	RIGHTUP ,
	UP ,
	LEFTUP ,
	DIR_MAX ,
	DIR_NONE = DIR_MAX
};*/
    public class GCSetPosition : Packet
    {
        public byte X, Y, Direction;

        public GCSetPosition(byte x, byte y, byte dir)
        {
            this.ID = PacketID.GCSetPosition;
            this.BodySize = 3;

            this.X = x;
            this.Y = y;
            this.Direction = dir;
        }

        public override void Write(ref NetworkStream stream)
        {
            // write id
            stream.Write(BitConverter.GetBytes((ushort)this.ID), 0, 2);

            // write size
            stream.Write(BitConverter.GetBytes(this.BodySize), 0, 4);

            // write coords
            stream.WriteByte(this.X);
            stream.WriteByte(this.Y);
            stream.WriteByte(this.Direction);

            // write unknown
            /*byte[] unk = new byte[] {
                0xBF, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB7, 0x00, 0x01, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x70, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00, 0x11, 0x00, 0x00, 0x00, 0x05,
                0x12, 0x29, 0x00, 0x13, 0x4F, 0x00, 0x14, 0x29, 0x00, 0x10, 0x05, 0x00, 0x11, 0x07, 0x00, 0x00,
                0xAE, 0x01, 0x06, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x05, 0x01, 0x20, 0xB4, 0x01, 0x0D, 0x00,
                0x00, 0x00, 0x02, 0xCD, 0x00, 0x00, 0x00, 0x01, 0x00, 0xCF, 0x00, 0x00, 0x00, 0x01, 0x00, 0xB9,
                0x01, 0x03, 0x00, 0x00, 0x00, 0x01, 0x0D, 0x00, 0xD9, 0x01, 0x1A, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x00 
            };*/

            byte[] unk = new byte[] {
                0x53, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD0, 0x01, 0x05, 0x00, 0x00, 0x00, 0x03, 0x00,
                0x00, 0x00, 0x00, 0xBF, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB7, 0x00, 0x01,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x53, 0x00, 0x11, 0x00,
                0x00, 0x00, 0x05, 0x12, 0x29, 0x00, 0x13, 0x4F, 0x00, 0x14, 0x29, 0x00, 0x10, 0x05, 0x00, 0x11,
                0x07, 0x00, 0x00, 0xAE, 0x01, 0x06, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x05, 0x01, 0x20, 0xB4,
                0x01, 0x0D, 0x00, 0x00, 0x00, 0x02, 0xCD, 0x00, 0x00, 0x00, 0x01, 0x00, 0xCF, 0x00, 0x00, 0x00,
                0x01, 0x00, 0xB9, 0x01, 0x03, 0x00, 0x00, 0x00, 0x01, 0x0D, 0x00, 0xD9, 0x01, 0x1A, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0x00 
            };
            stream.Write(unk, 0, unk.Length);
        }
    }
}