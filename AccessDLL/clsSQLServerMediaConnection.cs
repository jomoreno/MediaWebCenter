using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AccessDLL
{
    public class clsSQLServerMediaConnection
    {
        private string connectionString = String.Empty;
        private string Server = String.Empty;
        private string Username = String.Empty;
        private string Password = String.Empty;
        private string Database = String.Empty;
        private SqlConnection connection = null;

        public clsSQLServerMediaConnection()
        {
            Server = ConfigurationManager.AppSettings.Get("SQL_Server");
            Username = ConfigurationManager.AppSettings.Get("SQL_User");
            Password = ConfigurationManager.AppSettings.Get("SQL_Password");
            Database = ConfigurationManager.AppSettings.Get("SQL_Database");
        }

        public clsSQLServerMediaConnection(string myServer, string myUsername, string myPassword, string myDatabase)
        {
            Server = myServer;
            Username = myUsername;
            Password = myPassword;
            Database = myDatabase;
        }

        public bool connect()
        {
            try
            {

                string ConnString = String.Format("Data Source ={0};initial Catalog = {1};user Id={2}; Password = {3}",
                this.Server, this.Database, this.Username, this.Password);

                if (connection != null)
                {
                    connection.Close();
                }

                connection = new SqlConnection(ConnString);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public bool disconnect()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public Media getMediaByName(MediaType.MediaTypes type, string name)
        {
            Media media = new Media();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT NAME,TYPE,YEAR,DESCRIPTION FROM " + getMediaTypeTable(type) + " WHERE Name ='" + name.Replace("'", "''") + "' ORDER BY NAME", connection);
                    dataAdapter.Fill(selectedData);
                    media = createMedia(selectedData,false);
                    disconnect();
                    return media;
                }
                else return media;
            }
            catch (SqlException ex)
            {
                return new Media();
            }
        }

        private Media createMedia(DataSet data, bool includeImage)
        {
            DataTable table = data.Tables[0];
            Media media = new Media();

            media.setName(table.Rows[0]["NAME"].ToString());
            media.setType(table.Rows[0]["TYPE"] != DBNull.Value ? table.Rows[0]["TYPE"].ToString() : "");
            media.setYear(Convert.ToInt32(table.Rows[0]["YEAR"] != DBNull.Value ? Convert.ToString(table.Rows[0]["YEAR"]) : "0"));
            media.setDescription(table.Rows[0]["DESCRIPTION"] != DBNull.Value ? table.Rows[0]["DESCRIPTION"].ToString() : "");
            if (includeImage)
            {
                media.setImage((table.Rows[0]["IMAGE1"] == DBNull.Value) ? new byte[] { } : (byte[])table.Rows[0]["IMAGE1"], 1);
            }
            return media;
        }

        public List<string> getMediaNameList(MediaType.MediaTypes type)
        {
            List<string> mediaList = new List<string>();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT NAME FROM " + getMediaTypeTable(type), connection);
                    dataAdapter.Fill(selectedData);
                    mediaList = createMediaList(selectedData);
                    disconnect();
                    return mediaList;
                }
                else return mediaList;
            }
            catch (SqlException ex)
            {
                return new List<string>();
            }
        }

        public List<string> getMediaListByLetter(MediaType.MediaTypes type, string letter)
        {
            List<string> mediaList = new List<string>();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT NAME FROM " + getMediaTypeTable(type) + " WHERE NAME like %'" + letter + "' ORDER BY NAME", connection);
                    dataAdapter.Fill(selectedData);
                    mediaList = createMediaList(selectedData);
                    disconnect();
                    return mediaList;
                }
                else return mediaList;
            }
            catch (SqlException ex)
            {
                return new List<string>();
            }
        }

        public List<Media> getPresentationMediaListByLetter(MediaType.MediaTypes type, string letter)
        {
            List<Media> mediaList = new List<Media>();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    string queryString = "select NAME,TYPE,YEAR,DESCRIPTION from " + getMediaTypeTable(type) + " where NAME like '[0-9]%' OR NAME NOT like '[a-Z]%' ORDER BY NAME";
                    if (letter != "#")
                    {
                        queryString = "SELECT NAME,TYPE,YEAR,DESCRIPTION FROM " + getMediaTypeTable(type) + " WHERE NAME like '" + letter + "%' ORDER BY NAME";
                    }

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, connection);
                    dataAdapter.Fill(selectedData);
                    mediaList = createPresentationMediaList(selectedData);
                    disconnect();
                    return mediaList;
                }
                else return mediaList;
            }
            catch (SqlException ex)
            {
                return new List<Media>();
            }
        }

        public List<Media> getPresentationMediaListByValue(MediaType.MediaTypes type, string value)
        {
            List<Media> mediaList = new List<Media>();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    string queryString = "select NAME,TYPE,YEAR,DESCRIPTION from " + getMediaTypeTable(type) + " where NAME like '%"+ value.Replace("'", "''") + "%' ORDER BY NAME";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, connection);
                    dataAdapter.Fill(selectedData);
                    mediaList = createPresentationMediaList(selectedData);
                    disconnect();
                    return mediaList;
                }
                else return mediaList;
            }
            catch (SqlException ex)
            {
                return new List<Media>();
            }
        }


        public List<string> getMediaListByValue(MediaType.MediaTypes type, string value)
        {
            List<string> mediaList = new List<string>();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT NAME FROM " + getMediaTypeTable(type) + " WHERE NAME like '%" + value.Replace("'", "''") + "%' ORDER BY NAME", connection);
                    dataAdapter.Fill(selectedData);
                    mediaList = createMediaList(selectedData);
                    disconnect();
                    return mediaList;
                }
                else return mediaList;
            }
            catch (SqlException ex)
            {
                return new List<string>();
            }
        }

        public List<string> createMediaList(DataSet data)
        {
            DataTable table = data.Tables[0];
            List<string> list = new List<string>();
            foreach (DataRow dr in table.Rows)
            {
                list.Add(dr["NAME"].ToString());
            }
            return list;
        }

        public List<Media> createPresentationMediaList(DataSet data)
        {
            DataTable table = data.Tables[0];
            List<Media> list = new List<Media>();
            foreach (DataRow dr in table.Rows)
            {
                Media media = new Media();
                media.setName(dr["NAME"].ToString());
                media.setType(dr["TYPE"] != DBNull.Value ? dr["TYPE"].ToString() : "");
                media.setYear(Convert.ToInt32(dr["YEAR"] != DBNull.Value ? Convert.ToString(dr["YEAR"]) : "0"));
                media.setDescription(dr["DESCRIPTION"] != DBNull.Value ? dr["DESCRIPTION"].ToString() : "");
                list.Add(media);
            }
            return list;
        }

        private string getMediaTypeTable(MediaType.MediaTypes type)
        {
            switch (type)
            {
                case MediaType.MediaTypes.MOVIES:
                    {
                        return ConfigurationManager.AppSettings.Get("MovieTable");
                    }
                case MediaType.MediaTypes.TVSERIES:
                    {
                        return ConfigurationManager.AppSettings.Get("TVSeriesTable");
                    }
                case MediaType.MediaTypes.ANIMESERIES:
                    {
                        return ConfigurationManager.AppSettings.Get("AnimeTable");
                    }
                case MediaType.MediaTypes.GAMES:
                    {
                        return ConfigurationManager.AppSettings.Get("GamesTable");
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }

        public byte[] getImageData(MediaType.MediaTypes type, int image, string name)
        {
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT IMAGE" + image + " FROM " + getMediaTypeTable(type) + " WHERE Name ='" + name.Replace("'", "''") + "' ORDER BY NAME", connection);
                    dataAdapter.Fill(selectedData);
                    if (selectedData.Tables.Count > 0 && selectedData.Tables[0].Rows.Count > 0)
                    {
                        byte[] data = (selectedData.Tables[0].Rows[0]["IMAGE" + image] == DBNull.Value) ? null : (byte[])selectedData.Tables[0].Rows[0]["IMAGE" + image];
                        disconnect();
                        return data;
                    }
                    else {
                        return new byte[] { };
                    }
                }
                return new byte[] { };
            }
            catch (SqlException ex)
            {
                return new byte[] { };
            }
        }

        public Object[] getVideoData(MediaType.MediaTypes type, string name)
        {
            Object[] videoInformation = new Object[2];
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT VIDEO,VIDEOEXTENTION FROM " + getMediaTypeTable(type) + " WHERE Name ='" + name.Replace("'", "''") + "' ORDER BY NAME", connection);
                    dataAdapter.Fill(selectedData);
                    byte[] data = (selectedData.Tables[0].Rows[0]["VIDEO"] == DBNull.Value) ? null : (byte[])selectedData.Tables[0].Rows[0]["VIDEO"];
                    string extention = (selectedData.Tables[0].Rows[0]["VIDEOEXTENTION"] == DBNull.Value) ? String.Empty : selectedData.Tables[0].Rows[0]["VIDEOEXTENTION"].ToString();
                    videoInformation[0] = data;
                    videoInformation[1] = extention;
                    disconnect();
                    return videoInformation;
                }
                else return new Object[] { };
            }
            catch (SqlException ex)
            {
                return new Object[] { };
            }
        }

        public Media getMediaPresentationList(MediaType.MediaTypes type, string name)
        {
            Media media = new Media();
            try
            {
                if (connect())
                {
                    DataSet selectedData = new DataSet();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT NAME,TYPE,YEAR,DESCRIPTION,IMAGE1 FROM " + getMediaTypeTable(type) + " ORDER BY NAME", connection);
                    dataAdapter.Fill(selectedData);
                    media = createMedia(selectedData,true);
                    disconnect();
                    return media;
                }
                else return new Media();
            }
            catch (SqlException ex)
            {
                return new Media();
            }
        }

        public byte[] getPresentationImage(MediaType.MediaTypes type)
        {
            int mediaType = (type == MediaType.MediaTypes.MOVIES) ? 1 : (type == MediaType.MediaTypes.TVSERIES ? 2 : (type == MediaType.MediaTypes.ANIMESERIES ? 3 : 4));

            try
            {
                if (connect())
                {
                    SqlCommand command = new SqlCommand("getPresentationImage", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameter = new SqlParameter("MEDIATYPE", mediaType);
                    command.Parameters.Add(parameter);
                    SqlDataReader reader = command.ExecuteReader();
                    byte[] imageData = null;
                    if (reader.Read())
                    {
                        imageData = (byte[])reader["IMAGE1"];
                    }
                    reader.Close();
                    disconnect();
                    return imageData;
                }
                else return null;
            }
            catch (SqlException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] getImageByName(MediaType.MediaTypes type,string name)
        {
            return getImageData(type, 1, name);
        }


    }
}
