using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SQLite;


namespace TurnierverwaltungWeb
{
    class Physio : Teilnehmer
    {
        #region Properties
        private int _physioNummer;
        private int _jahreErfahrung;
        #endregion

        #region Accessors/Modifiers
        public int JahreErfahrung { get => _jahreErfahrung; set => _jahreErfahrung = value; }
        public int PhysioNummer { get => _physioNummer; set => _physioNummer = value; }
        #endregion

        #region Constructor
        public Physio() {
            JahreErfahrung = 0;
        }

        public Physio(string name, string vorname, string rolle, int nummer, int physioNummer, int jahreErfahrung) : base(name, vorname, rolle, nummer)
        {
            JahreErfahrung = jahreErfahrung;
            PhysioNummer = physioNummer;
        }
        #endregion

        #region Worker
        public void heileSpieler(int spielerNummer)
        {
            Console.WriteLine("Der Spieler mit der Nummer {0} wird geheilt.", spielerNummer);
        }

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

            // speichert nun die Daten in die Spielertabelle

            string insertSpieler = "insert into Physio values('" + Nummer + "', '" + PhysioNummer + "', '" + JahreErfahrung + "');";
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

            // Close connection
            Connection.Close();
        }
        #endregion

    }
}