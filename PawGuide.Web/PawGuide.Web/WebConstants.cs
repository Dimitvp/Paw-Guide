namespace PawGuide.Web
{
    using System.Threading.Tasks;

    public class WebConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string ModeratorRole = "Moderator";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataWarningMessageKey = "WarningMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";
        public const string TempDataDangerMessageKey = "DangerMessage";


        public const string SuccessfullAdd = "Succesfully added {0}";
        public const string SuccessfullEdit = "Succesfully edited {0}";
        public const string SuccessfullDelete = "Delete was successfull";
        public const string SuccessfullAddRoleToUser = "Succesfully add role '{0}' to user '{1}";


        public const string AdminArea = "Admin";
        public const string PublicationsArea = "Publications";
        public const string BusinessArea = "Business";

        public const string JpgFormat = ".jpg";
        public const string PngFormat = ".png";
        public const string BusinessEntertainmentImagesPath = "wwwroot/img/businesses/Entertainment";
        public const string BusinessHotelImagesPath = "wwwroot/img/businesses/Hotel";
        public const string BusinessPrivateHouseImagesPath = "wwwroot/img/businesses/PrivateHouse";
        public const string BusinessCampingImagesPath = "wwwroot/img/businesses/Camping";
        public const string BusinessCabinImagesPath = "wwwroot/img/businesses/Cabin";
        public const string BusinessOtherTypeImagesPath = "wwwroot/img/businesses/OtherType";
        public const string BusinessImagesPath = "wwwroot/img/businesses";

        public const long ImageSize = 2 * 1024 * 1024;

    }
}
