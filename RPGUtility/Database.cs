using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace RPGUtility
{
    internal class Database
    {
        private string ConnectionDB = "Server=localhost; port=5433; userid=postgres; password=DB`D5ARG}$r[>zu\\Jd7H5/vAVqs+B[3L; database=RPGUtility;";
        NpgsqlConnection Con;
        NpgsqlCommand CommandDB;
        public Database()
        {
            Connect();
        }
        private void Connect()
        {
            Con = new NpgsqlConnection();
            Con.ConnectionString = ConnectionDB;
            if (Con.State != ConnectionState.Open) { Con.Open(); }
           
            Trace.WriteLine("pomyslnie polaczono");

        }
        public string get(string sql)
        {
            //string dt =new DataTable();
            string dt="a";
            Connect();
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

        static void Main(string[] args)
        {
            Database bd=new Database();
           
            Trace.WriteLine(bd.get("Select * from \"Campaign\"")); 
            // Display the number of command line arguments.
            // Console.WriteLine(args.Length);
            
        }
    }
}
