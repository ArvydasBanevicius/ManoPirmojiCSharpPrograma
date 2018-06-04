using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PirmojiPrograma
{
    public partial class DatabaseWindow : Form
    {
        public DatabaseWindow(int SelectedIndex)
        {
            InitializeComponent();
            DatabaseClass.DeviceDataSelect(SelectedIndex, dgDeviceData);
        }
    }
}
