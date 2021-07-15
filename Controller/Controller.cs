using System;
using System.IO;
using TurnierverwaltungWeb.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Controller
    {
        private List<Teilnehmer> _teilnehmerListe;
        private List<int> _spielerID;
        private Mannschaft _team;

        public List<Teilnehmer> TeilnehmerListe { get => _teilnehmerListe; set => _teilnehmerListe = value; }
        public List<int> SpielerID { get => _spielerID; set => _spielerID = value; }
        public Mannschaft Team { get => _team; set => _team = value; }

        public Controller()
        {
            TeilnehmerListe = new List<Teilnehmer>();
            SpielerID = new List<int>();
            Team = new Mannschaft();
        }
        public void HoleAllePersonen()
        {
            var path = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierverwaltungWeb/TurnierDatenbank/turnier.db";

            string connectionString = "Data Source=" + path + ";Version=3;";

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
            // Select everything from Volleyball Database (Teilnehmer inner join Volleyballspieler)
            string selectQuery = "Select * From Volleyball;";
            SQLiteCommand command = new SQLiteCommand(selectQuery, Connection);

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
                    string rolle = reader.GetValue(1).ToString();
                    string name = reader.GetValue(2).ToString();
                    string vorname = reader.GetValue(3).ToString();
                    string geburtstag = reader.GetValue(4).ToString();
                    int groesse = reader.GetInt32(5);
                    int spielernummer = reader.GetInt32(6);
                    string trikotnummer = reader.GetValue(7).ToString();
                    string position = reader.GetValue(8).ToString();
                    int sprunghoehe = reader.GetInt32(9);

                    Teilnehmer volleyballspieler = new Volleyballspieler(name, vorname, rolle, id, geburtstag, groesse, Convert.ToInt32(trikotnummer), position, sprunghoehe);
                    TeilnehmerListe.Add(volleyballspieler);
                }
            }
            else
            {
                Console.WriteLine("Error, cannot find any data for Volleyballspieler");
            }

            //Select everything from Table Fussball

            selectQuery = "SELECT * FROM Fussball;";
            command = new SQLiteCommand(selectQuery, Connection);

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
                    System.Diagnostics.Debug.WriteLine("Fussball");
                    int id = reader.GetInt32(0);
                    string rolle = reader.GetValue(1).ToString();
                    string name = reader.GetValue(2).ToString();
                    string vorname = reader.GetValue(3).ToString();
                    string geburtstag = reader.GetValue(4).ToString();
                    int groesse = reader.GetInt32(5);
                    int trikotnummer = reader.GetInt32(7);
                    string position = reader.GetValue(8).ToString();
                    string fuss = reader.GetValue(9).ToString();

                    Teilnehmer fussballspieler = new Fussballspieler(name, vorname, rolle, id, geburtstag, groesse, trikotnummer, position, fuss);
                    TeilnehmerListe.Add(fussballspieler);
                }
            }
            else
            {
                Console.WriteLine("Error, cannot find any data for Fussballspieler");
            }

            // Select everything from Table Basketball

            selectQuery = "SELECT * FROM Basketball;";
            command = new SQLiteCommand(selectQuery, Connection);

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
                    System.Diagnostics.Debug.WriteLine("Basketball");
                    int id = reader.GetInt32(0);
                    string rolle = reader.GetValue(1).ToString();
                    string name = reader.GetValue(2).ToString();
                    string vorname = reader.GetValue(3).ToString();
                    string geburtstag = reader.GetValue(4).ToString();
                    int groesse = reader.GetInt32(5);
                    int trikotnummer = reader.GetInt32(7);
                    string position = reader.GetValue(8).ToString();
                    int koerbe = reader.GetInt32(9);

                    Teilnehmer basketballspieler = new Basketballspieler(name, vorname, rolle, id, geburtstag, groesse, trikotnummer, position, koerbe);
                    TeilnehmerListe.Add(basketballspieler);
                }
            }
            else
            {
                Console.WriteLine("Error, cannot find any data for Basketballspieler");
            }

            // Select everything from table Trainer

            selectQuery = "SELECT * FROM Trainers;";
            command = new SQLiteCommand(selectQuery, Connection);

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
                    System.Diagnostics.Debug.WriteLine("Trainer");
                    int id = reader.GetInt32(0);
                    string rolle = reader.GetValue(1).ToString();
                    string name = reader.GetValue(2).ToString();
                    string vorname = reader.GetValue(3).ToString();
                    string geburtstag = reader.GetValue(4).ToString();
                    int groesse = reader.GetInt32(5);
                    string sportart = reader.GetValue(7).ToString();
                    int jahreErfahrung = reader.GetInt32(8);

                    Teilnehmer trainer = new Trainer(name, vorname, rolle, id, geburtstag, groesse, sportart, jahreErfahrung);
                    TeilnehmerListe.Add(trainer);
                }
            }
            else
            {
                Console.WriteLine("Error, cannot find any data for Trainer");
            }
            //close connection
            Connection.Close();

        }

        public void VolleyballspielerHinzufuegen(string name, string vorname, string rolle, string geburtstag, int groesse, string position, int trikotnummer, int sprunghoehe)
        {
            Volleyballspieler tln = new Volleyballspieler(name, vorname, rolle, 0, geburtstag, groesse, trikotnummer, position, sprunghoehe);
            tln.DatenSpeichern();
        }

        public void FussballspielerHinzufuegen(string name, string vorname, string rolle, string geburtstag, int groesse, string position, int trikotnummer, string fuss)
        {
            Teilnehmer tln = new Fussballspieler(name, vorname, rolle, 0, geburtstag, groesse, trikotnummer, position, fuss);
            tln.DatenSpeichern();
        }

        public void BasketballspielerHinzufuegen(string name, string vorname, string rolle, string geburtstag, int groesse, string position, int trikotnummer, int anzahlkoerbe)
        {
            Teilnehmer tln = new Basketballspieler(name, vorname, rolle, 0, geburtstag, groesse, trikotnummer, position, anzahlkoerbe);
            tln.DatenSpeichern();
        }

        public void TrainerHinzufuegen(string name, string vorname, string rolle, string geburtstag, int groesse, string sportart, int jahreErfahrung)
        {
            Teilnehmer tln = new Trainer(name, vorname, rolle, 0, geburtstag, groesse, sportart, jahreErfahrung);
            tln.DatenSpeichern();
        }

        public void PersonLoeschen(int nummer)
        {
            //suche Teilnehmer anhand der Id und lösche diesen
            
            var tln = TeilnehmerListe.Find(e => e.Nummer == nummer);
            tln.DatenLöschen(tln); 
        }

        public void PersonBearbeiten(int nummer)
        {
            //suche Teilnehmer anhand der Id und bearbeite diesen
            var tln = TeilnehmerListe.Find(e => e.Nummer == nummer);
            tln.DatenBearbeiten(tln);
        }

        public void MannschaftHinzufuegen()
        {
            Team.MannschaftSpeichern(SpielerID);
        }

        #region Worker

        #endregion
    }
}