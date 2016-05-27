using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;
using AccessDLL;
using Entities;


namespace MediaWebCenter
{
    public partial class GetImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"];
                if (id != String.Empty && id != null)
                {
                    DataSet data = (DataSet)Session["MediaData"];
                    DataTable dt = data.Tables[0];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["NAME"].ToString().Equals(id))
                        {
                            byte[] imgData = (byte[])dt.Rows[i]["IMAGE1"];
                            Response.BinaryWrite(imgData);
                        }
                    }
                }
                else
                {
                    string type = Request.QueryString["type"];
                    if (type != String.Empty && type != null)
                    {
                        clsSQLServerMediaConnection access = new clsSQLServerMediaConnection();
                        MediaType.MediaTypes typeValue = type == "1" ? MediaType.MediaTypes.MOVIES : type == "2" ? MediaType.MediaTypes.TVSERIES : type == "3" ? MediaType.MediaTypes.ANIMESERIES : MediaType.MediaTypes.GAMES;
                        byte[] img = access.getPresentationImage(typeValue);

                        Response.ContentType = "image/jpeg";
                        Response.BinaryWrite(img);
                    }
                }
            }
            catch (Exception ex) {

            }
        }
    }
}