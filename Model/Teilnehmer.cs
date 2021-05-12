using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace TurnierverwaltungWeb
{
    public abstract class Teilnehmer
    {
        #region Properties
        private string _name;
        private string _vorname;
        private string _rolle;
        private int _nummer;
        private string _geburtstag;
        private int _groesse;
        #endregion

        #region Accessors/Modifiers
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Rolle
        {
            get => _rolle;
            set => _rolle = value;
        }
        public int Nummer { get => _nummer; set => _nummer = value; }
        public string Vorname { get => _vorname; set => _vorname = value; }
        public string Geburtstag { get => _geburtstag; set => _geburtstag = value; }
        public int Groesse { get => _groesse; set => _groesse = value; }
        #endregion
        #region Constructor

        public Teilnehmer()
        {
            Name = " ";
            Rolle = " ";
            Vorname = " ";
            Geburtstag = " ";
            Groesse = 0;
        }

        public Teilnehmer(string name, string vorname, string rolle, int nummer, string geburtstag, int groesse)
        {
            Name = name;
            Rolle = rolle;
            Nummer = nummer;
            Vorname = vorname;
            Geburtstag = geburtstag;
            Groesse = groesse;
        }
        #endregion
        #region Worker

        public void anmelden(){}

        public abstract void DatenSpeichern();
        public abstract void DatenBearbeiten(Teilnehmer teilnehmer);
        public abstract void DatenLöschen(Teilnehmer tln);
        #endregion

    }
}