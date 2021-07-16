using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace TurnierverwaltungWeb.View
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter
        {
            get => _verwalter;
            set => _verwalter = value;
        }

        public Mannschaftsverwaltung() : base()
        {
            Verwalter = new Controller();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
            //Verwalter.TeilnehmerListe.Clear();
            ShowParticipants();

        }

        protected void ShowParticipants()
        {
            Verwalter.HoleAllePersonen();
            //selMannschaft.Items.Insert(0, "select program");
            int x = 0;
            foreach (Teilnehmer tln in Verwalter.TeilnehmerListe)
            {
                ListItem list = new ListItem(tln.Nummer + ", " + tln.Name + ", " + tln.Vorname + ", " + tln.Rolle, tln.Nummer.ToString());
                selMannschaft.Items.Insert(x, list);
                x++;
            }
        }

        protected void addSpieler_Click(object sender, EventArgs e)
        {
            var selected = Request.Form["selMannschaft"];
            System.Diagnostics.Debug.WriteLine(selected);
            Verwalter.SpielerID.Add(Convert.ToInt32(selected));
        }

        protected void addMannschaft_onClick(object sender, EventArgs e)
        {
            var selectedSport = Request.Form["selSport"];
            System.Diagnostics.Debug.WriteLine("request::", selectedSport);
            System.Diagnostics.Debug.WriteLine("name::", tbName.Text);
            Verwalter.MannschaftHinzufuegen(tbName.Text, selectedSport);
        }
    }
}