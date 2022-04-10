using System;
using System.Data.SqlClient;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;
using System.Data;
using System.Configuration;

namespace RecognitionWPF.Models
{
    public class SQLManager
    {
        //private readonly string connection = @"Data Source=tcp: 192.168.3.44, 1433;Initial Catalog=VDS;Integrated Security=True;User ID=TOOECP;Password=12345qwert";
        private readonly string connection = @"Data Source=DESKTOP-KI31THC\SQLEXPRESS;Initial Catalog=AS;Integrated Security=True";
        SqlConnection sqlConnection;
        RecognitionDataContext recognitionData;

        public Action<string> DisplayMessage = delegate { };

        public bool IsOpen { get => sqlConnection.State == System.Data.ConnectionState.Open; }
#if DEBUG
        public string ConnectionString { get => connection; }
#else
        public string ConnectionString { get => ConfigurationManager.ConnectionStrings["ConnectionStirng"].ConnectionString; }
#endif

        public RecognitionDataContext RecognitionData { get => recognitionData; }

        public bool Login()
        {
            sqlConnection = sqlConnection ?? new SqlConnection(ConnectionString);

            try
            {
                sqlConnection.Open();
                recognitionData = new RecognitionDataContext(ConnectionString);
            }
            catch (Exception ex)
            {
                DisplayMessage(ex.Message);
                return false;
            }
            return IsOpen;
        }

        public void Logout()
        {
            if (IsOpen)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlConnection = null;
            }
        }
    }

    public partial class RecognitionDataContext : DataContext
    {
        public RecognitionDataContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection)
        {
        }

        public RecognitionDataContext(IDbConnection connection) : base(connection)
        {
        }

        public RecognitionDataContext(string fileOrServerOrConnection, MappingSource mapping) : base(fileOrServerOrConnection, mapping)
        {
        }

        public RecognitionDataContext(IDbConnection connection, MappingSource mapping) : base(connection, mapping)
        {
        }

        public Table<RecognitionRow> Recognitions { get => this.GetTable<RecognitionRow>(); }

        public void InsertRecognition(RecognitionRow row)
        {
            Recognitions.InsertOnSubmit(row);
            this.SubmitChanges();
        }

        public void UpdateRecognition(RecognitionRow row)
        {
            this.SubmitChanges();
        }

        public void DeleteRecognition(RecognitionRow row)
        {
            Recognitions.DeleteOnSubmit(row);
            this.SubmitChanges();
        }
    }

    [Table(Name = "Recognition")]
    public class RecognitionRow //: INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        [Column(IsDbGenerated = true, IsPrimaryKey = true, Name = "ID")]
        public int ID { get; set; }

        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        [Column(Name = "Number")]
        public string Number { get; set; }

        [Column(Name = "Confidence")]
        public decimal Confidence { get; set; }

        //#region INotifyPropertyChanged
        //public event PropertyChangingEventHandler PropertyChanging;
        //protected virtual void SendPropertyChanging()
        //{
        //    if ((this.PropertyChanging != null))
        //    {
        //        this.PropertyChanging(this, emptyChangingEventArgs);
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void SendPropertyChanged(String propertyName)
        //{
        //    if ((this.PropertyChanged != null))
        //    {
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //#endregion
    }
}
