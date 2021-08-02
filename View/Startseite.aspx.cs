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
    public partial class Turnierverwaltung : Page
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
            
        }

        
    }
}