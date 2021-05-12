using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public class Controller
    {
        private List<Teilnehmer> _teilnehmer;

        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }


        public Controller()
        {
            Teilnehmer = new List<Teilnehmer>();
        }

        public void HoleAllePersonen()
        {
            string DatabasePath = "D:/Users/NatalieHasselmann/Documents/2.Lehrjahr/AWE/TurnierDatenbank/turnier.db";
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
                    int trikotnummer = reader.GetInt32(7);
                    string position = reader.GetValue(8).ToString();
                    int sprunghoehe = reader.GetInt32(9);

                    Teilnehmer volleyballspieler = new Volleyballspieler(name, vorname, rolle, id, geburtstag, groesse, trikotnummer, position, sprunghoehe);
                    Teilnehmer.Add(volleyballspieler);
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
                    Teilnehmer.Add(fussballspieler);
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
                    Teilnehmer.Add(basketballspieler);
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
                    int id = reader.GetInt32(0);
                    string rolle = reader.GetValue(1).ToString();
                    string name = reader.GetValue(2).ToString();
                    string vorname = reader.GetValue(3).ToString();
                    string geburtstag = reader.GetValue(4).ToString();
                    int groesse = reader.GetInt32(5);
                    string sportart = reader.GetValue(7).ToString();
                    int jahreErfahrung = reader.GetInt32(8);

                    Teilnehmer trainer = new Trainer(name, vorname, rolle, id, geburtstag, groesse, sportart, jahreErfahrung);
                    Teilnehmer.Add(trainer);
                }
            }
            else
            {
                Console.WriteLine("Error, cannot find any data for Trainer");
            }
            //close connection
            Connection.Close();

        }

        public void PersonHinzufuegen(string name, string vorname)
        {
            //Teilnehmer tln = new Volleyballspieler(name, vorname, "Volleyballspieler", 1, 4, "Libero");
            //tln.DatenSpeichern();
            //this.Teilnehmer.Add(tln);
        }

        #region Worker

        #endregion
    }
}