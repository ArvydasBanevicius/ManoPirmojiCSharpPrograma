using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

// https://blogs.msdn.microsoft.com/spike/2009/03/03/pivot-tables-in-sql-server-a-simple-sample/
// https://techbrij.com/pivot-c-array-datatable-convert-column-to-row-linq
// https://www.c-sharpcorner.com/UploadFile/8911c4/pivot-examples-in-sql-server/

/*
 var pivot = Manufacturers.Select(m => new 
    { 
        Name = m.Name, 
        Products = Products
            .Where(p => p.ManufacturerId == m.ManufacturerId)
            .Select(p => p.Name)
            .ToList()
    });
*/

/*  -->> inner join 
select DataCollection.DeviceData from DataCollection 
inner join DeviceList on DataCollection.DeviceID = DeviceList.Id
inner join Parameter on DataCollection.ParameterID = Parameter.Id
inner join Dimension on DataCollection.DimensionID = Dimension.Id
where (DeviceList.Id = 4)
*/


namespace PirmojiPrograma
{
    public class DeviceValue
    {
        public string Value { get; set; }
        public string ParamName { get; set; }
        public string ParamDim { get; set; }
        public string ParamType { get; set; }
        public DeviceValue(DateTime Value, string ParamName, string ParamDim, string ParamType)
        {
            this.Value = string.Format("{0}", Value);
            this.ParamName = ParamName;
            this.ParamDim = ParamDim;
            this.ParamType = ParamType;
        }
        public DeviceValue(Int32 Value, string ParamName, string ParamDim, string ParamType)
        {
            this.Value = string.Format("{0}", Value);
            this.ParamName = ParamName;
            this.ParamDim = ParamDim;
            this.ParamType = ParamType;
        }
        public DeviceValue(double Value, string ParamName, string ParamDim, string ParamType)
        {
            this.Value = string.Format( "{0}", Value );
            this.ParamName = ParamName;
            this.ParamDim = ParamDim;
            this.ParamType = ParamType;
        }
        public DeviceValue(string Value, string ParamName, string ParamDim, string ParamType)
        {
            this.Value = Value;
            this.ParamName = ParamName;
            this.ParamDim = ParamDim;
            this.ParamType = ParamType;
        }
    }

    public class DeviceRecord 
    {
        public List<DeviceValue> deviceValues = new List<DeviceValue>();
        public DateTime dateTime { get; set; }
        public string DeviceName { get; set; }
        public string Location { get; set; }
        public string DeviceID { get; set; }
        public int ValueCount { get { return deviceValues.Count; } }
        public void AddValue(DeviceValue deviceValue)
        {
            deviceValues.Add(deviceValue);
        }
    }

    class DatabaseClass
    {
        /// <summary>
        /// Sarasas nauju irasu, laukianciu, kol bus irasyti i duomenu baze
        /// </summary>
        public List<DeviceRecord> deviceRecordsArray = new List<DeviceRecord>();

        Thread workThread;
        SqlConnection sqlConnection;

        /// <summary>
        /// Sukuriamas Thread-as, darbui su duomenu baze, kadangi uztrunka nuomenu sulyginimo ir irasymo proceduros
        /// </summary>
        public DatabaseClass()
        {
            workThread = new Thread(Execute);
            workThread.Start();
        }

        /// <summary>
        /// Baigian darba su programa, sunaikinamas thread-as
        /// </summary>
        public void CloseDatabase()
        {
            workThread.Abort();
        }

        /// <summary>
        /// Pridedamas irasas i duomenu baze
        /// </summary>
        /// <param name="DeviceRecord"></param>
        public void AddNewRecord(DeviceRecord deviceRecord)
        {
            deviceRecord.dateTime = DateTime.Now;
            deviceRecordsArray.Add(deviceRecord);
        }

        /// <summary>
        /// Nupaiso dataGridView lentele isrinktam prietaisui
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="dataGrid"></param>
        public static void DeviceDataSelect(int Index, DataGridView dataGrid)
        {
            string connectioString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Mano\VS\ManoProjektai\Testai\PirmojiPrograma\DevicesDataCollection.mdf;Integrated Security=True";
            var Conn = new SqlConnection(connectioString);
            Dictionary<string, string> colNames = new Dictionary<string, string>();
            try
            {
                string stringQuery = string.Format( // issifiltruojam stulpeliu pavadinimas, isfiltruoja besikartojancius "distinct" 
                        "select distinct Parameter.ParameterName, Dimension.DimensionName, DataCollection.ColumnIndex from DataCollection " +
                        "inner join DeviceList on DataCollection.DeviceID = DeviceList.Id " +
                        "inner join Parameter on DataCollection.ParameterID = Parameter.Id " +
                        "inner join Dimension on DataCollection.DimensionID = Dimension.Id " +
                        "where (DeviceList.Id = {0}) " +
                        "Order by DataCollection.ColumnIndex ", Index);

                Conn.Open();
                using (SqlCommand sql = new SqlCommand(stringQuery, Conn))
                {
                    SqlDataReader reader = sql.ExecuteReader();                    
                    while (reader.Read())
                    {
                        colNames.Add((string)reader["ParameterName"],(string)reader["DimensionName"]);
                    }
                }
            }
            finally
            {
                Conn.Close();
            }

            string StulpeliuPavadinimai="";
            string StulpeliuSelectas = "";
            if (colNames.Count > 0)
            {
                StulpeliuPavadinimai = string.Format("[{0}] AS {0}, {1}", colNames.Keys, colNames.Values);
                StulpeliuSelectas = string.Format("[{0}]", colNames.Keys);
                for (int i = 1; i < colNames.Count; i++)
                {
                    StulpeliuPavadinimai += string.Format(", [{0}] AS {0}, {1}", colNames.Keys, colNames.Values);
                    StulpeliuSelectas += string.Format(",[{0}]", colNames.Keys);
                }
                StulpeliuPavadinimai += " ";
                StulpeliuSelectas += " ";
            }

            try
            {
                string stringQuery = string.Format( // Sulankstom lentele
                        "select [DeviceTime],[Energy],[Volume],[Flow],[Power],[T1],[T2],[dT],[OnTime],[Error] " +
                        "from " +
                        "( " +
                        "  select ReadingTime, DeviceData, ParameterName, DimensionName from DataCollection  " +
                        "	inner join DeviceList on DataCollection.DeviceID = DeviceList.Id " +
                        "	inner join Parameter on DataCollection.ParameterID = Parameter.Id " +
                        "	inner join Dimension on DataCollection.DimensionID = Dimension.Id " +
                        "  where (DeviceList.Id = {0}) " +
                        ") src " +
                        "pivot " +
                        "( " +
                        "  max(DeviceData) " +
                        "  for ParameterName in([DeviceTime],[Energy],[Volume],[Flow],[Power],[T1],[T2],[dT],[OnTime],[Error]) " +
                        ") pvt ", Index);

                //string stringQuery = "select * from  DataCollection";

                Conn.Open();
                using (SqlCommand sql = new SqlCommand(stringQuery, Conn))
                {
                    sql.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    dt.Load( sql.ExecuteReader() );
                    dataGrid.DataSource = dt;
                }
            }
            finally
            {
                Conn.Close();
            }

        }

        public static void GetDeviceList(ComboBox _DeviceList)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Mano\VS\ManoProjektai\Testai\PirmojiPrograma\DevicesDataCollection.mdf;Integrated Security=True";
            var Conn = new SqlConnection(connStr);
            _DeviceList.Items.Clear();
            try
            {
                string stringQuery = // issifiltruojam stulpeliu pavadinimas, isfiltruoja besikartojancius "distinct" 
                        "select DeviceList.FabricationNumber from DeviceList";

                Conn.Open();
                using (var sql = new SqlCommand(stringQuery, Conn))
                {
                    SqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        _DeviceList.Items.Add( reader["FabricationNumber"] );
                    }
                }
            }
            finally
            {
                Conn.Close();
            }
        }
    
        /// <summary>
        /// Issaugomas duomenu irasas duomenu bazeje
        /// </summary>
        /// <param name="deviceRecord"></param>
        private void StoreNewRecord(DeviceRecord deviceRecord)
        {
            if (sqlConnection != null) 
            {
                try
                {
                    int DevID=0;

                    sqlConnection.Open();
                    // patikrinam prietaisu sarasa
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) AS RecordCount FROM DeviceList WHERE ([FabricationNumber] = @DeviceID)", sqlConnection))
                    {
                        SqlDataReader reader = null;
                        sqlCommand.Parameters.AddWithValue("@DeviceID", deviceRecord.DeviceID);
                        int Count = (int)sqlCommand.ExecuteScalar();

                        string queryStr = "";
                        if (Count == 0) // jeigu neradom sukuriam nauja prietaisa
                        { 
                            queryStr = "INSERT INTO DeviceList (FabricationNumber, DeviceName, Location) VALUES(@FabricationNumber, @DeviceName, @Location); ";
                        }
                        queryStr += "SELECT * FROM DeviceList WHERE ([FabricationNumber] = @DeviceID)";
                        using (SqlCommand DevSql = new SqlCommand(queryStr, sqlConnection))
                        {
                            if (Count == 0) // jeigu neradom sukuriam nauja prietaisa
                            {
                                DevSql.Parameters.AddWithValue("@FabricationNumber", deviceRecord.DeviceID);
                                DevSql.Parameters.AddWithValue("@DeviceName", deviceRecord.DeviceName);
                                DevSql.Parameters.AddWithValue("@Location", deviceRecord.Location);
                            }
                            DevSql.Parameters.AddWithValue("@DeviceID", deviceRecord.DeviceID);
                            reader = DevSql.ExecuteReader();
                            reader.Read();
                            DevID = (int)reader["Id"];
                        }
                        reader.Close();
                    }
                    sqlConnection.Close();

                    if (DevID > 0)
                    {
                        int i = 0;
                        foreach (var item in deviceRecord.deviceValues)
                        {
                            int ParamID=0;
                            int DimID=0;
                            int ParamTypeID=0;

                            sqlConnection.Open();
                            // patikrinam prietaisu parametru sarasa
                            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) AS RecordCount FROM Parameter WHERE ([ParameterName] = @ParameterName)", sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@ParameterName", item.ParamName);
                                int Count = (int)sqlCommand.ExecuteScalar();

                                string queryStr = "";
                                if (Count == 0) // jeigu neradom sukuriam nauja prietaisa
                                {
                                    queryStr = "INSERT INTO Parameter (ParameterName) VALUES(@ParameterName); ";
                                }
                                queryStr += "SELECT * FROM Parameter WHERE ([ParameterName] = @ParameterID)";

                                SqlDataReader reader = null;
                                using (SqlCommand ParSql = new SqlCommand(queryStr, sqlConnection))
                                {
                                    if (Count == 0) // jeigu neradom sukuriam nauja prietaisa
                                        ParSql.Parameters.AddWithValue("@ParameterName", item.ParamName);
                                    ParSql.Parameters.AddWithValue("@ParameterID", item.ParamName);
                                    reader = ParSql.ExecuteReader();
                                }
                                reader.Read();
                                ParamID = (int)reader["Id"];
                                reader.Close();
                            }
                            sqlConnection.Close();

                            sqlConnection.Open();
                            // patikrinam prietaisu parametru dimensiju sarasa
                            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) AS RecordCount FROM Dimension WHERE ([DimensionName] = @DimensionName)", sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@DimensionName", item.ParamDim);
                                int Count = (int)sqlCommand.ExecuteScalar();

                                string queryStr = "";
                                if (Count == 0) // jeigu neradom sukuriam nauja parametro dimensija
                                {
                                    queryStr = "INSERT INTO Dimension (DimensionName) VALUES(@DimensionName); ";
                                }
                                queryStr += "SELECT * FROM Dimension WHERE ([DimensionName] = @DimensionID)";

                                SqlDataReader reader = null;
                                using (SqlCommand DimSql = new SqlCommand(queryStr, sqlConnection))
                                {
                                    if (Count == 0) // jeigu neradom sukuriam nauja parametro dimensija
                                        DimSql.Parameters.AddWithValue("@DimensionName", item.ParamDim);
                                    DimSql.Parameters.AddWithValue("@DimensionID", item.ParamDim);
                                    reader = DimSql.ExecuteReader();
                                }
                                reader.Read();
                                DimID = (int)reader["Id"];
                                reader.Close();
                            }
                            sqlConnection.Close();

                            sqlConnection.Open();
                            // patikrinam prietaisu parametru tipu sarasa
                            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) AS RecordCount FROM DataType WHERE ([TypeName] = @TypeName)", sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@TypeName", item.ParamType);
                                int Count = (int)sqlCommand.ExecuteScalar();

                                string queryStr = "";
                                if (Count == 0) // jeigu neradom sukuriam nauja parametro tipa
                                {
                                    queryStr = "INSERT INTO DataType (TypeName) VALUES(@TypeName); ";
                                }
                                queryStr += "SELECT * FROM DataType WHERE ([TypeName] = @TypeID)";

                                SqlDataReader reader = null;
                                using (SqlCommand TypeSql = new SqlCommand(queryStr, sqlConnection))
                                {
                                    if (Count == 0) // jeigu neradom sukuriam nauja parametro tipa
                                        TypeSql.Parameters.AddWithValue("@TypeName", item.ParamType);
                                    TypeSql.Parameters.AddWithValue("@TypeID", item.ParamType);
                                    reader = TypeSql.ExecuteReader();
                                }
                                reader.Read();
                                ParamTypeID = (int)reader["Id"];
                                reader.Close();
                            }
                            sqlConnection.Close();

                            if ((ParamID > 0) && (DimID > 0) && (ParamTypeID > 0))
                            {
                                sqlConnection.Open();
                                // Iraso nauja irasa
                                using (SqlCommand sqlCommand = new SqlCommand(
                                       "INSERT INTO DataCollection (ReadingTime,DeviceID,DataType,DeviceData,ParameterID,DimensionID,ParameterTypeID,ColumnIndex) "+
                                       "VALUES(@ReadingTime,@DeviceID,@DataType,@DeviceData,@ParameterID,@DimensionID,@ParameterTypeID,@ColumnIndex)", sqlConnection))
                                {
                                    sqlCommand.Parameters.AddWithValue("@ReadingTime", deviceRecord.dateTime);
                                    sqlCommand.Parameters.AddWithValue("@DeviceID", DevID);
                                    sqlCommand.Parameters.AddWithValue("@DataType", 0);
                                    sqlCommand.Parameters.AddWithValue("@DeviceData", item.Value);
                                    sqlCommand.Parameters.AddWithValue("@ParameterID", ParamID);
                                    sqlCommand.Parameters.AddWithValue("@DimensionID", DimID);
                                    sqlCommand.Parameters.AddWithValue("@ParameterTypeID", ParamTypeID);
                                    sqlCommand.Parameters.AddWithValue("@ColumnIndex", i);
                                    sqlCommand.ExecuteNonQuery();
                                }
                                sqlConnection.Close();
                            }
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Uzleidziamas amzinas procesas, laukiantis naujo irasi irasymui i duomenu baze
        /// </summary>
        private void Execute()
        {
            string connectioString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Mano\VS\ManoProjektai\Testai\PirmojiPrograma\DevicesDataCollection.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectioString);
            if (sqlConnection != null)
            {
                while (true)
                {
                    while (deviceRecordsArray.Count > 0)
                    {
                        StoreNewRecord( deviceRecordsArray.ElementAt(0) );
                        deviceRecordsArray.RemoveAt(0);
                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
            else MessageBox.Show("Nera duomenu bazes");
        }

        //------------>> Kuriamos lenteles, cia tik naujai DB

        public void DeletedAllTables()
        {
            if (sqlConnection != null)
            {
                string queryStr;
                queryStr = "TRUNCATE TABLE DeviceList";
                sqlConnection.Open();
                using (SqlCommand Sql1 = new SqlCommand(queryStr, sqlConnection))
                {
                    Sql1.ExecuteReader();
                }
                sqlConnection.Close();

                queryStr = "TRUNCATE TABLE Parameter";
                sqlConnection.Open();
                using (SqlCommand Sql2 = new SqlCommand(queryStr, sqlConnection))
                {
                    Sql2.ExecuteReader();
                }
                sqlConnection.Close();

                queryStr = "TRUNCATE TABLE Dimension";
                sqlConnection.Open();
                using (SqlCommand Sql3 = new SqlCommand(queryStr, sqlConnection))
                {
                    Sql3.ExecuteReader();
                }
                sqlConnection.Close();

                queryStr = "TRUNCATE TABLE DataType";
                sqlConnection.Open();
                using (SqlCommand Sql4 = new SqlCommand(queryStr, sqlConnection))
                {
                    Sql4.ExecuteReader();
                }
                sqlConnection.Close();

                queryStr = "TRUNCATE TABLE DataCollection";
                sqlConnection.Open();
                using (SqlCommand Sql5 = new SqlCommand(queryStr, sqlConnection))
                {
                    Sql5.ExecuteReader();
                }
                sqlConnection.Close();
            }
        }


        private void CreateDeviceListTable()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("CREATE TABLE [dbo].[DeviceList] ( " +
                                                                        "[Id]         INT            IDENTITY (1, 1) NOT NULL, " +
                                                                        "[FabricationNumber] BIGINT  NULL,  " +
                                                                        "[DeviceName] NVARCHAR (120) NULL, " +
                                                                        "[Location]   NVARCHAR (120) NULL, " +
                                                                        "PRIMARY KEY CLUSTERED ([Id] ASC)  " +
                                                                    ");"))
                    {
                        sqlCommand.ExecuteNonQuery();
                        //sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void CreateDataCollectionTable()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand( "CREATE TABLE [dbo].[DataCollection] ( "+
                                                                    "[Id]              BIGINT        IDENTITY(1, 1) NOT NULL, " +
                                                                    "[ReadingTime]     DATETIME      NOT NULL, "+
                                                                    "[DeviceID]        BIGINT        NOT NULL, "+
                                                                    "[DataType]        INT           NOT NULL, "+
                                                                    "[DeviceData]      NVARCHAR(50)  NOT NULL, "+
                                                                    "[ParameterID]     INT           NOT NULL, "+
                                                                    "[DimensionID]     INT           NOT NULL, "+
                                                                    "[ParameterTypeID] INT           NOT NULL, "+
                                                                    "[ColumnIndex]     INT           NOT NULL, "+
                                                                    "PRIMARY KEY CLUSTERED([Id] ASC) "+
                                                                   ") ;"))
                    {
                        sqlCommand.ExecuteNonQuery();
                        //sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void CreateParametersTable()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand( "CREATE TABLE [dbo].[Parameter] ( "+
                                                                    "[Id]            INT           IDENTITY(1, 1) NOT NULL, "+
                                                                    "[ParameterName] NVARCHAR(50) NULL, "+
                                                                    "PRIMARY KEY CLUSTERED([Id] ASC) "+
                                                                   ") ;"))
                    {
                        sqlCommand.ExecuteNonQuery();
                        //sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void CreateDimensionTable()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("CREATE TABLE [dbo].[Dimension] ( " +
                                                                    "[Id]            INT           IDENTITY(1, 1) NOT NULL, " +
                                                                    "[DimensionName] NVARCHAR(50) NULL, " +
                                                                    "PRIMARY KEY CLUSTERED([Id] ASC) " +
                                                                   ") ;"))
                    {
                        sqlCommand.ExecuteNonQuery();
                        //sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void CreateDataTypeTable()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("CREATE TABLE [dbo].[DataType] ( " +
                                                                    "[Id]       INT           IDENTITY(1, 1) NOT NULL, " +
                                                                    "[TypeName] NVARCHAR(50) NULL, " +
                                                                    "PRIMARY KEY CLUSTERED([Id] ASC) " +
                                                                   ") ;"))
                    {
                        sqlCommand.ExecuteNonQuery();
                        //sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void CreateParameterTypesTable()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand( "CREATE TABLE [dbo].[ParameterType] ( "+
                                                                    "[Id]                INT           IDENTITY(1, 1) NOT NULL, " +
                                                                    "[ParameterTypeName] NVARCHAR(50) NULL, " +
                                                                    "PRIMARY KEY CLUSTERED([Id] ASC) " +
                                                                   ") ;"))
                    {
                        sqlCommand.ExecuteNonQuery();
                        //sqlConnection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
