using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Npgsql;
namespace RPGUtility
{
    internal class Database
    {
       // private string ConnectionDB = "Server=localhost; port=5433; userid=postgres; password=DB`D5ARG}$r[>zu\\Jd7H5/vAVqs+B[3L; database=RPGUtility;";
        NpgsqlConnection Con;
        NpgsqlCommand? CommandDB;
        private static Database? _instance;
        private static readonly object _lock = new object();

        private Database()
        {
           string _connectionString = "Server=localhost; port=5433; userid=postgres; password=DB`D5ARG}$r[>zu\\Jd7H5/vAVqs+B[3L; database=RPGUtility;";
           Con= new NpgsqlConnection(_connectionString);
            if (Con.State != ConnectionState.Open) { Con.Open(); }

            Trace.WriteLine("pomyslnie polaczono");
           // Connect();
        }
        public static Database GetInstance()
        {
            if(_instance ==null)
            {
                lock(_lock)
                    if (_instance == null)
                    {
                        _instance = new Database();
                    }
               // _instance.Value = 1;
            }
            return _instance;
        }
        private void Connect()
        {
            Con = new NpgsqlConnection();
           // Con.ConnectionString = ConnectionDB;
            if (Con.State != ConnectionState.Open) { Con.Open(); }
           
            Trace.WriteLine("pomyslnie polaczono");

        }
        public string read()
        {
            //string dt =new DataTable();
            string dt="a";
            string sql = "Select * from \"Campaign\"";
            //Connect();
            CommandDB = new NpgsqlCommand(sql); 
            CommandDB.Connection = Con;
            CommandDB.CommandText = sql;
            NpgsqlDataReader dr=CommandDB.ExecuteReader();
            //dt.Load(dr);

            while (dr.Read())
            {
                dt = dr[0].ToString(); //get Value of ppassword Column
            }
            //Trace.WriteLine(dt);
            //dt = dr.GetString();
            return dt;
        }
        public void Insert()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {
        }
        public void Close()
        {
            Con.Close();
        }
      /*  static void Main(string[] args)
        {
            Database bd=Database.GetInstance();
           
            //Trace.WriteLine(); 
            bd.Close();
            // Display the number of command line arguments.
            // Console.WriteLine(args.Length);
            
        }*/
    }
}
