using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace PirmojiPrograma
{
    public class Common
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        static internal void ScrollToBottom(RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
            richTextBox.SelectionStart = richTextBox.Text.Length;
        }

        public static void GetPortList(ListBox LB)
        {
            string[] PortList = COMportList.PortList();
            foreach (var port in PortList)
            {
                LB.Items.Add(port);
            }
        }

        public static void ClearByteArray(ref byte[] src)
        {
            Array.Clear(src, 0, src.Length);
        }

        public static int AppendByteArray(ref byte[] dst, byte[] src, int LstIndex)
        {
            if ((LstIndex + src.Length) > dst.Length)
            {
                ClearByteArray(ref dst);
                return 0;
            }
            else
            {
                Array.ConstrainedCopy(src, 0, dst, LstIndex, src.Length);
                return (LstIndex + src.Length);
            }
        }

        public static string ByteArrayToString(byte[] ba, int Size)
        {
            if ((ba != null) && (Size > 0))
            {
                StringBuilder hex = new StringBuilder(Size * (2+1));
                for (int i=0; i<Size; i++)
                    hex.AppendFormat("{0:X2} ", ba[i]);
                return hex.ToString();
            }
            return "";
        }

        public static Int64 bcdTobin( ref byte[] s, int idx, int sz)
        {
            int Mul;
            Int64 Result = 0;
            sz += idx;
            if ((s[sz - 1] & 0xF0) == 0xF0)
            {
                Mul = -1;
                s[sz - 1] &= 0x0F;
            }
            else Mul = 1;
            while ((sz) > idx)
            {
                Result = Result * 100 + ((s[sz - 1] >> 4) & 0x0F) *10 + (s[sz - 1] & 0x0F);
                sz--;
            }
            return Result * Mul;
        }

        //public static string ByteArrayToString(byte[] ba)
        //{
        //    return BitConverter.ToString(ba).Replace("-", "");
        //}

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        //public static byte[] StringToByteArray(String hex)
        //{
        //    int NumberChars = hex.Length;
        //    byte[] bytes = new byte[NumberChars / 2];
        //    for (int i = 0; i < NumberChars; i += 2)
        //        bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        //    return bytes;
        //}

    }
}
