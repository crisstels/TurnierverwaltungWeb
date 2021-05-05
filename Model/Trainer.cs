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

        private int _trainerNummer;
        private string _sportart;
        private int _erfahrung;
        #endregion

        #region Accessors/Modifiers
        public string Sportart { get => _sportart; set => _sportart = value; }
        public int Erfahrung { get => _erfahrung; set => _erfahrung = value; }
        public int TrainerNummer { get => _trainerNummer; set => _trainerNummer = value; }
        #endregion

        #region Constructor
        public Trainer()
        {
            Sportart = "Fussball";
            Erfahrung = 0;
        }

        public Trainer(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse, int trainerNummer, string sportart, int erfahrung) : base(name, vorname, rolle, nummer, geburtstag, groesse)
        {
            TrainerNummer = trainerNummer;
            Sportart = sportart;
            Erfahrung = erfahrung;
        }
        #endregion

        #region Worker
        public void trainieren() { }

        public override void DatenSpeichern()
        {
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierDatenbank/turnier.db";
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

            // speichert zuerst die Daten in die Teilnehmertabelle

            string insertTeilnehmer = "insert into Teilnehmer values('" + Nummer + "', '" + Rolle + "', '" + Name + "', '" + Vorname + "');";
            SQLiteCommand command = new SQLiteCommand(insertTeilnehmer, Connection);

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

            // speichert nun die Daten in die Trainertabelle

            string insertTrainer = "insert into Trainer values('" + Nummer + "', '" + TrainerNummer + "', '" + Sportart + "', '" + Erfahrung + "');";
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
        #endregion
    }
}