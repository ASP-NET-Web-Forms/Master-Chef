namespace MasterChef.Web.Controls
{
    using Common.Constants;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public partial class FileUpload : System.Web.UI.UserControl
    {
        private string[] defaulFormats = new string[3] { "image/jpeg", "image/jpg", "image/png" };

        public int MaxFileSize { get; set; }

        public string[] ImageFormats { get; set; }

        public string PathValue { get; set; }

        public bool IsRequired { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.ImageFormats == null)
            {
                this.ImageFormats = defaulFormats;
            }

            if (String.IsNullOrEmpty(this.PathValue))
            {
                this.PathValue = SiteConstants.DefaultImagePath;
            }

            if (this.MaxFileSize == 0)
            {
                this.MaxFileSize = SiteConstants.ImageMaxSize;
            }

            if (this.IsRequired)
            {
                this.RequiredFieldImage.Visible = true;
            }
        }

        public string Upload()
        {
            if (ImageUpload.HasFile)
            {
                if (defaulFormats.Any(ImageUpload.PostedFile.ContentType.Contains))
                {
                    if (ImageUpload.PostedFile.ContentLength < this.MaxFileSize)
                    {
                        var guidName = Guid.NewGuid();
                        var extension = Path.GetExtension(ImageUpload.FileName);

                        string fileName = string.Format("{0}.{1}", guidName, extension);

                        string path = Server.MapPath(this.PathValue);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        ImageUpload.SaveAs(path + fileName);

                        return this.PathValue + fileName;
                    }
                    else
                    {
                        var maxSizeInMB = (this.MaxFileSize / 1024) / 1024;
                        throw new InvalidOperationException(string.Format("Upload status: The file has to be less than {0} mb!", maxSizeInMB));
                    }
                }
                else
                {
                    StringBuilder allowedFormats = new StringBuilder();
                    foreach (var format in this.ImageFormats)
                    {
                        allowedFormats.AppendFormat("{0} ", format);
                    }

                    throw new InvalidOperationException(string.Format("Upload status: Only {0} files are accepted!", allowedFormats.ToString()));
                }
            }

            return string.Empty;
        }
    }
}