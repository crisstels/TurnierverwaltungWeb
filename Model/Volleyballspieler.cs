using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Volleyballspieler : Teilnehmer
    {
        #region Properties

        private int _spielernummer;
        private string _position;
        private int _sprunghoehe;

        #endregion

        #region Accessors/Modifiers

        public int Spielernummer
        {
            get => _spielernummer;
            set => _spielernummer = value;
        }

        public string Position
        {
            get => _position;
            set => _position = value;
        }
        public int Sprunghoehe 
        { 
            get => _sprunghoehe; 
            set => _sprunghoehe = value; 
        }

        #endregion

        #region Constructor

        public Volleyballspieler()
        {
            Position = " ";
            Spielernummer = 0;
            Sprunghoehe = 0;

        }

        public Volleyballspieler(int spielernummer, string position, int sprunghoehe)
        {
            Spielernummer = spielernummer;
            Position = position;
            Sprunghoehe = sprunghoehe;
        }

        public Volleyballspieler(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse, int spielernummer, string position, int sprunghoehe) : base(name, vorname, rolle, nummer, geburtstag, groesse)
        {
            Spielernummer = spielernummer;
            Position = position;
            Sprunghoehe = sprunghoehe;
        }

        #endregion

        #region Worker

        public void BallPassen(){}

        public override void DatenSpeichern()
        {
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierDatenbank/turnier.db";
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
                Console.WriteLine(e);
            }

            if (anzahl > 0)
            {
                Console.WriteLine(anzahl);
            }

            // speichert nun die Daten in die Spielertabelle

            string insertSpieler = "insert into Volleyballspieler (VolleyballspielerID, Trikotnummer, Position, Sprunghoehe) values('" + lastID + "', '" + Position + "', '" + Spielernummer +"', '" + Sprunghoehe + "');";
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