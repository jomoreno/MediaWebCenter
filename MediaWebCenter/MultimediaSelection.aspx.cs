using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services;
using Entities;
using AccessDLL;

namespace MediaWebCenter
{
    public partial class MultimediaSelection : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                clsSQLServerMediaConnection getData = new clsSQLServerMediaConnection();
                List<Media> mediaList = getData.getPresentationMediaListByLetter(MediaType.MediaTypes.MOVIES, "A");
                int counter = 0;
                foreach (Media media in mediaList)
                {
                    counter++;
                    //media.ImageURL = "~/ImageHandlerRequest.ashx?op=GetPicRan&type=1" + "&randomKey=" + DateTime.Now.Ticks.ToString() + counter;
                    media.ImageURL = "~/ImageHandlerRequest.ashx?op=GetPicByName&type=1&name=" + Server.UrlEncode(media.Name);
                }
                lbl_ContentTitle.Text = "Showing " + mediaSelection.SelectedValue + " - " + mediaList.Count + " results were found!"; 
                imageDataList.DataSource = mediaList;
                imageDataList.DataBind();
            }
        }

        protected void filterSearch_Click(object sender, ImageClickEventArgs e)
        {
            searchLoadData();
        }

        protected void searchLoadData()
        {
            string media = mediaSelection.SelectedValue;
            string displayViewMode = displayMode.SelectedValue;
            string letter = ddlLetter.SelectedValue;
            string searchText = txt_SearchValue.Text;

            clsSQLServerMediaConnection getData = new clsSQLServerMediaConnection();

            MediaType.MediaTypes typeSelected = getMediaTypeValueSelected(media);
            int typeValueSelected = getMediaNumericValueSelected(media);

            List<Media> mediaList = new List<Media>();
            if (searchText == String.Empty)
            {
                // search by letter
                mediaList = getData.getPresentationMediaListByLetter(typeSelected, letter);
            }
            else
            {
                // search by value
                mediaList = getData.getPresentationMediaListByValue(typeSelected, searchText);
            }

            lbl_ContentTitle.Text = "Showing " + mediaSelection.SelectedValue + " - " + mediaList.Count + " results were found!";

            if (displayViewMode == "Image Grid")
            {
                if (mediaList.Count > 0)
                {
                    foreach (Media m in mediaList)
                    {
                        m.ImageURL = "~/ImageHandlerRequest.ashx?op=GetPicByName&type=" + typeValueSelected + "&name=" + Server.UrlEncode(m.Name);
                    }

                    imageDataList.DataSource = mediaList;
                    imageDataList.DataBind();
                }
                else
                {
                    // no elements found
                }
            }
            else
            {
                imageDataList.DataSource = null;
                imageDataList.DataBind();

                if (displayViewMode == "Details")
                {
                    if (mediaList.Count > 0)
                    {
                        foreach (Media m in mediaList)
                        {
                            m.ImageURL = "~/ImageHandlerRequest.ashx?op=GetPicByName&type=" + typeValueSelected + "&name=" + Server.UrlEncode(m.Name);
                        }
                        gridMediaList.DataSource = mediaList;
                        gridMediaList.DataBind();
                    }
                    else
                    {
                        // no elements
                    }
                }
            }
        }

        protected int getMediaNumericValueSelected(string media)
        {
            switch (media)
            {
                case "Movies": { return 1; }
                case "TV Series": { return 2; }
                case "Anime Series": { return 3; }
                case "Games": { return 4; }
                default: { return 5; }
            }
        }

        protected MediaType.MediaTypes getMediaTypeValueSelected(String media)
        {
            switch (media)
            {
                case "Movies": { return MediaType.MediaTypes.MOVIES; } 
                case "TV Series": { return MediaType.MediaTypes.TVSERIES; } 
                case "Anime Series": { return MediaType.MediaTypes.ANIMESERIES; }
                case "Games": { return  MediaType.MediaTypes.GAMES; } 
                default: { return MediaType.MediaTypes.MOVIES; } 
            }
        }

        [WebMethod]
        public static Media returnInformation(string name, string type)
        {
            clsSQLServerMediaConnection getData = new clsSQLServerMediaConnection();

            MediaType.MediaTypes typeM = MediaType.MediaTypes.MOVIES;
            switch (type)
            {
                case "Movies": { typeM = MediaType.MediaTypes.MOVIES; } break;
                case "TV Series": { typeM = MediaType.MediaTypes.TVSERIES; } break;
                case "Anime Series": { typeM = MediaType.MediaTypes.ANIMESERIES; } break;
                case "Games": { typeM = MediaType.MediaTypes.GAMES; } break;
                default : { typeM = MediaType.MediaTypes.MOVIES; } break;
            }

            Media mediaData = getData.getMediaByName(typeM,name);
            object[] videoData = getData.getVideoData(typeM, name);

            if (videoData != null && videoData.Length > 0 && videoData[0] != null)
            {
                try
                {
                    string fileName = name + "." + Convert.ToString(videoData[1]);
                    string fileNameCompletePath = HttpContext.Current.Server.MapPath("~/videos/" + fileName);
                    byte[] videoBytes = (byte[])videoData[0];
                    // Open file for reading
                    System.IO.FileStream _FileStream =
                       new System.IO.FileStream(fileNameCompletePath, System.IO.FileMode.Create,
                                                System.IO.FileAccess.Write);
                    // Writes a block of bytes to this stream using data from
                    // a byte array.
                    _FileStream.Write(videoBytes, 0, videoBytes.Length);

                    // close file stream
                    _FileStream.Close();
                    mediaData.VideoURL = "videos/" + fileName;

                }
                catch (Exception ex)
                {
                    mediaData.VideoURL = "";
                }
            }
            else {
                mediaData.VideoURL = "";
            }

            return mediaData;

            //Media m = new Media();
            //m.Name = "Movie Test 999";
            //m.Description = "Description 999";
            //m.Year = 2016;
            //m.Type = "Comedy";
            //m.VideoURL = "videos/TWICE - CHEER UP Dance video 3 HD.mp4";
            //return m;

            //return "{ 'name':'Movie Name','year':'2016','type':'Comedy','Description':'Lucys movie description', 'videoURL':'videos/TWICE - CHEER UP  M V.mp4'}";
        }

        protected void displayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchLoadData();
        }
    }
}