using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirmojiPrograma
{
    //[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct REQModBusHead
    {
        public byte Addr;
        public byte COM;
        public ushort REG;
        public ushort Length;
    }

    unsafe class MODBUSdrv
    {
        public byte[] Data = new byte[260];

        public static void PrepareREQ(ref byte[] buff)
        {
            unsafe
            {
                //fixed(REQModBusHead* REQ = REQModBusHead.Equals(  buff ))
                //REQ->Addr = 1;
                //REQ->COM = 0x03;
                //REQ->REG = 0x0000;
                //REQ->Length = 2;
            }
        }
    }
}
