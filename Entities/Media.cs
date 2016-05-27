using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Media
    {
        private string name;
        private string type;
        private int year;
        private string description;

        private byte[] image1;
        private byte[] image2;
        private byte[] image3;

        private byte[] video;
        private string extention;

        private string videoURL;
        private string imageURL;

        private string toolTip;

        public Media()
        {

        }

        public Media(string name, string type, int year, string description)
        {
            this.name = name;
            this.type = type;
            this.year = year;
            this.description = description;
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string VideoURL
        {
            get
            {
                return videoURL;
            }
            set
            {
                videoURL = value;
            }
        }

        public string ImageURL
        {
            get
            {
                return imageURL;
            }
            set
            {
                imageURL = value;
            }
        }

        public string ToolTip
        {
            get
            {
                string tool = "Title : " + this.name + Environment.NewLine + "Type : " + (this.type == String.Empty ? "Not defined yet" : this.type) + Environment.NewLine + "Year : " + (this.year == 0 ? "Not defined yet" : this.year.ToString());
                return tool;
            }
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setType(string type)
        {
            this.type = type;
        }

        public void setYear(int year)
        {
            this.year = year;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setImage(byte[] imageData, int imageToSet)
        {
            switch (imageToSet)
            {
                case 1:
                    {
                        this.image1 = imageData;
                    }
                    break;
                case 2:
                    {
                        this.image2 = imageData;
                    }
                    break;
                case 3:
                    {
                        this.image3 = imageData;
                    }
                    break;
            }
        }

        public void setVideoData(byte[] videoData)
        {
            this.video = videoData;
        }

        public void setVideoExtention(string extention)
        {
            this.extention = extention;
        }

        public string getName()
        {
            return this.name;
        }

        public string getType()
        {
            return this.type;
        }

        public int getYear()
        {
            return this.year;
        }

        public string getDescription()
        {
            return this.description;
        }

        public Object[] getVideoData()
        {
            return new Object[] { this.video, this.extention };
        }

        public byte[] getImage(int image)
        {
            switch (image)
            {
                case 1:
                    {
                        return this.image1;
                    }
                case 2:
                    {
                        return this.image2;
                    }
                case 3:
                    {
                        return this.image3;
                    }
                default: { return null; }
            }
        }
    }
}
