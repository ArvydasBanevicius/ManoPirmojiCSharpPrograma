using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.IO;

namespace PirmojiPrograma
{

    public partial class Form1 : Form
    {
        Random rnd = new Random();
        static public InfoWindow infoWondow;
        CommunicationDriver COMport;

        DatabaseClass databaseClass;

        int RecIndex = 0;
        byte[] ReceiverBuffer = new byte[1000];

        public Form1()
        {
            InitializeComponent();
            COMport = new CommunicationDriver();
            COMport.PortName = "COM10";
            COMport.BaudRate = 19200;// 2400;
            COMport.DataBits = 8;
            COMport.Parity = Parity.Even;
            COMport.StopBits = StopBits.One;
            COMport.OnTimeOutEvent += DoReceivedTimeOut;
            COMport.OnReceived += DoReceivedData;

            Common.GetPortList(lbPortList);

            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 1;
            dataGridView1.Columns[0].Name = "Nr";
            dataGridView1.Columns[1].Name = "Parametras";
            dataGridView1.Columns[2].Name = "Reikšmė";
            dataGridView1.Columns[3].Name = "Matavimo vienetai";

            comboBox1.SelectedIndex = 0;

            DatabaseClass.GetDeviceList(cbDeviceList);
            if (cbDeviceList.Items.Count > 0)
                cbDeviceList.SelectedIndex = 0;
        }

        private void ShowInfo(int DataType, byte[] buff)
        {
            if (infoWondow != null)
            {
                infoWondow.UpdateInfoWindow(DataType, buff);
            }
        }

        private void DoReceivedTimeOut(object sender, EventArgs e)
        {
            if (RecIndex > 0)
            {
                Common.ClearByteArray(ref ReceiverBuffer);
            }
            RecIndex = 0;

            byte[] buff = { 0x10, 0x40, 0xFE, 0x3E, 0x16 };
            COMport.SendData(ref buff, buff.Length);
            ShowInfo(2, buff);
        }

        private void DoReceivedData(object sender, CommunicationDriverArgs ev)
        {
            try
            {
                ShowInfo(1, ev.Buff);
                RecIndex = Common.AppendByteArray(ref ReceiverBuffer, ev.Buff, RecIndex);
                COMport.Wait = 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Common.ClearByteArray(ref ReceiverBuffer);
                RecIndex = 0;
                if (COMport.Open)
                    COMport.Open = false;
                COMport.PortName = lbPortList.Items[lbPortList.SelectedIndex].ToString();
                COMport.Open = true;
            }
            catch (Exception)
            {
                MessageBox.Show("COM port not seleted");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            COMport.Open = false;
        }

        private void btOpenInfoWindow_Click(object sender, EventArgs e)
        {
            if (infoWondow == null)
            {
                infoWondow = new InfoWindow();
                infoWondow.Show();
            }
            else
            {
                infoWondow.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] Buff = new byte[260];
            //MODBUSdrv.PrepareREQ(ref Buff);

            if (databaseClass == null)
                databaseClass = new DatabaseClass();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (databaseClass != null)
            {
                databaseClass.CloseDatabase();
                databaseClass = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (databaseClass != null)
            {
                DeviceRecord deviceRecord = new DeviceRecord();
                deviceRecord.DeviceID = string.Format("{0}", rnd.Next(1, 5) );
                deviceRecord.DeviceName = "Prietaiso pavadinimas";
                deviceRecord.Location = "Kazkur";

                deviceRecord.AddValue(new DeviceValue(DateTime.Now, "DeviceTime","","") );
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 1000.0, "Energy", "MWh", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 100000.0, "Volume", "m3", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 10.0, "Flow", "m3/h", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 10.0, "Power", "kW", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 100.0, "T1", "°C", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 100.0, "T2", "°C", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 100.0, "dT", "°C", ""));
                deviceRecord.AddValue(new DeviceValue(rnd.NextDouble() * 100.0, "OnTime", "h", ""));
                deviceRecord.AddValue(new DeviceValue("0000001001101111", "Error", "", ""));

                databaseClass.AddNewRecord(deviceRecord);

                DatabaseClass.GetDeviceList(cbDeviceList);
                if (cbDeviceList.Items.Count > 0)
                    cbDeviceList.SelectedIndex = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            databaseClass.DeletedAllTables();

            DatabaseClass.GetDeviceList(cbDeviceList);
            if (cbDeviceList.Items.Count > 0)
                cbDeviceList.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (databaseClass != null)
            {                
                DatabaseWindow databaseWindow = new DatabaseWindow(cbDeviceList.SelectedIndex );
                databaseWindow.Show();
            }
        }

        private void NuskaitytiDuomenys(DeviceRecord deviceRecord)
        {
            dataGridView1.Rows.Clear();
            label1.Text = "";
            if (deviceRecord.ValueCount > 0)
            {
                label1.Text = string.Format("Prietaiso gamyklinis numeris: {0:00000000}", deviceRecord.DeviceID); 
                for (int i = 0; i < deviceRecord.ValueCount; i++)
                {
                    dataGridView1.RowCount += 1;
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    dataGridView1.Rows[i].Cells[1].Value = deviceRecord.deviceValues[i].ParamName;
                    dataGridView1.Rows[i].Cells[2].Value = string.Format( "{0:0.000}", deviceRecord.deviceValues[i].Value);
                    dataGridView1.Rows[i].Cells[3].Value = deviceRecord.deviceValues[i].ParamDim;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeviceRecord deviceRecord = new DeviceRecord();
            byte[] test;
            switch (comboBox1.SelectedIndex)
            {
                case 0: test = MBusClass.TestData1;
                    break;
                case 1: test = MBusClass.TestData2;
                    break;
                case 2: test = MBusClass.TestData3;
                    break;
                case 3: test = MBusClass.TestData4;
                    break;
            default: return;
            }

            deviceRecord.DeviceName = "Prietaiso pavadinimas";
            deviceRecord.Location = "Kazkur";
            MBusClass.CheckReceivedData(ref test, deviceRecord);
            if (deviceRecord.ValueCount > 0)
            {
                if (databaseClass != null)
                {
                    databaseClass.AddNewRecord(deviceRecord);
                    if (cbDeviceList.Items.Count > 0)
                        cbDeviceList.SelectedIndex = 0;
                }
                NuskaitytiDuomenys(deviceRecord);
            }
        }
    }
}




//https://limbioliong.wordpress.com/2011/10/26/quick-serializationdeserialization-of-a-managed-structure/

//https://www.dotnetperls.com/richtextbox
//https://www.google.lt/search?rlz=1C1CHBD_enLT787LT787&ei=47kAW-jkGMKqsgG4yZLADA&q=how+C%23+add+text+to+richeditbox&oq=how+C%23+add+text+to+richeditbox&gs_l=psy-ab.3...4693.5466.0.5975.2.2.0.0.0.0.80.154.2.2.0....0...1c.1.64.psy-ab..0.0.0....0.DV-xquluN2A
//https://www.telerik.com/forums/drag-and-drop-a-text-on-on-a-richtextbox
