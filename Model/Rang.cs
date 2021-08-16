using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Rang
    {
        #region Properties
        private string _name;
        private string _sportart;
        private int _punkte;
        #endregion

        #region Accessors/Modifiers
        public string Name { get => _name; set => _name = value; }
        public string Sportart { get => _sportart; set => _sportart = value; }
        public int Punkte { get => _punkte; set => _punkte = value; }
        #endregion

        #region Constructor
        public Rang(string name, string sportart, int punkte)
        {
            Name = name;
            Sportart = sportart;
            Punkte = punkte;
        }

        public Rang()
        {
            Name = "";
            Sportart = "";
            Punkte = 0;
        }
        #endregion

        #region Worker
        public void DatenSpeichern()
        {
            string DatabasePath = Properties.Resources.Database;
            string connectionString = "Data Source=" + DatabasePath + ";Version=3;";

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

            // speichert Daten über eine Mannschaft in die Ranglisten Tabelle, wenn eine neue Mannschaft registriert wird

            string insertMannschaft = "insert into Rangliste (Name, Sportart, Punkte ) values('" + Name + "', '" + Sportart + "', '" + Punkte + "');";
            SQLiteCommand command = new SQLiteCommand(insertMannschaft, Connection);

            try
            {
                anzahl = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            if (anzahl > 0)
            {
                Console.WriteLine(anzahl);
            }

            //close connection

            Connection.Close();

        }

        public void DatenBearbeiten()
        {
            string DatabasePath = Properties.Resources.Database;
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
            }
            //bearbeite den Punktestand nach jeder Tunierergebniseingabe
            string updatePunkte = "UPDATE Rangliste SET Punkte= Punkte + '" + Punkte + "' WHERE Name='" + Name + "' AND Sportart='" + Sportart + "' ";
            SQLiteCommand command = new SQLiteCommand(updatePunkte, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //close connections

            Connection.Close();
        }
        #endregion
    }
}