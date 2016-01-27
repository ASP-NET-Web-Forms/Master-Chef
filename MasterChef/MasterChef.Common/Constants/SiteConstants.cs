namespace MasterChef.Common.Constants
{
    public class SiteConstants
    {
        public const string DefaultAvatar = "/Uploaded_Files/default.jpg";
        //5 megabytes
        public const int ImageMaxSize = 5 * 1024 * 1024;
        public const string DefaultImagePath = "~/Uploaded_Files/";
        public const string PublicPathImages = "/Uploaded_Files/";
        public const string DateFormatForFileNameImages = "dd-MMM-yyyy-HH-mm-ss";

        public const string EmailRegex = "^([\\w\\.\\-_]+)?\\w+@[\\w-_]+(\\.\\w+){1,}$";
        public const string ErrorAccountLink = "Invalid Url";
        public const string WrongEmailAddress = "Email address is not valid";
        public const string ErrorFieldMinLength = "Field is too short";
        public const string ErrorFieldMaxLength = "Field is too long";
        public const string ErrorUploadMessageFormat = "Only images with size up to <strong>{0}Mb</strong> are allowed for uploading!";
    }
}
