using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PirmojiPrograma
{
    class MBusClass
    {
        public static ushort SchneiderManufacture = 0x4CA3;

        public static byte[] TestData1 = {  0x68, 0x4E, 0x4E, 0x68, 0x08, 0x00, 0x72, 0x80, 0x50, 0x90,
                                            0x49, 0x24, 0x23, 0x49, 0x06, 0xEB, 0x00, 0x00, 0x00, 0x0C,
                                            0x14, 0x41, 0x52, 0x62, 0x00, 0x8C, 0x10, 0x12, 0x93, 0x41,
                                            0x52, 0x62, 0x0B, 0x3B, 0x00, 0x00, 0x00, 0x8C, 0x20, 0x14,
                                            0x42, 0x52, 0x62, 0x00, 0x8C, 0x30, 0x14, 0x00, 0x00, 0x00,
                                            0x00, 0x04, 0x6D, 0x03, 0x14, 0x42, 0x26, 0x4C, 0x14, 0x54,
                                            0x86, 0x38, 0x00, 0x42, 0x6C, 0x3F, 0x2C, 0x42, 0xEC, 0x7E,
                                            0x5F, 0x2C, 0x0A, 0x92, 0x2A, 0x00, 0x10, 0x0A, 0x92, 0x2B,
                                            0x00, 0x10, 0x1A, 0x16  };

        public static byte[] TestData2 = {  0x68, 0x4D, 0x4D, 0x68, 0x08, 0xFD, 0x72, 0x78, 0x85, 0x62,
                                            0x43, 0xD3, 0x10, 0x01, 0x0C, 0xA4, 0x00, 0x00, 0x00, 0x0C,
                                            0xFD, 0x11, 0x78, 0x85, 0x62, 0x43, 0x0C, 0x0F, 0x00, 0x23,
                                            0x42, 0x11, 0x0C, 0x14, 0x08, 0x04, 0x13, 0x66, 0x0C, 0x2D,
                                            0x49, 0x36, 0x48, 0x47, 0x0C, 0x3D, 0x45, 0x00, 0x00, 0x00,
                                            0x0B, 0x5A, 0x91, 0x04, 0x00, 0x0B, 0x5E, 0x03, 0x02, 0x00,
                                            0x0B, 0x61, 0x70, 0x28, 0x00, 0x04, 0x22, 0xFC, 0x09, 0x02,
                                            0x00, 0x04, 0x6D, 0x24, 0x36, 0x42, 0x26, 0x01, 0xFD, 0x17,
                                            0x03, 0x58, 0x16  };

        public static byte[] TestData3 = {  0x68, 0x8B, 0x8B, 0x68, 0x08, 0x0C, 0x72, 0x12, 0x20, 0x14, 
                                            0x04, 0xB4, 0x05, 0xA8, 0x0C, 0x4B, 0x00, 0xFF, 0xFF, 0x04, 
                                            0x8E, 0x7D, 0x89, 0x08, 0x08, 0x00, 0x04, 0x15, 0x37, 0x48, 
                                            0x01, 0x02, 0x84, 0x40, 0x14, 0xFC, 0x63, 0x8F, 0x01, 0x42, 
                                            0x6C, 0x4A, 0x24, 0x44, 0x8E, 0x7D, 0x20, 0x08, 0x08, 0x00, 
                                            0xC4, 0x40, 0x14, 0xBC, 0x02, 0x8E, 0x01, 0x82, 0x01, 0x6C, 
                                            0x3E, 0x24, 0x84, 0x01, 0x8E, 0x7D, 0x63, 0xA6, 0x07, 0x00, 
                                            0x84, 0x41, 0x14, 0xAD, 0xDB, 0xAE, 0x00, 0x03, 0x22, 0x36, 
                                            0x30, 0x02, 0x05, 0x2E, 0x39, 0xC6, 0xCE, 0x42, 0x05, 0x3E, 
                                            0xE2, 0x23, 0x06, 0x40, 0x85, 0x40, 0x3E, 0x00, 0x00, 0x00, 
                                            0x00, 0x05, 0x5B, 0x06, 0x30, 0x86, 0x42, 0x55, 0x5B, 0x8C, 
                                            0x74, 0x34, 0x43, 0x05, 0x5F, 0x2A, 0xC4, 0xBD, 0x41, 0x55, 
                                            0x5F, 0xB2, 0xA0, 0x02, 0x43, 0x05, 0x63, 0xF7, 0x7D, 0x2D, 
                                            0x42, 0x55, 0x63, 0xBE, 0x17, 0x2F, 0x43, 0x04, 0x6D, 0x27, 
                                            0x09, 0x52, 0x24, 0x71, 0x16  };

        public static byte[] TestData4 = {  0x68, 0x4D, 0x4D, 0x68, 0x08, 0x4E, 0x72, 0x78, 0x85, 0x62,
                                            0x43, 0xD3, 0x10, 0x01, 0x0C, 0xA5, 0x00, 0x00, 0x00, 0x0C,
                                            0xFD, 0x11, 0x78, 0x85, 0x62, 0x43, 0x0C, 0x0F, 0x01, 0x23,
                                            0x42, 0x11, 0x0C, 0x14, 0x15, 0x04, 0x13, 0x66, 0x0C, 0x2D,
                                            0x49, 0x36, 0x48, 0x47, 0x0C, 0x3D, 0x44, 0x00, 0x00, 0x00,
                                            0x0B, 0x5A, 0x14, 0x05, 0x00, 0x0B, 0x5E, 0x04, 0x02, 0x00,
                                            0x0B, 0x61, 0x91, 0x30, 0x00, 0x04, 0x22, 0xFC, 0x09, 0x02,
                                            0x00, 0x04, 0x6D, 0x24, 0x36, 0x42, 0x26, 0x01, 0xFD, 0x17,
                                            0x03, 0x65, 0x16  };

        //public struct TMBusHeader
        //{
        //    public byte CField;
        //    public byte AField;
        //    public byte CIField;
        //    public ulong ID;
        //    public ushort Manuf;
        //    public byte Version;
        //    public byte Medium;
        //    public byte AccNo;
        //    public byte Status;
        //    public ushort Signature;
        //};

        public class VIF_DIF_Value
        {
            private int _ValueSize = 0;
            private string _Value = "";
            private int _Unit = 0;
            private int _Tariff = 0;
            private int _Storage = 0;
            private int _Function = 0;
            private string _Name = "";
            private string _Dimention = "";
            private int _DateTimeFormat = 0;
            private double _Daug = 1;

            public int ValueSize { get { return this._ValueSize; } set { this._ValueSize = value; } }
            public string Value { get { return this._Value; } set { this._Value = value; } }
            public int Unit { get { return this._Unit; } set { this._Unit = value; } }
            public int Tariff { get { return this._Tariff; } set { this._Tariff = value; } }
            public int Storage { get { return this._Storage; } set { this._Storage = value; } }
            public int Function { get { return this._Function; } set { this._Function = value; } }
            public string Name { get { return this._Name; } set { this._Name = value; } }
            public string Dimention { get { return this._Dimention; } set { this._Dimention = value; } }
            public int DateTimeFormat { get { return this._DateTimeFormat; } set { this._DateTimeFormat = value; } }
            public double Daug { get { return this._Daug; } set { this._Daug = value; } }
        }


        public static int MBusCheckSum(ref byte[] Buff, bool wrCRC = true)
        {
            int i, Size;
            byte CRC;

            if (Buff[0] == 0x68)
            {
                Size = Buff[1] + 4;
                i = 4;
            }
            else
            {
                Size = 3;
                i = 1;
            }
            CRC = 0;
            while (i < Size)
            {
                CRC += Buff[i];
                i++;
            }

            Size += 2;
            if (wrCRC)
            {
                Buff[i]  = CRC;
                Buff[i + 1] = 0x16;
                return (Size);
            }
            else return ((Buff[i] == CRC) ? (Size):(0));
        }

        public static void CheckReceivedData(ref byte[] buff, DeviceRecord deviceRecord)
        {
            int Size;
            if ((Size = MBusCheckSum(ref buff, false)) > 0)
            {
                DecodingMBUSData(ref buff, Size, deviceRecord);
            }
        }

        private static bool DecodingMBUSData( ref byte[] Data, int Size, DeviceRecord deviceRecord)
        {
            int ValueIndex = 0;
            deviceRecord.DeviceID = string.Format( "{0}", Common.bcdTobin( ref Data, 7, 4) );

            ValueIndex = 12 + 7;
            while (ValueIndex < Size-2)
            {
                var ValueClass = new VIF_DIF_Value();
                ValueIndex = DecodingDIF(ref Data, ValueIndex, ValueClass);
                ValueIndex = DecodingVIF(ref Data, ValueIndex, ValueClass);
                if (ValueClass.DateTimeFormat > 0)
                {
                    switch (ValueClass.DateTimeFormat)
                    {
                        case 1:
                            ValueClass.Value = DecodeDateTypeF(ref Data, ValueIndex);
                            break;
                        case 2:
                            ValueClass.Value = DecodeDateTimeTypeF(ref Data, ValueIndex);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (ValueClass.ValueSize)
                    {
                        case 0: return false;
                        case 1:
                            ValueClass.Value = string.Format("{0}", (Data[ValueIndex]) * ValueClass.Daug);
                            break;
                        case 2:
                            ValueClass.Value = string.Format("{0}", (System.BitConverter.ToUInt16(Data, ValueIndex)) * ValueClass.Daug);
                            break;
                        case 3:
                            ValueClass.Value = string.Format("{0}", (System.BitConverter.ToUInt32(Data, ValueIndex) & 0xFFFFFF) * ValueClass.Daug);
                            break;
                        case 4:
                            ValueClass.Value = string.Format("{0}", (System.BitConverter.ToUInt32(Data, ValueIndex)) * ValueClass.Daug);
                            break;
                        case 5:
                            try
                            {
                                ValueClass.Value = string.Format("{0}", (System.BitConverter.ToSingle(Data, ValueIndex)) * ValueClass.Daug);
                            }
                            catch (Exception)
                            {
                                ValueClass.Value = "";
                            }
                            ValueClass.ValueSize = 4;
                            break;
                        case 6:
                            ValueClass.Value = string.Format("{0}", (System.BitConverter.ToUInt64(Data, ValueIndex) & 0xFFFFFFFFFFFF)*ValueClass.Daug );
                            break;
                        case 7:
                            ValueClass.Value = string.Format("{0}", (System.BitConverter.ToUInt64(Data, ValueIndex)) * ValueClass.Daug);
                            break;
                        case 0x0D:
                            ValueClass.ValueSize = Data[ValueIndex];
                            break;
                        default:
                            if ((ValueClass.ValueSize & 0x08) > 0)
                            {
                                ValueClass.Value = string.Format("{0}", (Common.bcdTobin(ref Data, ValueIndex, (ValueClass.ValueSize & 7))) * ValueClass.Daug);
                                ValueClass.ValueSize = (ValueClass.ValueSize & 0x07);
                            }
                            else return false;
                            break;
                    }
                }
                deviceRecord.AddValue( new DeviceValue(ValueClass.Value, ValueClass.Name, ValueClass.Dimention, "") );
                ValueIndex += ValueClass.ValueSize;
            }
            return true;
        }

        private static int DecodingVIF(ref byte[] Buff, int Idx, VIF_DIF_Value MBUSValue)
        {
            byte VIF;
            MBUSValue.Daug = 1;
            if ((Buff[Idx] & 0x80) != 0)
            {
                if (Buff[Idx] == 0xFB)
                {
                    //VIF_Is_2:
                    Idx++;
                    while ((Buff[Idx] & 0x80) != 0) Idx++;
                    VIF = Buff[Idx];
                    switch ((Buff[Idx] & 0x78) >> 3)
                    {
                        case 0:
                            MBUSValue.Daug = System.Math.Pow( 10, ((VIF & 0x01) - 1));
                            MBUSValue.Name = "Energy";
                            MBUSValue.Dimention = "MWh";
                            break;
                        case 1:
                            if ((VIF & 0x06) == 0)
                            {
                                MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x01) - 1);
                                MBUSValue.Name = "Energy";
                                MBUSValue.Dimention = "GJ";
                            }
                            else
                            {
                                if ((VIF & 0x04)>0)
                                {
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 1) * 0.001;
                                    MBUSValue.Name = "Energy";
                                    MBUSValue.Dimention = "GJ";
                                }
                            }
                            break;
                        case 2:
                            switch (VIF & 0x04)
                            {
                                case 0:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x01) + 2);
                                    MBUSValue.Name = "Volume_m3*100";
                                    MBUSValue.Dimention = "m3";
                                    break;
                                case 4:
                                    if ((VIF & 0x03) == 3)
                                    {
                                        MBUSValue.Name = "Error";
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x01) + 2);
                            MBUSValue.Name = "Mass";
                            MBUSValue.Dimention = "t";
                            break;
                        case 4:
                            switch (VIF & 0x07)
                            {
                                case 1: MBUSValue.Daug = 0.1; MBUSValue.Name = "Volume"; MBUSValue.Dimention = "feet3"; break;
                                case 2: MBUSValue.Daug = 0.1; MBUSValue.Name = "Volume"; MBUSValue.Dimention = "gallon*10"; break;
                                case 3: MBUSValue.Daug = 1; MBUSValue.Name = "Volume"; MBUSValue.Dimention = "gallon"; break;
                                case 4: MBUSValue.Daug = 0.001; MBUSValue.Name = "Volume"; MBUSValue.Dimention = "Gallon min*0001"; break;
                                case 5: MBUSValue.Daug = 1; MBUSValue.Name = "Volume"; MBUSValue.Dimention = "Gallon min*1"; break;
                                case 6: MBUSValue.Daug = 1; MBUSValue.Name = "Volume"; MBUSValue.Dimention = "Gallon*h1"; break;
                            }
                            break;
                        case 5:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x01) - 1);
                            MBUSValue.Name = "Power";
                            MBUSValue.Dimention = "MW";
                            break;
                        case 6:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x01) - 1);
                            MBUSValue.Name = "Power";
                            MBUSValue.Dimention = "GJ/h";
                            break;
                        case 0xB:
                            MBUSValue.Dimention = "°K";
                            switch (VIF & 0x04)
                            {
                                case 0:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                                    MBUSValue.Name = "Flow. Temperatrure";
                                    MBUSValue.Dimention = "°F";
                                    break;
                                case 4:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                                    MBUSValue.Name = "Ret. Temperature";
                                    MBUSValue.Name = "°F";
                                    break;
                            }
                            break;
                        case 0xC:
                            MBUSValue.Dimention = "°K";
                            switch (VIF & 0x04)
                            {
                                case 0:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                                    MBUSValue.Name = "Temperature Difference";
                                    MBUSValue.Dimention = "°F";
                                    break;
                                case 4:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                                    MBUSValue.Name = "Ext.Temperature";
                                    MBUSValue.Dimention = "°F";
                                    break;
                            }
                            break;
                        //       rmR13,
                        case 0xE:
                            MBUSValue.Dimention = "°K";
                            switch (VIF & 0x04)
                            {
                                case 0:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                                    MBUSValue.Name = "Temperature Limit";
                                    MBUSValue.Dimention = "°F";
                                    break;
                                case 4:
                                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                                    MBUSValue.Name = "Temperature Limit";
                                    MBUSValue.Dimention = "°C";
                                    break;
                            }
                            break;
                        case 0xF:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 3);
                            MBUSValue.Name = "Max Power";
                            MBUSValue.Dimention = "W";
                            break;
                    }
                }
                else
                {
                    if (Buff[Idx] == 0xFD)
                    {
                        //VIF_Is_3:
                        do
                        {
                            Idx++;
                            switch (Buff[Idx] & 0x7F)
                            {
                                case 0x00:
                                case 0x01:
                                case 0x02:
                                case 0x03: MBUSValue.Name = "Credits";
                                           MBUSValue.Dimention = "";
                                    break;  // E000 00nn	Credit of 10nn-3 of the nominal local legal currency units	Currency Units
                                case 0x04:
                                case 0x05:
                                case 0x06:
                                case 0x07: MBUSValue.Name = "Debit"; break;  // E000 01nn	Debit of 10nn-3 of the nominal local legal currency units
                                case 0x08: MBUSValue.Name = "Access Number"; break;// E000 1000	Access Number (transmission count)
                                case 0x09: MBUSValue.Name = "Medium"; break;   // E000 1001	Medium (as in fixed header)
                                case 0x0A: MBUSValue.Name = "Manufacturer"; break;// E000 1010	Manufacturer (as in fixed header)
                                case 0x0B: MBUSValue.Name = "Parameter set identification"; break;// E000 1011	Parameter set identification	Enhanced Identification
                                case 0x0C: MBUSValue.Name = "Model"; break;// E000 1100	Model / Version
                                case 0x0D: MBUSValue.Name = "Hardware version"; break;// E000 1101	Hardware version #
                                case 0x0E: MBUSValue.Name = "Firmware version"; break;// E000 1110	Firmware version #
                                case 0x0F: MBUSValue.Name = "Software version"; break;// E000 1111	Software version #
                                case 0x10: MBUSValue.Name = "Customer location"; break;// E001 0000	Customer location
                                case 0x11: MBUSValue.Name = "Customer"; break;// E001 0001	Customer
                                case 0x12: MBUSValue.Name = "Access Code User"; break;// E001 0010	Access Code User
                                case 0x13: MBUSValue.Name = "Access Code Operator"; break;// E001 0011	Access Code Operator	Implementation of all
                                case 0x14: MBUSValue.Name = "Access Code System Operator"; break;// E001 0100	Access Code System Operator	TC294 WG1 requirements
                                case 0x15: MBUSValue.Name = "Access Code Developer"; break;// E001 0101	Access Code Developer	(improved selection ..)
                                case 0x16: MBUSValue.Name = "Password"; break;// E001 0110	Password
                                                                     
                                case 0x17: MBUSValue.Name = "Error flags"; break;// E001 0111	Error flags (binary)
                                case 0x18: MBUSValue.Name = "Error mask"; break;// E001 1000	Error mask
                                case 0x19: break;// E001 1001	Reserved
                                case 0x1A: MBUSValue.Name = "Digital Output (binary)"; break;// E001 1010	Digital Output (binary)
                                case 0x1B: MBUSValue.Name = "Digital Input (binary)"; break;// E001 1011	Digital Input (binary)
                                case 0x1C: MBUSValue.Name = "Baudrate [Baud]"; break;// E001 1100	Baudrate [Baud]
                                case 0x1D: MBUSValue.Name = "response delay time [bittimes]"; break;// E001 1101	response delay time [bittimes]
                                case 0x1E: MBUSValue.Name = "Retry"; break;// E001 1110	Retry
                                case 0x1F: break;// E001 1111	Reserved
                                case 0x20: MBUSValue.Name = "First storage # for cyclic storage"; break;// E010 0000	First storage # for cyclic storage
                                case 0x21: MBUSValue.Name = "Last storage # for cyclic storage"; break;// E010 0001	Last storage # for cyclic storage
                                case 0x22: MBUSValue.Name = "Size of storage block"; break;// E010 0010	Size of storage block
                                case 0x23: break;// E010 0011	Reserved
                                case 0x24:
                                case 0x25:
                                case 0x26:
                                case 0x27: MBUSValue.Name = "Storage interval [sec(s)..day(s)]"; break;// E010 01nn	Storage interval [sec(s)..day(s)] *
                                case 0x28: MBUSValue.Name = "Storage interval month(s)	management"; break;// E010 1000	Storage interval month(s)	management
                                case 0x29: MBUSValue.Name = "Storage interval year(s)"; break;// E010 1001	Storage interval year(s)
                                case 0x2A: break;// E010 1010	Reserved
                                case 0x2B: break;// E010 1011	Reserved
                                case 0x2C:
                                case 0x2D:
                                case 0x2E:
                                case 0x2F: MBUSValue.Name = "Duration since last readout [sec(s)..day(s)] "; break;// E010 11nn	Duration since last readout [sec(s)..day(s)] *
                                case 0x30: MBUSValue.Name = "Start (date/time) of tariff"; break;// E011 0000	Start (date/time) of tariff *
                                case 0x31:
                                case 0x32:
                                case 0x33: MBUSValue.Name = "Duration of tariff"; break;// E011 00nn	Duration of tariff (nn=01 ..11: min to days)
                                case 0x34:
                                case 0x35:
                                case 0x36:
                                case 0x37: MBUSValue.Name = "Period of tariff sec(s)"; break;// E011 01nn	Period of tariff [sec(s) to day(s)] *
                                case 0x38: MBUSValue.Name = "Period of tariff months(s)"; break;// E011 1000	Period of tariff months(s)	Enhanced tariff
                                case 0x39: MBUSValue.Name = "Period of tariff year(s)"; break;// E011 1001	Period of tariff year(s)	management
                                case 0x3A: MBUSValue.Name = "dimensionless"; break;// E011 1010	dimensionless / no VIF
                                case 0x3B: break;// E011 1011	Reserved
                                case 0x3C:
                                case 0x3D:
                                case 0x3E:
                                case 0x3F: break;// E011 11xx	Reserved

                                case 0x40:
                                case 0x41:
                                case 0x42:
                                case 0x43:
                                case 0x44:
                                case 0x45:
                                case 0x46:
                                case 0x47:
                                case 0x48:
                                case 0x49:
                                case 0x4A:
                                case 0x4B:
                                case 0x4C:
                                case 0x4D:
                                case 0x4E:
                                case 0x4F:
                                    MBUSValue.Daug = System.Math.Pow(10, ((Buff[Idx] & 0x0F) - 9));
                                    MBUSValue.Name = "Volts";            // E100 nnnn	10nnnn-9 Volts	electrical units
                                    MBUSValue.Dimention = "V";
                                    break;
                                case 0x50:
                                case 0x51:
                                case 0x52:
                                case 0x53:
                                case 0x54:
                                case 0x55:
                                case 0x56:
                                case 0x57:
                                case 0x58:
                                case 0x59:
                                case 0x5A:
                                case 0x5B:
                                case 0x5C:
                                case 0x5D:
                                case 0x5E:
                                case 0x5F:
                                    MBUSValue.Name = "Ampers";
                                    MBUSValue.Daug = System.Math.Pow(10, ((Buff[Idx] & 0x0F) - 12));
                                    MBUSValue.Dimention = "A";
                                    break;
                                case 0x60: MBUSValue.Name = "Reset counter"; break;// E110 0000	Reset counter
                                case 0x61: MBUSValue.Name = "Cumulation counter"; break;// E110 0001	Cumulation counter
                                case 0x62: MBUSValue.Name = "Control signal"; break;// E110 0010	Control signal
                                case 0x63: MBUSValue.Name = "Day of week"; break;// E110 0011	Day of week
                                case 0x64: MBUSValue.Name = "Week number"; break;// E110 0100	Week number
                                case 0x65: MBUSValue.Name = "Time point of day change"; break;// E110 0101	Time point of day change
                                case 0x66: MBUSValue.Name = "State of parameter activation"; break;// E110 0110	State of parameter activation
                                case 0x67: MBUSValue.Name = "Special supplier information"; break;// E110 0111	Special supplier information
                                case 0x68:
                                case 0x69:
                                case 0x6A:
                                case 0x6B: MBUSValue.Name = "Duration since last cumulation"; break;// E110 10pp	Duration since last cumulation [hour(s)..years(s)]*
                                case 0x6C:
                                case 0x6D:
                                case 0x6E:
                                case 0x6F: MBUSValue.Name = "Operating time battery"; break;// E110 11pp	Operating time battery [hour(s)..years(s)]*
                                case 0x70: MBUSValue.Name = "Date and time of battery change"; break;// E111 0000	Date and time of battery change
                                case 0x71:
                                case 0x72:
                                case 0x73:
                                case 0x74:
                                case 0x75: MBUSValue.Name = "Date and time of battery change"; MBUSValue.Dimention = "h"; break;// E111 0000	Date and time of battery change
                                case 0x76:
                                case 0x77:
                                case 0x78:
                                case 0x79:
                                case 0x7A:
                                case 0x7B:
                                case 0x7C:
                                case 0x7D:
                                case 0x7E: break;
                                case 0x7F:
                                    Idx++;
                                    //if (MBUSValue.Manufacture == SchneiderManufacture) MBUSValue.ValUnit = Buff[Idx];
                                    break;
                                default:
                                    Idx++;
                                    break;
                            }
                        }
                        while ((Buff[Idx] & 0x80) > 0);
                    }
                    else
                    {
                        DefaultVIF(ref Buff, Idx, MBUSValue);
                        while ((Buff[Idx] & 0x80) != 0)
                        {         // patikrinam manufaktura is headerio
                            if ((System.BitConverter.ToUInt16(Buff, 11) == SchneiderManufacture) && (Buff[Idx] == 0xFF))
                            {
                                Idx++;
                                switch (Buff[Idx])
                                {
                                    case 0x0A:
                                        MBUSValue.Name = "Phase";
                                        MBUSValue.Dimention = "cosF";
                                        break;
                                    case 0x0B:
                                        MBUSValue.Name = "Frequency";
                                        MBUSValue.Dimention = "Hz";
                                        break;
                                }
                                break;
                            }
                            Idx++;  // patikrinam manufaktura
                            if ((System.BitConverter.ToUInt16(Buff, 11) == SchneiderManufacture) && (Buff[Idx] == 0xFF))
                            {
                                Idx++;
                                MBUSValue.Unit = Buff[Idx] + 3;
                                break;
                            }
                            Idx = VIFE(ref Buff, Idx, MBUSValue);
                        }
                    }
                }
            }
            else
            {
                Idx = DefaultVIF(ref Buff, Idx, MBUSValue);
                //switch (DefaultVIF(ref Buff, Idx, MBUSValue))
                //{
                //    case 1: goto VIF_Is_2; break;
                //    case 2: goto VIF_Is_3; break;
                //}
            }

            Idx++;

            if (MBUSValue.Unit > 0)
                MBUSValue.Name += MBUSValue.Unit;
            if (MBUSValue.Storage > 0)
                MBUSValue.Name += ", S"+ MBUSValue.Storage;
            if (MBUSValue.Tariff > 0)
                MBUSValue.Name += ", T" + MBUSValue.Tariff;
            if (MBUSValue.Function > 0)
                MBUSValue.Name += ", F" + MBUSValue.Function;

            return Idx;
        }


        private static int VIFE(ref byte[] Buff, int Idx, VIF_DIF_Value MBUSValue)
        {
            switch (Buff[Idx] & 0x70)
            {
                case 0x10: break;
                case 0x20:
                    switch (Buff[Idx] & 0x0F)
                    {
                        case 0: MBUSValue.Name += " per second";       break;
                        case 1: MBUSValue.Name += " per minute";       break;
                        case 2: MBUSValue.Name += " per hour";         break;
                        case 3: MBUSValue.Name += " per day";          break;
                        case 4: MBUSValue.Name += " per week";         break;
                        case 5: MBUSValue.Name += " per month";        break;
                        case 6: MBUSValue.Name += " per year";         break;
                        case 7: MBUSValue.Name += " per measurement";  break;
                        case 0x8:
                        case 0x9:
                        case 0xA:
                        case 0xB:
                            if ((Buff[Idx] & 0x02) == 0)
                                 MBUSValue.Name += string.Format( " pulse on input {0}", (Buff[Idx] & 1));
                            else MBUSValue.Name += string.Format(" pulse on output {0}", (Buff[Idx] & 1));
                            break;
                        case 0xC: MBUSValue.Name += " per liter";      break;
                        case 0xD: MBUSValue.Name += " per m3";         break;
                        case 0xE: MBUSValue.Name += " per kg";         break;
                        case 0xF: MBUSValue.Name += " per K (Kelvin)"; break;
                    }
                    break;

                case 0x30:
                    switch (Buff[Idx] & 0x0F)
                    {
                        case 0: MBUSValue.Name += " per kWh";          break; // 
                        case 1: MBUSValue.Name += " per GJ";           break;
                        case 2: MBUSValue.Name += " per kW";           break;
                        case 3: MBUSValue.Name += " per (K*l)";        break;
                        case 4: MBUSValue.Name += " per V";            break;
                        case 5: MBUSValue.Name += " per A";            break;
                        case 6: MBUSValue.Name += " by sek";           break;
                        case 7: MBUSValue.Name += " by sek/V";         break;
                        case 8: MBUSValue.Name += " by sek/A";         break;
                        case 9: MBUSValue.Name += " date";             break;

                        case 0xB: MBUSValue.Name += " accumulated positive";   break;//' accumul. if positive';
                        case 0xC: MBUSValue.Name += " accumulated negative";   break;//' accumul. if negative';
                    }
                    break;

                case 0x40:
                    MBUSValue.Name = "Average Duration";
                    if ((Buff[Idx] & 0x08) == 0) MBUSValue.Function = 1;// "min";
                    else MBUSValue.Function = 2;// _st_max;
                    //if ((Buff[Idx] & 0x04) == 0) MBUSValue.ValTariff++;
                    //MBUSValue.VType = vtAverDuration;
                    break;

                case 0x50:
                    MBUSValue.Tariff++;
                    if ((Buff[Idx] & 0x08) == 0) MBUSValue.Function = 1;// _st_min;
                    else MBUSValue.Function = 2;// _st_max;
                    if ((Buff[Idx] & 0x04) == 0) MBUSValue.Tariff++;
                    MBUSValue.Name = "Average Duration";
                    switch (Buff[Idx] & 0x03)
                    {
                        case 0: MBUSValue.Dimention = "sec"; break;
                        case 1: MBUSValue.Dimention = "min"; break;
                        case 2: MBUSValue.Dimention = "hour"; break;
                        case 3: MBUSValue.Dimention = "days"; break;
                    }
                    break;

                case 0x60:
                    MBUSValue.Tariff = 1;
                    if ((Buff[Idx] & 0x04) == 0)
                    {
                        MBUSValue.Name = "Average Duration";
                        switch (Buff[Idx] & 0x03)
                        {
                            case 0: MBUSValue.Dimention = "sec"; break;
                            case 1: MBUSValue.Dimention = "min"; break;
                            case 2: MBUSValue.Dimention = "hour"; break;
                            case 3: MBUSValue.Dimention = "days"; break;
                        }
                    }
                    else
                    {
                        if ((Buff[Idx] & 0x01) == 0)
                        {
                            MBUSValue.Name = "Time";
                            MBUSValue.DateTimeFormat = 1;
                        }
                        else
                        {
                            MBUSValue.Name = "Time";
                            MBUSValue.DateTimeFormat = 2;
                        }
                    }
                    MBUSValue.Name = "Average Duration";
                    break;
                case 0x70:
                    switch (Buff[Idx])
                    {
                        case 0x70:
                        case 0x71:
                        case 0x72:
                        case 0x73:
                        case 0x74:
                        case 0x75:
                        case 0x76:
                        case 0x77:
                            MBUSValue.Daug *= System.Math.Pow(10, ((Buff[Idx] & 7) - 6));
                            break;
                        case 0x78:
                        case 0x79:
                        case 0x7A:
                        case 0x7B:
                            MBUSValue.Daug += System.Math.Pow(10, ((Buff[Idx] & 3) - 3));
                            break;
                        case 0x7D:
                            MBUSValue.Daug *= System.Math.Pow(10, 3);
                            break;
                    }
                    MBUSValue.Tariff = (Buff[Idx] & 0xF);
                    break;
                default: MBUSValue.Tariff++;
                    break;
            }
            return (Idx);
        }




        private static int DefaultVIF(ref byte[] Buff, int Idx, VIF_DIF_Value MBUSValue)
        {
            byte VIF;
            VIF = Buff[Idx];
            switch ((Buff[Idx] & 0x78) >> 3)
            {
                case 0:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 3);
                    MBUSValue.Name = "Energy";
                    MBUSValue.Dimention = "Wh";
                    break;
                case 1:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07));
                    MBUSValue.Name = "Energy";
                    MBUSValue.Dimention = "J";
                    break;
                case 2:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 6);
                    MBUSValue.Name = "Volume";
                    MBUSValue.Dimention = "m3";
                    break;
                case 3:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 3);
                    MBUSValue.Name = "Mass";
                    MBUSValue.Dimention = "kg";
                    break;
                case 4:
                    switch (VIF & 0x04)
                    {
                        case 0:
                            MBUSValue.Name = "Time";
                            switch (VIF & 0x03)
                            {
                                case 0: MBUSValue.Dimention = "sek"; break;
                                case 1: MBUSValue.Dimention = "min"; break;
                                case 2: MBUSValue.Dimention = "h"; break;
                                case 3: MBUSValue.Dimention = "days"; break;
                            }
                            break;
                        case 4:
                            MBUSValue.Name = "WorkTime";
                            switch (VIF & 0x03)
                            {
                                case 0: MBUSValue.Dimention = "sek"; break;
                                case 1: MBUSValue.Dimention = "min"; break;
                                case 2: MBUSValue.Dimention = "h"; break;
                                case 3: MBUSValue.Dimention = "days"; break;
                            }
                            break;
                    }
                    break;
                case 5:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 3);
                    MBUSValue.Name = "Power";
                    MBUSValue.Dimention = "W";
                    break;
                case 6:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07));
                    MBUSValue.Name = "Power";
                    MBUSValue.Dimention = "J/h";
                    break;
                case 7:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 6);
                    MBUSValue.Name = "Volume Flow";
                    MBUSValue.Dimention = "m3/h";
                    break;
                case 8:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 7);
                    MBUSValue.Name = "Volume Flow";
                    MBUSValue.Dimention = "m3/min";
                    break;
                case 9:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 9);
                    MBUSValue.Name = "Volume Flow";
                    MBUSValue.Dimention = "m3/s";
                    break;
                case 10:
                    MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x07) - 3);
                    MBUSValue.Name = "Mass Flow";
                    MBUSValue.Dimention = "kg/h";
                    break;
                case 11:
                    switch (VIF & 0x04)
                    {
                        case 0:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                            MBUSValue.Name = "Flow Temperature";
                            MBUSValue.Dimention = "°C";
                            break;
                        case 4:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                            MBUSValue.Name = "Return Temperature";
                            MBUSValue.Dimention = "°C";
                            break;
                    }
                    break;
                case 12:
                    switch (VIF & 0x04)
                    {
                        case 0:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                            MBUSValue.Name = "Temperature Difference";
                            MBUSValue.Dimention = "°K";
                            break;
                        case 4:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                            MBUSValue.Name = "Ext. Temperature";
                            MBUSValue.Dimention = "°C";
                            break;
                    }
                    break;
                case 13:
                    switch (VIF & 0x04)
                    {
                        case 0:
                            MBUSValue.Daug = System.Math.Pow(10, (VIF & 0x03) - 3);
                            MBUSValue.Name = "Pressure";
                            MBUSValue.Dimention = "bar";
                            break;
                        case 4:
                            if ((VIF & 0x02) == 0)
                            {
                                if ((VIF & 0x01) == 0)
                                {
                                    MBUSValue.DateTimeFormat = 1;
                                    MBUSValue.Name = "Date";
                                }
                                else
                                {
                                    MBUSValue.DateTimeFormat = 2;
                                    MBUSValue.Name = "Date & time";
                                }
                            }
                            else
                            {
                                MBUSValue.Name = "H.C.A.";
                                MBUSValue.Dimention = "H.C.A.";
                            }
                            break;
                        default: break;
                    }
                    break;
                case 14:
                    switch (VIF & 0x04)
                    {
                        case 0:
                            MBUSValue.Name = "OnTime";
                            switch (VIF & 0x03)
                            {
                                case 0: MBUSValue.Dimention = "sek"; break;
                                case 1: MBUSValue.Dimention = "min"; break;
                                case 2: MBUSValue.Dimention = "h"; break;
                                case 3: MBUSValue.Dimention = "days"; break;
                            }
                            break;
                        case 4:
                            MBUSValue.Name = "OnTime";
                            switch (VIF & 0x03)
                            {
                                case 0: MBUSValue.Dimention = "sek"; break;
                                case 1: MBUSValue.Dimention = "min"; break;
                                case 2: MBUSValue.Dimention = "h"; break;
                                case 3: MBUSValue.Dimention = "days"; break;
                            }
                            break;
                    }
                    break;
                case 15:
                    switch (VIF & 0x07)
                    {
                        case 0:
                            MBUSValue.Name = "FabricationNo";
                            break;
                        case 1:
                            MBUSValue.Name = "Enhanced";
                            break;
                        case 2:
                            MBUSValue.Name = "BusAddress";
                            break;
                        case 3: break;  //goto VIF_Is_2;                 
                        case 4:
                            MBUSValue.Name = "SpecValue";
                            Idx++;
                            Idx = Buff[Idx];
                            break;
                        case 5: break;  //goto VIF_Is_3;
                        case 6:
                            MBUSValue.Name = "SpecValue";
                            break;
                        case 7:
                            MBUSValue.Name = "SpecValue";
                            break;
                    }
                    break;
                default:
                    break;
            }
            return Idx;
        }


        private static int DecodingDIF(ref byte[] Buff, int Idx, VIF_DIF_Value Val)
        {
            Val.ValueSize = (Buff[Idx] & 0x0F);
            int i = 0;
            do
            {
                if (i > 0)
                {
                    Val.Unit += (((Buff[Idx] & 0x40) > 0) ? (1) : (0)) << 1;
                    Val.Tariff += ((Buff[Idx] & 0x30) >> 4) << ((i - 1) * 2);
                    Val.Storage += ((Buff[Idx] & 0xF) << ((4 * (i - 1)) + 1));
                }
                else
                {
                    Val.Storage = (((Buff[Idx] & 0x40) > 0) ? (1) : (0));
                    Val.Function = ((Buff[Idx] & 0x30) >> 4);
                }
                Idx++;
                i++;
            }
            while ((Buff[Idx - 1] & 0x80) > 0);
            if (Val.Unit > 0) Val.Unit >>= 1;
            return Idx;
        }

        // Datos ir laiko dekodavimas is kazkurio documento
        private static string DecodeDateTimeTypeF(ref byte[] buff, int Idx)
        {
            int minutes = 0;
            int hours = 0;
            int days = 0;
            int month = 0;
            int year = 0;

            try
            {
                if ((System.BitConverter.ToUInt32(buff, Idx) == 0) || (System.BitConverter.ToInt32(buff, Idx) == -1)) throw new Exception();//  goto DT_Error1;
                minutes = buff[Idx + 0] & 0x3F; // decode minutes

                if (minutes > 59) throw new Exception();//  goto DT_Error1;
                hours = buff[Idx + 1] & 0x1F; // decode hours
                if (hours > 23) throw new Exception();//  goto DT_Error1;

                days = buff[Idx + 2] & 0x1F; // decode days
                if ((days > 31) || (days == 0)) throw new Exception();//  goto DT_Error1;

                month = buff[Idx + 3] & 0x0F; // decode months
                if ((month > 12) || (month == 0)) throw new Exception();//  goto DT_Error1;

                year = ((buff[Idx + 3] & 0xF0) >> 1) | ((buff[Idx + 2] >> 5) & 0x07);
                if (year > 99) throw new Exception();//  
            }
            catch (Exception)
            {
                year = 0;
                month = 1;
                days = 1;
            }
            year = 2000 + year;
            
            return string.Format("{0}", new DateTime(year, month, days, hours, minutes, 0));
        }

        // Datos dekodavimas is kazkurio documento
        private static string DecodeDateTypeF(ref byte[] buff, int Idx)
        {
            int days = 0;
            int month = 0;
            int year = 0;

            try
            {
                if ((System.BitConverter.ToUInt32(buff, Idx) == 0) || (System.BitConverter.ToInt32(buff, Idx) == -1)) throw new Exception();
                days = buff[0] & 0x1F; // decode days
                if ((days > 31) || (days == 0)) throw new Exception();

                month = buff[Idx + 1] & 0x0F; // decode months
                if ((month > 12) || (month == 0)) throw new Exception();

                year = (((buff[Idx + 1] & 0xF0) >> 1) | (buff[Idx + 0] >> 5));
                if (year > 99) throw new Exception();
            }
            catch (Exception)
            {
                year = 0;
                month = 1;
                days = 1;
            }
            year = 2000 + year;
            return string.Format("{0}", new DateTime(year, month, days));
        }

    }
}
