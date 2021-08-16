using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnierverwaltungWeb.View
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter
        {
            get => _verwalter;
            set => _verwalter = value;
        }

        public Turnierverwaltung() : base()
        {
            Verwalter = new Controller();
        }
        public void addTeam_Click(object sender, EventArgs e)
        {
            var selectedA = Request.Form["selMannschaftA"];
            var selectedB = Request.Form["selMannschaftB"];
            System.Diagnostics.Debug.WriteLine(selectedA);
            Verwalter.TurnierHinzufuegen(selectedA, selectedB, tbSportart.Text, Convert.ToInt32(tbErgebnisA.Text), Convert.ToInt32(tbErgebnisB.Text));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
            showParticipants();
        }

        public void showParticipants()
        {
            Verwalter.MannschaftHolen();
            int x = 0;
            if(Verwalter.TeamListe == null)
            {
                ListItem list = new ListItem("noch kein Teilnehmer vorhanden");
                selMannschaftA.Items.Insert(x, list);
                selMannschaftB.Items.Insert(x, list);
            }
            else
            {
                foreach (Mannschaft team in Verwalter.TeamListe)
                {
                    ListItem list = new ListItem(team.Name);
                    selMannschaftA.Items.Insert(x, list);
                    selMannschaftB.Items.Insert(x, list);
                    x++;
                }
            }
        }
    }
}