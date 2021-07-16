using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;


namespace TurnierverwaltungWeb
{
    public class Mannschaft
    {
        private string _name;
        private string _sportart;
        private List<Teilnehmer> _spieler;

        public Mannschaft(string name, List<Teilnehmer> spieler, string sportart)
        {
            Name = name;
            Spieler = spieler;
            Sportart = sportart;
        }

        public Mannschaft()
        {
            Name = "";
            Spieler = new List<Teilnehmer>();
            Sportart = "";
        }
        public string Name { get => _name; set => _name = value; }
        public List<Teilnehmer> Spieler { get => _spieler; set => _spieler = value; }
        public string Sportart { get => _sportart; set => _sportart = value; }

        public void MannschaftSpeichern(List<int> nummern)
        {
            string DatabasePath = Properties.Resources.Database;
            string connectionString = "Data Source=" + DatabasePath + ";Version=3;";
            long lastID = 0;

            SQLiteConnection Connection = new SQLiteConnection(connectionString);
            int anzahl = -1;

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

            // speichert zuerst die Daten in der Mannschaftstabelle

            string insertMannschaft = "insert into Mannschaft(Name, Sportart) values('" + Name + "', '" + Sportart + "'); ";
            SQLiteCommand command = new SQLiteCommand(insertMannschaft, Connection);

            try
            {
                anzahl = command.ExecuteNonQuery();
                lastID = Connection.LastInsertRowId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (anzahl > 0)
            {
                Console.WriteLine(anzahl);
            }

            // speichert nun die Spieler in der ist_Mitglied_von Tabelle
            foreach(int idSpieler in nummern){

                string insertSpieler = "insert into Mitglied_von (TeilnehmerID, MannschaftID) values('" + idSpieler + "', '" + lastID + "');";
                SQLiteCommand command1 = new SQLiteCommand(insertSpieler, Connection);
                anzahl = -1;

                try
                {
                    anzahl = command1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (anzahl > 0)
                {
                    Console.WriteLine(anzahl);
                }
            }
            // Close connection
            Connection.Close();

        }
    }
}