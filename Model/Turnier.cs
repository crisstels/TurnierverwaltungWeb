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
        private string _nameA;
        private string _nameB;
        #endregion

        #region Accessors/Modifiers
        public int MannschaftA { get => _mannschaftA; set => _mannschaftA = value; }
        public int MannschaftB { get => _mannschaftB; set => _mannschaftB = value; }
        public string Sportart { get => _sportart; set => _sportart = value; }
        public int ErgebnisA { get => _ergebnisA; set => _ergebnisA = value; }
        public int ErgebnisB { get => _ergebnisB; set => _ergebnisB = value; }
        public string NameA { get => _nameA; set => _nameA = value; }
        public string NameB { get => _nameB; set => _nameB = value; }
        #endregion

        #region Konstruktor
        public Turnier()
        {
            MannschaftA = 0;
            MannschaftB = 0;
            Sportart = " ";
            ErgebnisA = 0;
            ErgebnisB = 0;
            NameA = "";
            NameB = "";
        }
        public Turnier(int mannschaftA, int mannschaftB, string sportart, int ergebnisA, int ergebnisB)
        {
            MannschaftA = mannschaftA;
            MannschaftB = mannschaftB;
            Sportart = sportart;
            ErgebnisA = ergebnisA;
            ErgebnisB = ergebnisB;
        }

        public Turnier(string nameA, string nameB, string sportart, int ergebnisA, int ergebnisB)
        {
            NameA = nameA;
            NameB = nameB;
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