using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessDLL;
using Entities;
using System.Data;
using System.IO;

namespace MediaWebCenter
{
    /// <summary>
    /// Descripción breve de ImageHandlerRequest
    /// </summary>
    public class ImageHandlerRequest : System.Web.UI.Page, IHttpHandler 
    {
        override
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            context.Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-1));
            context.Response.Expires = 0;

            string operation = context.Request.QueryString["op"];
            if (operation != null && operation != String.Empty)
            {
                if (operation == "GetPicRan")
                {
                    string type = context.Request.QueryString["type"];
                    if (type != null && type != String.Empty)
                    {
                        clsSQLServerMediaConnection access = new clsSQLServerMediaConnection();
                        MediaType.MediaTypes typeValue = type == "1" ? MediaType.MediaTypes.MOVIES : type == "2" ? MediaType.MediaTypes.TVSERIES : type == "3" ? MediaType.MediaTypes.ANIMESERIES : MediaType.MediaTypes.GAMES;
                        byte[] img = access.getPresentationImage(typeValue);

                        context.Response.ContentType = "image/jpeg";
                        context.Response.BinaryWrite(img);
                    }
                }
                else
                {
                    if (operation == "GetPicByName")
                    {
                        string type = context.Request.QueryString["type"];
                        string name = context.Request.QueryString["name"];
                        if (type != null && type != String.Empty && name != null && name != String.Empty)
                        {
                            name = Server.UrlDecode(name);
                            clsSQLServerMediaConnection access = new clsSQLServerMediaConnection();
                            MediaType.MediaTypes typeValue = type == "1" ? MediaType.MediaTypes.MOVIES : type == "2" ? MediaType.MediaTypes.TVSERIES : type == "3" ? MediaType.MediaTypes.ANIMESERIES : MediaType.MediaTypes.GAMES;
                            byte[] img = access.getImageByName(typeValue, name);
                            if (img != null)
                            {
                                context.Response.ContentType = "image/jpeg";
                                context.Response.BinaryWrite(img);
                            }
                            else
                            {
                                string imageFileName = "image-not-available.jpg";
                                string path = HttpContext.Current.Server.MapPath("~/images/" + imageFileName);

                                try
                                {
                                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                                    BinaryReader br = new BinaryReader(fs);
                                    byte[] image = br.ReadBytes((int)fs.Length);
                                    br.Close();
                                    fs.Close();
                                    context.Response.ContentType = "image/jpeg";
                                    context.Response.BinaryWrite(image);
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}