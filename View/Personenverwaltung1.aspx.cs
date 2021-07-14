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

        }
        protected void button1_Click(object sender, EventArgs e)
        {
            string selectedItem = RadioButtonList1.SelectedValue.ToLower();
            System.Diagnostics.Debug.WriteLine(selectedItem);

            volleyDiv.Visible = false;
            fussDiv.Visible = false;
            basketDiv.Visible = false;
            trainerDiv.Visible = false;

            switch (selectedItem)
            {
                case "volleyball":
                    volleyDiv.Visible = true;
                    break;
                case "fussball":
                    fussDiv.Visible = true;
                    break;
                case "basketball":
                    basketDiv.Visible = true;
                    break;
                case "trainer":
                    testdiv.Visible = false;
                    trainerDiv.Visible = true;
                    break;
                default:
                    Console.WriteLine("An error occurred");
                    break;
            }
        }

        protected void btnOKPerson(object sender, EventArgs e)
        {
            string selectedItem = RadioButtonList1.SelectedValue.ToLower();
            int groesse = Convert.ToInt32(tbGroesse.Text);

            switch (selectedItem)
            {
                case "volleyballspieler":
                    Verwalter.VolleyballspielerHinzufuegen(tbName.Text, tbVorname.Text, selectedItem, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), Convert.ToInt32(tbSprunghoehe.Text));
                    break;
                case "fussballspieler":
                    Verwalter.FussballspielerHinzufuegen(tbName.Text, tbVorname.Text, selectedItem, tbGeburtstag.Text, groesse, tbPosition.Text, Convert.ToInt32(tbTrikotnummer.Text), tbFuss.Text);
                    break;
                case "basketballspieler":
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