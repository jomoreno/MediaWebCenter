using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MediaWebCenter
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }

        protected void imb_Enter_Click(object sender, ImageClickEventArgs e)
        {
            string usrName = tbx_UserName.Text.Trim();
            string password = tbx_Password.Text.Trim();

            if (usrName.Equals("tekken") && (password.Equals("zouyiro")))
            {
                Session["LoginProcess"] = "Processed";
                Response.Redirect("Pages/Default.aspx");
            }
        }

    }
}