namespace PawGuide.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum TypeBusiness
    {
        [Display(Name = "Entertainment place")]
        PlaceForFoodAndDrinks = 0,
        Hotel = 1,
        [Display(Name = "Private House")]
        PrivateHouse = 2,
        Camping = 3,
        Cabin = 4,
        [Display(Name = "Other Type")]
        OtherType = 5
    }
}
