using System;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Volleyballspieler : Teilnehmer
    {
        #region Properties

        private int _trikotnummer;
        private string _position;
        private int _sprunghoehe;

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
            Trikotnummer = 0;
            Sprunghoehe = 0;

        }

        public Volleyballspieler(int spielernummer, string position, int sprunghoehe)
        {
            Trikotnummer = spielernummer;
            Position = position;
            Sprunghoehe = sprunghoehe;
        }

        public Volleyballspieler(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse, int spielernummer, string position, int sprunghoehe) : base(name, vorname, rolle, nummer, geburtstag, groesse)
        {
            Trikotnummer = spielernummer;
            Position = position;
            Sprunghoehe = sprunghoehe;
        }

        #endregion

        #region Worker


        public override void DatenSpeichern()
        {
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierverwaltungWeb/TurnierDatenbank/turnier.db";
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

            string insertSpieler = "insert into Volleyballspieler (VolleyballspielerID, Trikotnummer, Position, Sprunghoehe) values('" + lastID + "', '" + Position + "', '" + Trikotnummer + "', '" + Sprunghoehe + "');";
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

        public override void DatenBearbeiten(Teilnehmer  tln)
        {
            Volleyballspieler volley = (Volleyballspieler)tln;
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierverwaltungWeb/TurnierDatenbank/turnier.db";
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
            string updateTeilnehmer = "UPDATE Teilnehmer SET Rolle='"+tln.Rolle+"' Name='" +tln.Name+"' Vorname= '"+tln.Vorname+"' " +
                "Geburtstag='"+tln.Geburtstag+"' Groesse='"+tln.Groesse+"' WHERE TeilnehmerID='"+tln.Nummer+"' ";
            SQLiteCommand command = new SQLiteCommand(updateTeilnehmer, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //update entry in Volleyballspieler table
            string updateVolleyball = "UPDATE Volleyballspieler SET VolleyballspielerID='" + tln.Rolle + "' Trikotnummer='" + volley.Trikotnummer + "' Position= '" + volley.Position + "' " +
                "Sprunghoehe='" + volley.Sprunghoehe + "'  WHERE TeilnehmerID='" + tln.Nummer + "' ";
            command = new SQLiteCommand(updateVolleyball, Connection);

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
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierverwaltungWeb/TurnierDatenbank/turnier.db";
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
            string delete = "DELETE FROM Teilnehmer WHERE TeilnehmerID='"+ tln.Nummer+ "' ";
            SQLiteCommand command = new SQLiteCommand(delete, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //delete one entry from Volleyballspieler
            delete = "DELETE FROM Volleyballspieler WHERE VolleyballspielerID='" + tln.Nummer + "' ";
            command = new SQLiteCommand(delete, Connection);

            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //close connection
            Connection.Close();
        }
        #endregion
    }
}