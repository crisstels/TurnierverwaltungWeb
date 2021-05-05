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

            foreach (Volleyballspieler tln in Verwalter.Teilnehmer)
            {
                TableRow neueZeile = new TableRow();
                TableCell neueZelle = new TableCell();
                neueZelle.Text = tln.Nummer.ToString();
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = tln.Rolle;
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = tln.Name;
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = tln.Vorname;
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = tln.Position;
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = Convert.ToString(tln.Spielernummer);
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = tln.Geburtstag;
                neueZeile.Cells.Add(neueZelle);

                neueZelle = new TableCell();
                neueZelle.Text = Convert.ToString(tln.Groesse);
                neueZeile.Cells.Add(neueZelle);

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