using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// backend Datei
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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
            Verwalter.Teilnehmer.Clear();
            LoadData();
        }

        private void LoadData()
        {
            Verwalter.HoleAllePersonen();
            //Konfiguration der Website
            TableHeaderRow tmp = (TableHeaderRow)this.Person.Rows[0];
            this.Person.Rows.Clear();
            this.Person.Rows.Add(tmp);

            foreach (Teilnehmer tln in Verwalter.Teilnehmer)
            {
                TableRow neueZeile = new TableRow();
                TableCell neueSpalte = new TableCell();

                neueSpalte.Text = tln.Nummer.ToString();
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = tln.Rolle;
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = tln.Name;
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = tln.Vorname;
                neueZeile.Cells.Add(neueSpalte);


                neueSpalte = new TableCell();
                neueSpalte.Text = tln.Geburtstag;
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = Convert.ToString(tln.Groesse);
                neueZeile.Cells.Add(neueSpalte);

                this.Person.Rows.Add(neueZeile);            
            }

        }
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Verwalter.PersonHinzufuegen(tbName.Text, tbVorname.Text);
            Response.Redirect(Request.RawUrl);
        }
    }
}