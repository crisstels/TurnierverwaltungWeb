using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;


namespace TurnierverwaltungWeb
{
    public class Turnier
    {
        #region Properties
        private int _mannschaftA;
        private int _mannschaftB;
        private string _sportart;
        private int _ergebnisA;
        private int _ergebnisB;
        #endregion

        #region Accessors/Modifiers
        public int MannschaftA { get => _mannschaftA; set => _mannschaftA = value; }
        public int MannschaftB { get => _mannschaftB; set => _mannschaftB = value; }
        public string Sportart { get => _sportart; set => _sportart = value; }
        public int ErgebnisA { get => _ergebnisA; set => _ergebnisA = value; }
        public int ErgebnisB { get => _ergebnisB; set => _ergebnisB = value; }
        #endregion

        #region Konstruktor
        public Turnier()
        {
            MannschaftA = 0;
            MannschaftB = 0;
            Sportart = " ";
            ErgebnisA = 0;
            ErgebnisB = 0;
        }
        public Turnier(int mannschaftA, int mannschaftB, string sportart, int ergebnisA, int ergebnisB)
        {
            MannschaftA = mannschaftA;
            MannschaftB = mannschaftB;
            Sportart = sportart;
            ErgebnisA = ergebnisA;
            ErgebnisB = ergebnisB;
        }
        #endregion

        #region Worker
        public void DatenSpeichern()
        {
            string DatabasePath = Properties.Resources.Database;
            string connectionString = "Data Source=" + DatabasePath + ";Version=3;";

            SQLiteConnection Connection = new SQLiteConnection(connectionString);

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
            /*
            // Select ID from MannschaftA and MannschaftB
            string selectTeamA = "Select MannschaftID From Mannschaft Where Bezeichnung=(" + MannschaftA + ");";
            string selectTeamB = "Select MannschaftID From Mannschaft Where Bezeichnung=(" + MannschaftB + ");";

            SQLiteCommand command = new SQLiteCommand(selectTeamA, Connection);
            SQLiteCommand commandB = new SQLiteCommand(selectTeamB, Connection);
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
                    int id = reader.GetInt32(0);
                    
                }
            }
            else
            {
                Console.WriteLine("Error, cannot find any data for Volleyballspieler");
            }*/

            string insertTurnier = "insert into Turnierergebnis (TeilnehmerA, TeilnehmerB, Sportart, ErgebnisA, ErgebnisB) values('" + MannschaftA + "', '" + MannschaftB + "', '" + Sportart + "', '" + ErgebnisA + "', '" + ErgebnisB + "');";
            SQLiteCommand command = new SQLiteCommand(insertTurnier, Connection);
            int anzahl = -1;

            try
            {
                anzahl = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (anzahl > 0)
            {
                Console.WriteLine(anzahl);
            }

            // Close connection
            Connection.Close();
        }
        #endregion
    }
}