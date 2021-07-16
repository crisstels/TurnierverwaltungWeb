using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SQLite;


namespace TurnierverwaltungWeb
{
    class Trainer : Teilnehmer
    {
        #region Properties

        private string _sportart;
        private int _erfahrung;
        #endregion

        #region Accessors/Modifiers
        public string Sportart { get => _sportart; set => _sportart = value; }
        public int Erfahrung { get => _erfahrung; set => _erfahrung = value; }
        #endregion

        #region Constructor
        public Trainer()
        {
            Sportart = "Fussball";
            Erfahrung = 0;
        }

        public Trainer(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse, string sportart, int erfahrung) : base(name, vorname, rolle, nummer, geburtstag, groesse)
        {
            Sportart = sportart;
            Erfahrung = erfahrung;
        }
        #endregion

        #region Worker

        public override void DatenSpeichern()
        {
            string DatabasePath = Properties.Resources.Database;
            string connectionString = "Data Source=" + DatabasePath + ";Version=3;";

            SQLiteConnection Connection = new SQLiteConnection(connectionString);
            int anzahl = -1;
            long lastID = 0;

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

            // speichert zuerst die Daten in die Teilnehmertabelle

            string insertTeilnehmer = "insert into Teilnehmer (Rolle, Name, Vorname, Geburtstag, Groesse ) values('" + Rolle + "', '" + Name + "', '" + Vorname + "', '" + Geburtstag + "', '" + Groesse + "');";
            SQLiteCommand command = new SQLiteCommand(insertTeilnehmer, Connection);

            try
            {
                anzahl = command.ExecuteNonQuery();
                lastID = Connection.LastInsertRowId;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            if (anzahl > 0)
            {
                Console.WriteLine(anzahl);
            }

            // speichert nun die Daten in die Trainertabelle

            string insertTrainer = "insert into Trainer values('" + lastID + "', '" + Sportart + "', '" + Erfahrung + "');";
            SQLiteCommand command1 = new SQLiteCommand(insertTrainer, Connection);
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

            // Close connection
            Connection.Close();

        }

        public override void DatenBearbeiten(Teilnehmer tln)
        {
            Trainer trainer = (Trainer)tln;
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
            //update entry in Teilnehmer table
            string updateTeilnehmer = "UPDATE Teilnehmer SET Rolle='" + tln.Rolle + "' Name='" + tln.Name + "' Vorname= '" + tln.Vorname + "' " +
                "Geburtstag='" + tln.Geburtstag + "' Groesse='" + tln.Groesse + "' WHERE TeilnehmerID='" + tln.Nummer + "' ";
            SQLiteCommand command = new SQLiteCommand(updateTeilnehmer, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //update entry in Trainer table
            string updateVolleyball = "UPDATE Volleyballspieler SET VolleyballspielerID='" + tln.Rolle + "' JahreErfahrung='" + trainer.Erfahrung + "' Sportart= '" + trainer.Sportart + "' WHERE TeilnehmerID='" + tln.Nummer + "' ";

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

        public override void DatenLöschen(Teilnehmer tln)
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

            //delete one entry from Teilnehmer
            string delete = "DELETE FROM Teilnehmer WHERE TeilnehmerID='" + tln.Nummer + "' ";
            SQLiteCommand command = new SQLiteCommand(delete, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //delete one entry from Trainer
            delete = "DELETE FROM Trainer WHERE TrainerID='" + tln.Nummer + "' ";
            command = new SQLiteCommand(delete, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        #endregion
    }
}