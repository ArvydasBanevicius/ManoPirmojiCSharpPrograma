using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PirmojiPrograma
{

    public partial class InfoWindow : Form
    {
        Color[] colors =
        {
                Color.Black,
                Color.Red,
                Color.Blue,
        };

        private int dataIs { get; set; }

        public delegate void UpdateInfoWindowDelegate(int dataType, byte[] buff);
        public void UpdateInfoWindow(int dataType, byte[] buff)
        {
            try
            {
                Invoke(new UpdateInfoWindowDelegate(FillRichEditBox), new object[] { dataType, buff });
            }
            catch (Exception)
            {
            }
        }

        private void FillRichEditBox(int dataType, byte[] buff)
        {
            if (dataIs != dataType) rtInfoText.Text += '\r';

            //rtInfoText.SelectionStart = rtInfoText.Text.Length;
            ////rtInfoText.SelectionColor = colors[dataType];
            ////rtInfoText.SelectedText += Common.ByteArrayToString(buff, buff.Length);

            ////rtInfoText.SelectionFont = new Font("Georgia", 16, FontStyle.Bold);
            //rtInfoText.SelectionColor = colors[dataType];
            //rtInfoText.SelectedText += Common.ByteArrayToString(buff, buff.Length);
            //rtInfoText.SelectionColor = colors[dataType];

            //rtInfoText.SelectionStart = rtInfoText.TextLength;
            //rtInfoText.SelectionLength = buff.Length * 3;
            //rtInfoText.SelectionColor = colors[dataType];
            //rtInfoText.SelectedText += Common.ByteArrayToString(buff, buff.Length);
            //rtInfoText.SelectionColor = rtInfoText.ForeColor;

            //rtInfoText.SelectionStart = rtInfoText.TextLength;
            //string str = Common.ByteArrayToString(buff, buff.Length);
            //rtInfoText.SelectedText += str;
            //rtInfoText.SelectionLength = str.Length;
            //rtInfoText.SelectionColor = colors[dataType];

            rtInfoText.SelectionStart = rtInfoText.TextLength;
            rtInfoText.SelectionLength = 0;
            rtInfoText.SelectionBackColor = colors[dataType];

            string str = "";
            if (cbHEX.Checked) str = Common.ByteArrayToString(buff, buff.Length);
            else               str = System.Text.Encoding.UTF8.GetString(buff, 0, buff.Length);
            rtInfoText.AppendText(str);

            if (cnScroll.Checked) Common.ScrollToBottom(rtInfoText);
            
            dataIs = dataType;
        }

        public InfoWindow()
        {
            InitializeComponent();
        }

        private void InfoWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.infoWondow = null;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            rtInfoText.Clear();
        }
    }
}
