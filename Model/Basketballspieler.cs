using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Basketballspieler : Teilnehmer
    {
        #region Properties
        private int _trikotnummer;
        private string _position;
        private int _anzahlKoerbe;

        #endregion

        #region Accessors/Modifiers

        public int Trikotnummer
        {
            get => _trikotnummer;
            set => _trikotnummer = value;
        }

        public string Position
        {
            get => _position;
            set => _position = value;
        }
        public int AnzahlKoerbe { get => _anzahlKoerbe; set => _anzahlKoerbe = value; }

        #endregion

        #region Constructor

        public Basketballspieler()
        {
            Position = " ";
            Trikotnummer = 0;
        }

        public Basketballspieler(int trikotnummer, string position, int koerbe)
        {
            Trikotnummer = trikotnummer;
            Position = position;
            AnzahlKoerbe = koerbe;
        }

        public Basketballspieler(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse, int trikotnummer, string position, int koerbe) : base(name, vorname, rolle, nummer, geburtstag, groesse)
        {
            Trikotnummer = trikotnummer;
            Position = position;
            AnzahlKoerbe = koerbe;
        }

        #endregion

        #region Worker

        public override void DatenSpeichern()
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

            string insertSpieler = "insert into Basketballspieler (Trikotnummer, Position, AnzahlKoerbe, BasketballspielerID) values('" + Trikotnummer + "', '" + Position + "', '" + AnzahlKoerbe + "', '" + lastID + "');";
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

        public override void DatenBearbeiten(Teilnehmer tln)
        {
            Basketballspieler basket = (Basketballspieler)tln;
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

            //update entry in Basketballspieler table
            string updateBasketball = "UPDATE Volleyballspieler SET VolleyballspielerID='" + tln.Rolle + "' Trikotnummer='" + basket.Trikotnummer + "' Position= '" + basket.Position + "' " +
                "AnzahlKoerbe='" + basket.AnzahlKoerbe + "'  WHERE TeilnehmerID='" + tln.Nummer + "' ";
            command = new SQLiteCommand(updateBasketball, Connection);

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

            //delete one entry from Basketballspieler
            delete = "DELETE FROM Basketballspieler WHERE BasketballspielerID='" + tln.Nummer + "' ";
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
    }
    #endregion
}