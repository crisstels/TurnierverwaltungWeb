using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurnierverwaltungWeb.View
{
    public partial class Rangliste : System.Web.UI.Page
    {
        private Controller _verwalter;

        public Controller Verwalter
        {
            get => _verwalter;
            set => _verwalter = value;
        }

        public Rangliste() : base()
        {
            Verwalter = new Controller();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = Global.Verwalter;
            Verwalter.Rangliste.Clear();
        }
        protected void bSportart_okClick(object sender, EventArgs e)
        {
            // sportart auswählen und dazugehörige Rangliste anzeigen
            string selectedItem = RadioButtonList1.SelectedValue;
            System.Diagnostics.Debug.WriteLine(selectedItem);
            HoleRangliste(selectedItem.ToLower());
        }

        protected void HoleRangliste(string sportart)
        {
            Verwalter.RanglisteAbrufen(sportart);
            TableHeaderRow tmp = (TableHeaderRow)this.Rang.Rows[0];
            this.Rang.Rows.Clear();
            this.Rang.Rows.Add(tmp);

            //Zeige Rangliste einer bestimmten Sportart an
            foreach (Rang rang in Verwalter.Rangliste)
            {
                TableRow neueZeile = new TableRow();
                TableCell neueSpalte = new TableCell();

                neueSpalte.Text = rang.Name.ToString();
                neueZeile.Cells.Add(neueSpalte);

                neueSpalte = new TableCell();
                neueSpalte.Text = rang.Punkte.ToString();
                neueZeile.Cells.Add(neueSpalte);

                this.Rang.Rows.Add(neueZeile);
            }
        }
    }
}