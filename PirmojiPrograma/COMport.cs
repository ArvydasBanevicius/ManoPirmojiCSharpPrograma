using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace PirmojiPrograma
{
    public class COMportList
    {
        public static string[] PortList()
        {
            return SerialPort.GetPortNames();
        }
    }

    public delegate void CommunicationEventHandler(object sender, CommunicationDriverArgs e);
    public class CommunicationDriverArgs : EventArgs
    {
        public CommunicationDriverArgs(byte[] Buffer) { Buff = Buffer; }
        public byte[] Buff  { get; }
    }

    public class CommunicationDriver : Timer
    {
        public CommunicationDriver()
        {
            this.Tick += new EventHandler(this.DriverTick);
            this.Interval = 1;
            this.Enabled = false;
            _serialPort = new SerialPort();
        }

        private SerialPort _serialPort;
        private int _baudRate = 9600;
        private int _dataBits = 8;
        private Handshake _handshake = Handshake.None;
        private Parity _parity = Parity.None;
        private string _portName = "COM1";
        private StopBits _stopBits = StopBits.One;

        public int BaudRate { get { return _baudRate; } set { _baudRate = value; } }
        public int DataBits { get { return _dataBits; } set { _dataBits = value; } }
        public Handshake Handshake { get { return _handshake; } set { _handshake = value; } }
        public Parity Parity { get { return _parity; } set { _parity = value; } }
        public StopBits StopBits { get { return _stopBits; } set { _stopBits = value; } }
        public string PortName { get { return _portName; } set { _portName = value; } }
        public bool Open
        {
            get
            {
                return _serialPort.IsOpen;
            }
            set
            {
                StartDriver(value);
            }
        }

        private int TimeOutAfterReceived = 100;
        private int TimeOutBeforReceive = 1000;
        private int Ticks = 0;

        public int WaitBeforReceive { get { return TimeOutBeforReceive; } set { TimeOutBeforReceive = value; } }
        public int WaitAfterReceive { get { return TimeOutAfterReceived; } set { TimeOutAfterReceived = value; } }
        public int Wait { get { return Ticks; } set { Ticks = Environment.TickCount + value; } }

        public event CommunicationEventHandler CommunicationEvent;
        public event EventHandler OnTimeOutEvent;
        public CommunicationEventHandler OnReceived { get { return CommunicationEvent; } set { CommunicationEvent += new CommunicationEventHandler(value); } }
        public EventHandler OnTimeOut{ get { return OnTimeOutEvent; } set { OnTimeOutEvent += new EventHandler(value); } }
        
        void StartDriver(bool StartStop)
        {
            try
            {
                if (StartStop)
                {
                    _serialPort.BaudRate = _baudRate;
                    _serialPort.DataBits = _dataBits;
                    _serialPort.Handshake = _handshake;
                    _serialPort.Parity = _parity;
                    _serialPort.PortName = _portName;
                    _serialPort.StopBits = _stopBits;
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                    _serialPort.Open();
                    Ticks = Environment.TickCount + 10;
                    this.Start();
                    Enabled = true;
                }
                else
                {
                    _serialPort.DataReceived += null;
                    _serialPort.Close();
                    this.Stop();
                    Enabled = false;
                }
            }
            catch (Exception e)
            {
                _serialPort.DataReceived += null;
                _serialPort.Close();
                this.Stop();
                Enabled = false;
                MessageBox.Show(e.Message);// "COM port busy");
            }
        }

        public void DriverTick(object source, EventArgs e)
        {
            if (Ticks < Environment.TickCount)
            {
                Enabled = false;
                if (OnTimeOutEvent != null)
                    OnTimeOutEvent(this, e);
                Enabled = true;
            }
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[_serialPort.BytesToRead];
                    int bytesRead = _serialPort.Read(buffer, 0, _serialPort.BytesToRead);
                    if (CommunicationEvent != null)
                        CommunicationEvent(this, new CommunicationDriverArgs(buffer));
                    Ticks = Environment.TickCount + WaitAfterReceive;
                }
            }
            catch (Exception ex)
            {
                this.Open = false;
                MessageBox.Show(ex.Message);// "Lost COM port");
            }
        }

        public void SendData(ref byte[] Data, int size)
        {
            try
            {
                if (!this.Open) this.Open = true;
                _serialPort.Write(Data, 0, size);
                Ticks = Environment.TickCount + WaitBeforReceive;
            }
            catch (Exception e)
            {
                this.Open = false;
                MessageBox.Show(e.Message);// "Lost COM port" );
            }
        }
    }
}
