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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSportart_okClick(object sender, EventArgs e)
        {
            // zeige Tabelle mit Turnierergebnissen je nach ausgewählter Sportart an
            string selectedItem = RadioButtonList1.SelectedValue;
            System.Diagnostics.Debug.WriteLine(selectedItem);
        }
    }
}