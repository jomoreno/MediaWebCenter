using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaWebCenter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                imageMovies.Src = "~/GetImage.aspx?type=1";
                imageTV.Src = "~/GetImage.aspx?type=2";
                imageGames.Src = "~/GetImage.aspx?type=4";
                imageAnime.Src = "~/GetImage.aspx?type=3";
            }
        }
    }
}