using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnierverwaltungWeb.View
{
    public partial class Turnierergebnis : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter
        {
            get => _verwalter;
            set => _verwalter = value;
        }

        public Turnierergebnis() : base()
        {
            Verwalter = new Controller();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
            Verwalter.TurnierListe.Clear();
        }

        protected void bSportart_okClick(object sender, EventArgs e)
        {
            // zeige Tabelle mit Turnierergebnissen je nach ausgewählter Sportart an
            string selectedItem = RadioButtonList1.SelectedValue;
            System.Diagnostics.Debug.WriteLine(selectedItem);
            HoleTurnierergebnisse(selectedItem);
        }

        protected void HoleTurnierergebnisse(string sportart)
        {
            Verwalter.TurnierergebnisseHolen(sportart);
            TableHeaderRow tmp = (TableHeaderRow)this.Turnier.Rows[0];
            this.Turnier.Rows.Clear();
            this.Turnier.Rows.Add(tmp);

            //Zeige Turnierergebnisse einer bestimmten Sportart an
            foreach (Turnier turnier in Verwalter.TurnierListe)
            {
                TableRow neueZeile = new TableRow();
                TableCell neueSpalte = new TableCell();

                neueSpalte.Text = turnier.NameA.ToString();
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = turnier.NameB.ToString();
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = turnier.ErgebnisA.ToString();
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = turnier.ErgebnisB.ToString();
                neueZeile.Cells.Add(neueSpalte);

                this.Turnier.Rows.Add(neueZeile);
            }
        }
    }
}