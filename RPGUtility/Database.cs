using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
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
            string _connectionString= ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            //string _connectionString = "Server=localhost; port=5433; userid=postgres; password=DB`D5ARG}$r[>zu\\Jd7H5/vAVqs+B[3L; database=RPGUtility;";
            Con = new NpgsqlConnection(_connectionString);
            if (Con.State != ConnectionState.Open) { Con.Open(); }

            Trace.WriteLine("pomyslnie polaczono");
            // Connect();
        }
        public static Database GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
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
        public void ReadAllCampaigns()
        {
            string sql = $"Select * from \"Campaign\"";
            //Connect();
            CommandDB = new NpgsqlCommand(sql);
            CommandDB.Connection = Con;
            CommandDB.CommandText = sql;
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            //dt.Load(dr);

            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
            }
        }

        public int? InsertCampaign(Campaign campaign)
        {
            int? key_id=null;
            // string sql = "select ";
            string sql = "insert into \"Campaign\" values(nextval('seq_campaign'),@name,@description,@game_master,@year) "; //string interpolation c# 6.0
            // CommandDB = new NpgsqlCommand(sql,Con);
            using (NpgsqlTransaction transaction = Con.BeginTransaction())
            {
                try
                {
                    using (NpgsqlCommand KeyCommandDB = new NpgsqlCommand("select nextval('seq_campaign')", Con))
                    {
                        key_id = Convert.ToInt32(KeyCommandDB.ExecuteScalar());
                        using (NpgsqlCommand CommandDB = new NpgsqlCommand(sql, Con))
                        {
                            // character = new Character();
                            //CommandDB.Parameters.AddWithValue("campaign_id", "seq_campaign");
                           /* CommandDB.Parameters.AddWithValue("name", campaign.name);// tutaj dodaj jeszcze zamiane tej bitmapy itd.
                            CommandDB.Parameters.AddWithValue("description", campaign.description);
                            CommandDB.Parameters.AddWithValue("game_master", campaign.game_master);
                            CommandDB.Parameters.AddWithValue("year", campaign.year);*/
                            CommandDB.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        Trace.WriteLine("Dodano rekordy do tabel.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Trace.WriteLine("Wystąpił błąd: " + ex.Message);
                }
               
            }
            return key_id;
        }
        /*public Campaign ReadCampaign(int id)
        {
            string sql = $"Select * from \"Campaign\" where campaign_id=@id";
            //Connect();
            Campaign pom;
            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            //NpgsqlDataReader dr = CommandDB.ExecuteReader();
            //dt.Load(dr);
            using (var dr= CommandDB.ExecuteReader())
            {
                while (dr.Read())
                {
                    Campaign _campaign = new Campaign(dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4));
                }
            }
            pom = _campaign;
            return _campaign;
        }*/
        public void UpdateCampaign(int id)
        {

        }
        public void DeleteCampaign(int id)
        {

        }

        public void ReadActs(int id)
        {
            string sql = $"Select * from \"Act\" where campaign_id=@id";
            //Connect();
            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            //dt.Load(dr);

            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
            }
        }

        public void ReadCharacter(int id)
        {
            string sql = $"Select * from \"Character_full_View\" where character_id=@id";
            //Connect();
            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            //dt.Load(dr);

            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
            }
        }
        public void ReadAllCharacters()
        {
            //string dt =new DataTable();
            // string dt="a";
            string sql = "Select * from \"Character_full_View\"";
            //Connect();
            CommandDB = new NpgsqlCommand(sql);
            CommandDB.Connection = Con;
            CommandDB.CommandText = sql;
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            //dt.Load(dr);

            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
            }
            //Trace.WriteLine(dt);
            //dt = dr.GetString();
            //return dt;
        }
        public void ReadInventory(int id)
        {
            string sql = "Select * from \"Inventory\" where character_id=@id"; //string interpolation c# 6.0

            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            // CommandDB.Connection = Con;
            //CommandDB.CommandText = sql;
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
                // dt = dr[0].ToString(); //get Value of ppassword Column
            }
        }
        public void RemovefromInventory(int id)
        {

        }

        public void UpdateInventory(int id)
        {

        }

        public void ReadTalent(int id)
        {
            string sql = "Select * from \"Talent\" where character_id=@id"; //string interpolation c# 6.0

            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            // CommandDB.Connection = Con;
            //CommandDB.CommandText = sql;
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
                // dt = dr[0].ToString(); //get Value of ppassword Column
            }
        }
        public void InsertTalent()
        {

        }
        public void UpdateTalent(int id)
        { }
        public void DeleteTalent(int id)
        {

        }
        public void ReadArmor(int id)
        {
            string sql = "Select * from \"Armor\" where character_id=@id"; //string interpolation c# 6.0

            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            // CommandDB.Connection = Con;
            //CommandDB.CommandText = sql;
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
                // dt = dr[0].ToString(); //get Value of ppassword Column
            }
        }
        public void InsertArmor()
        {

        }
        public void UpdateArmor(int id)
        { }
        public void DeleteArmor(int id)
        {

        }
        public void ReadWeapon(int id)
        {
            string sql = "Select * from \"Weapon\" where character_id=@id"; //string interpolation c# 6.0

            CommandDB = new NpgsqlCommand(sql, Con);
            CommandDB.Parameters.AddWithValue("id", id);
            // CommandDB.Connection = Con;
            //CommandDB.CommandText = sql;
            NpgsqlDataReader dr = CommandDB.ExecuteReader();
            while (dr.Read())
            {
                Trace.WriteLine(dr[0].ToString());
                // dt = dr[0].ToString(); //get Value of ppassword Column
            }
        }
        public void InsertWeapon()
        {

        }
        public void UpdateWeapon(int id)
        { }
        public void DeleteWeapon(int id)
        {

        }

        public void InsertCharacter(Character character)
        {
            int key_id;
           // string sql = "select ";
            string sql = "insert into \"Character\" values(@id,@image,@name,@race,@gender,@background,@birth_year,@height,@weight,@hair,@eyes,@characteristics,@place_birth,@star_sign,@relatives,@main_delty,@languages,@career,@career_path,@career_exits,@gold_crowns,@silver_shillings,@brass_penniews,@campaign_id) "; //string interpolation c# 6.0
            string sql2 = "insert into \"Statistics\" values(@id,@weapon_skill,@ballistic_skill,@strength,@toughness,@agility,@intelligence,@willpower,@fellowship,@advance_weapon_skill,@advance_ballistic_skill,@advance_strength,@advance_toughness,@advance_agility,@advance_intelligence,@advance_willpower,@advance_fellowship,@current_weapon_skill,@current_ballistic_skill,@current_strength,@current_toughness,@current_agility,@current_intelligence,@current_willpower,@current_fellowship,@attacks,@wounds,@strength_bonus,@toughness_bonus,@movement,@magic,@insanity_points,@fate_points,@advance_attacks,@advance_wounds,@advance_strength_bonus,@advance_toughness_bonus,@advance_movement,@advance_magic,@advance_insanity_points,@advance_fate_points,@current_attacks,@current_wounds,@current_strength_bonus,@current_toughness_bonus,@current_movement,@current_magic,@current_insanity_points,@current_fate_points)";
            // CommandDB = new NpgsqlCommand(sql,Con);
            using (NpgsqlTransaction transaction = Con.BeginTransaction())
            {
                try
                {
                    using (NpgsqlCommand KeyCommandDB = new NpgsqlCommand("select nextval('seq_character')", Con))
                    {
                        key_id = Convert.ToInt32(KeyCommandDB.ExecuteScalar());

                        using (NpgsqlCommand CommandDB = new NpgsqlCommand(sql, Con))
                        {
                           // character = new Character();
                           /* CommandDB.Parameters.AddWithValue("id", key_id);
                            CommandDB.Parameters.AddWithValue("image", DBNull.Value);// tutaj dodaj jeszcze zamiane tej bitmapy itd.
                            CommandDB.Parameters.AddWithValue("name", character.name);
                            CommandDB.Parameters.AddWithValue("race", character.race);
                            CommandDB.Parameters.AddWithValue("gender", character.gender);
                            CommandDB.Parameters.AddWithValue("background", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("birth_year", DBNull.Value);//tutaj dodaj jeszcze zamiane na date te postgresowom ok ok
                            CommandDB.Parameters.AddWithValue("height", character.height);
                            CommandDB.Parameters.AddWithValue("weight", character.weight);
                            CommandDB.Parameters.AddWithValue("hair", character.hair);
                            CommandDB.Parameters.AddWithValue("eyes", character.eyes);
                            CommandDB.Parameters.AddWithValue("characteristics", character.characteristics);
                            CommandDB.Parameters.AddWithValue("place_birth", character.place_birth);
                            CommandDB.Parameters.AddWithValue("star_sign", character.star_sign);
                            CommandDB.Parameters.AddWithValue("relatives", character.relatives);
                            CommandDB.Parameters.AddWithValue("main_delty", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("languages", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("career", character.career);
                            CommandDB.Parameters.AddWithValue("career_path", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("career_exits", character.career_exits);
                            CommandDB.Parameters.AddWithValue("gold_crowns", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("silver_shillings", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("brass_penniews", DBNull.Value);
                            CommandDB.Parameters.AddWithValue("campaign_id", 0);//tutaj se wezmiesz skads jaka jest tera kampania ok ok*/
                            CommandDB.ExecuteNonQuery();
                        }
                       using (NpgsqlCommand CommandDB2 = new NpgsqlCommand(sql2, Con))
                        {
                           /* CommandDB2.Parameters.AddWithValue("id", key_id);
                            CommandDB2.Parameters.AddWithValue("weapon_skill", character.weapon_skill);
                            CommandDB2.Parameters.AddWithValue("ballistic_skill", character.ballistic_skill);
                            CommandDB2.Parameters.AddWithValue("strength", character.strength);
                            CommandDB2.Parameters.AddWithValue("toughness", character.toughness);
                            CommandDB2.Parameters.AddWithValue("agility", character.agility);
                            CommandDB2.Parameters.AddWithValue("intelligence", character.inteligence);
                            CommandDB2.Parameters.AddWithValue("willpower", character.willpower);
                            CommandDB2.Parameters.AddWithValue("fellowship", character.fellowship);

                            CommandDB2.Parameters.AddWithValue("advance_weapon_skill", character.advance_weapon_skill);
                            CommandDB2.Parameters.AddWithValue("advance_ballistic_skill", character.advance_ballistic_skill);
                            CommandDB2.Parameters.AddWithValue("advance_strength", character.advance_strength);
                            CommandDB2.Parameters.AddWithValue("advance_toughness", character.advance_toughness);
                            CommandDB2.Parameters.AddWithValue("advance_agility", character.advance_agility);
                            CommandDB2.Parameters.AddWithValue("advance_intelligence", character.advance_inteligence);
                            CommandDB2.Parameters.AddWithValue("advance_willpower", character.advance_willpower);
                            CommandDB2.Parameters.AddWithValue("advance_fellowship", character.advance_fellowship);

                            CommandDB2.Parameters.AddWithValue("current_weapon_skill", character.current_weapon_skill);
                            CommandDB2.Parameters.AddWithValue("current_ballistic_skill", character.current_ballistic_skill);
                            CommandDB2.Parameters.AddWithValue("current_strength", character.current_strength);
                            CommandDB2.Parameters.AddWithValue("current_toughness", character.current_toughness);
                            CommandDB2.Parameters.AddWithValue("current_agility", character.current_agility);
                            CommandDB2.Parameters.AddWithValue("current_intelligence", character.current_inteligence);
                            CommandDB2.Parameters.AddWithValue("current_willpower", character.current_willpower);
                            CommandDB2.Parameters.AddWithValue("current_fellowship", character.current_fellowship);

                            CommandDB2.Parameters.AddWithValue("attacks", character.attacks);
                            CommandDB2.Parameters.AddWithValue("wounds", character.wounds);
                            CommandDB2.Parameters.AddWithValue("strength_bonus", character.strength_bonus);
                            CommandDB2.Parameters.AddWithValue("toughness_bonus", character.toughness_bonus);
                            CommandDB2.Parameters.AddWithValue("movement", character.movement);
                            CommandDB2.Parameters.AddWithValue("magic", character.magic);
                            CommandDB2.Parameters.AddWithValue("insanity_points", character.insanity_points);
                            CommandDB2.Parameters.AddWithValue("fate_points", character.fate_points);

                            CommandDB2.Parameters.AddWithValue("advance_attacks", character.advance_attacks);
                            CommandDB2.Parameters.AddWithValue("advance_wounds", character.advance_wounds);
                            CommandDB2.Parameters.AddWithValue("advance_strength_bonus", character.advance_strength_bonus);
                            CommandDB2.Parameters.AddWithValue("advance_toughness_bonus", character.advance_toughness_bonus);
                            CommandDB2.Parameters.AddWithValue("advance_movement", character.advance_movement);
                            CommandDB2.Parameters.AddWithValue("advance_magic", character.advance_magic);
                            CommandDB2.Parameters.AddWithValue("advance_insanity_points", character.advance_insanity_points);
                            CommandDB2.Parameters.AddWithValue("advance_fate_points", character.advance_fate_points);

                            CommandDB2.Parameters.AddWithValue("current_attacks", character.current_attacks);
                            CommandDB2.Parameters.AddWithValue("current_wounds", character.current_wounds);
                            CommandDB2.Parameters.AddWithValue("current_strength_bonus", character.current_strength_bonus);
                            CommandDB2.Parameters.AddWithValue("current_toughness_bonus", character.current_toughness_bonus);
                            CommandDB2.Parameters.AddWithValue("current_movement", character.current_movement);
                            CommandDB2.Parameters.AddWithValue("current_magic", character.current_magic);
                            CommandDB2.Parameters.AddWithValue("current_insanity_points", character.current_insanity_points);
                            CommandDB2.Parameters.AddWithValue("current_fate_points", character.current_fate_points);*/
                            CommandDB2.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        Trace.WriteLine("Dodano rekordy do tabel.");

                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Trace.WriteLine("Wystąpił błąd: " + ex.Message);
                }
            }
                // using (CommandDB = new NpgsqlCommand(sql, Con))
                // {
                

               

           // }
        /*    // CommandDB.Connection = Con;
            // CommandDB.CommandText = sql;
            //CommandDB.ExecuteNonQuery();
            int numRowsAffected = CommandDB.ExecuteNonQuery();
            if (numRowsAffected > 0)
            {
                Trace.WriteLine("Dodano rekord do tabeli.");
            }
            else
            {
                Trace.WriteLine("Nie udało się dodać rekordu do tabeli.");
            }

            numRowsAffected = CommandDB.ExecuteNonQuery();
            if (numRowsAffected > 0)
            {
                Trace.WriteLine("Dodano rekord do tabeli.");
            }
            else
            {
                Trace.WriteLine("Nie udało się dodać rekordu do tabeli.");
            }*/
            // NPgsql dr = CommandDB.ExecuteReader();
            //  while (dr.Read())
            //  {
            //      Trace.WriteLine(dr[0].ToString());
            // dt = dr[0].ToString(); //get Value of ppassword Column
            //  }
        }
        
        public void Close()
        {
            Con.Close();
        }
    }
}
