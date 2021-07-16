using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Fussballspieler : Teilnehmer
    {
        #region Properties

        private int _trikotnummer;
        private string _position;
        private string _fuss;

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
        public string Fuss { get => _fuss; set => _fuss = value; }

        #endregion

        #region Constructor

        public Fussballspieler()
        {
            Position = " ";
            Trikotnummer = 0;
        }

        public Fussballspieler(int trikotnummer, string position, string fuss)
        {
            Trikotnummer = trikotnummer;
            Position = position;
            Fuss = fuss;
        }

        public Fussballspieler(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse, int trikotnummer, string position, string fuss) : base(name, vorname, rolle, nummer, geburtstag, groesse)
        {
            Trikotnummer = trikotnummer;
            Position = position;
            Fuss = fuss;
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

            string insertTeilnehmer = "insert into Teilnehmer(Rolle, Name, Vorname, Geburtstag, Groesse ) values('" + Rolle + "', '" + Name + "', '" + Vorname + "', '" + Geburtstag + "', '" + Groesse + "'); ";
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

            string insertSpieler = "insert into Fussballspieler (Trikotnummer, Position, Fuss, TeilnehmerID) values('" + Trikotnummer + "', '" + Position + "', '"+ Fuss +"', '" + lastID + "');";
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
            Fussballspieler fussball = (Fussballspieler)tln;
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

            //update entry in Fussballspieler table
            string updateFussball = "UPDATE Fussballspieler SET VolleyballspielerID='" + tln.Nummer + "' Trikotnummer='" + fussball.Trikotnummer + "' Position= '" + fussball.Position + "' " +
                "Fuss='" + fussball.Fuss + "'  WHERE TeilnehmerID='" + tln.Nummer + "' ";
            command = new SQLiteCommand(updateFussball, Connection);

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

            //delete one entry from Fussballspieler
            delete = "DELETE FROM Fussballspieler WHERE FussballspielerID='" + tln.Nummer + "' ";
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