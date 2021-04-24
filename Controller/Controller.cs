using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Controller
    {
        private List<Teilnehmer> _teilnehmer;

        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }


        public Controller()
        {
            Teilnehmer = new List<Teilnehmer>();
        }

        public void HoleAllePersonen()
        {
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierDatenbank/turnier.db";
            string connectionString = "Data Source=" + DatabasePath + ";Version=3;";

            SQLiteConnection Connection = new SQLiteConnection(connectionString);
            SQLiteDataReader reader = null;

            // Open Database Connection
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            // Select everything from Teilnehmer Database
            string selectQuery = "Select * From Volleyball;";
            SQLiteCommand command = new SQLiteCommand(selectQuery, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string id = reader.GetValue(0).ToString();
                    string rolle = reader.GetValue(1).ToString();
                    string name = reader.GetValue(2).ToString();
                    string vorname = reader.GetValue(3).ToString();
                    string trikotnummer = reader.GetValue(4).ToString();
                    string position = reader.GetValue(5).ToString();

                    Teilnehmer tln = new Volleyballspieler(name, vorname, rolle, Convert.ToInt32(id), Convert.ToInt32(trikotnummer), position);

                    Teilnehmer.Add(tln);

                }
            }
            else
            {
                Console.WriteLine("Error. Data is not inserted");
            }
        }

        public void PersonHinzufuegen(string name, string vorname)
        {
            Teilnehmer tln = new Volleyballspieler(name, vorname, "Volleyballspieler", 1, 4, "Libero");
            tln.DatenSpeichern();
            this.Teilnehmer.Add(tln);
        }

        #region Worker

        #endregion
    }
}