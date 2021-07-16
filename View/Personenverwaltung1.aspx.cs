using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnierverwaltungWeb.View
{
    public partial class Personenverwaltung1 : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter
        {
            get => _verwalter;
            set => _verwalter = value;
        }

        public Personenverwaltung1() : base()
        {
            Verwalter = new Controller();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
            Verwalter.TeilnehmerListe.Clear();
            LoadData();

        }

        protected void LoadData()
        {
            Verwalter.HoleAllePersonen();
            //Konfiguration der Website
            TableHeaderRow tmp = (TableHeaderRow)this.Person.Rows[0];
            this.Person.Rows.Clear();
            this.Person.Rows.Add(tmp);

            //Zeige alle Teilnehmer aus der Teilnehmertabelle an
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
        protected void button1_Click(object sender, EventArgs e)
        {
            // Zeige die richtigen TextInputs an je nach Rolle
            string selectedItem = RadioButtonList1.SelectedValue.ToLower();
            System.Diagnostics.Debug.WriteLine(selectedItem);

            volleyDiv.Visible = false;
            fussDiv.Visible = false;
            basketDiv.Visible = false;
            trainerDiv.Visible = false;
            testdiv.Visible = true;

            switch (selectedItem)
            {
                case "volleyball":
                    volleyDiv.Visible = true;
                    BPerson.Visible = true;
                    break;
                case "fussball":
                    fussDiv.Visible = true;
                    BPerson.Visible = true;
                    break;
                case "basketball":
                    basketDiv.Visible = true;
                    BPerson.Visible = true;
                    break;
                case "trainer":
                    testdiv.Visible = false;
                    trainerDiv.Visible = true;
                    BPerson.Visible = true;
                    break;
                default:
                    Console.WriteLine("An error occurred");
                    break;
            }
        }

        protected void btnOKPerson(object sender, EventArgs e)
        {
            //Speichere die eingegbenen Daten in die DB-Tabllen
            string selectedItem = RadioButtonList1.SelectedValue.ToLower();
            System.Diagnostics.Debug.WriteLine("selected:" + selectedItem);
            int groesse = Convert.ToInt32(tbGroesse.Text);

            switch (selectedItem)
            {
                case "volleyball":
                    Verwalter.VolleyballspielerHinzufuegen(tbName.Text, tbVorname.Text, selectedItem, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), Convert.ToInt32(tbSprunghoehe.Text));
                    break;
                case "fussball":
                    Verwalter.FussballspielerHinzufuegen(tbName.Text, tbVorname.Text, selectedItem, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), tbFuss.Text);
                    break;
                case "basketball":
                    Verwalter.BasketballspielerHinzufuegen(tbName.Text, tbVorname.Text, selectedItem, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), Convert.ToInt32(tbAnzeahlKoerbe.Text));
                    break;
                case "trainer":
                    Verwalter.TrainerHinzufuegen(tbName.Text, tbVorname.Text, selectedItem, tbGeburtstag.Text, groesse, tbSportart.Text, int.Parse(tbJahreErfahrung.Text));
                    break;
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}