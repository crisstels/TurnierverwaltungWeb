using System;
using TurnierverwaltungWeb.Properties;
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
            Verwalter.TeilnehmerListe.Clear();
            LoadData();
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Test");
        }

        private void LoadData()
        {
            Verwalter.HoleAllePersonen();
            //Konfiguration der Website
            TableHeaderRow tmp = (TableHeaderRow)this.Person.Rows[0];
            this.Person.Rows.Clear();
            this.Person.Rows.Add(tmp);

            //´Zeige alle Teilnehmer aus der Teilnehmertabelle an
            foreach (Teilnehmer tln in Verwalter.TeilnehmerListe)
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
            string rolle = tbRolle.Text;
            System.Diagnostics.Debug.WriteLine(rolle);
            rolle = rolle.ToLower();
            int groesse = Convert.ToInt32(tbGroesse.Text);

            switch (rolle)
            {
                case "volleyballspieler":
                    Verwalter.VolleyballspielerHinzufuegen(tbName.Text,tbVorname.Text, tbRolle.Text, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), Convert.ToInt32(tbSprunghoehe.Text));
                    break;
                case "fussballspieler":
                    Verwalter.FussballspielerHinzufuegen(tbName.Text, tbVorname.Text, tbRolle.Text, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), tbFuss.Text);
                    break;
                case "basketballspieler":
                    Verwalter.BasketballspielerHinzufuegen(tbName.Text, tbVorname.Text, tbRolle.Text, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), Convert.ToInt32(tbAnzeahlKoerbe.Text));
                    break;
                case "trainer":
                    Verwalter.TrainerHinzufuegen(tbName.Text, tbVorname.Text, tbRolle.Text, tbGeburtstag.Text, groesse, tbSportart.Text, int.Parse(tbJahreErfahrung.Text));
                    break;
            }
 
            Response.Redirect(Request.RawUrl);
        }

        protected void RoleInputChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            text = text.ToLower();
            switch (text)
            {
                case "volleyballspieler":
                    tbTrikotnummer.Visible = true;
                    lbTrikotnummer.Visible = true;
                    lbPostion.Visible = true;
                    tbPosition.Visible = true;
                    lbSprunghoehe.Visible = true;
                    tbSprunghoehe.Visible = true;
                    break;
                case "fussballspieler":
                    tbTrikotnummer.Visible = true;
                    lbTrikotnummer.Visible = true;
                    lbPostion.Visible = true;
                    tbPosition.Visible = true;
                    lbFuss.Visible = true;
                    tbFuss.Visible = true;
                    break;
                case "basketballspieler":
                    tbTrikotnummer.Visible = true;
                    lbTrikotnummer.Visible = true;
                    lbPostion.Visible = true;
                    tbPosition.Visible = true;
                    lbAnzahlKoerbe.Visible = true;
                    tbAnzeahlKoerbe.Visible = true;
                    break;
                case "trainer":
                    lbJahreErfahrung.Visible = true;
                    tbJahreErfahrung.Visible = true;
                    lbSportart.Visible = true;
                    tbSportart.Visible = true;
                    break;
                default:
                    Console.WriteLine("An error occurred");
                    break;
            }
        }
    }
}