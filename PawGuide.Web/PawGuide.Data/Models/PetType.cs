namespace PawGuide.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum PetType
    {
        [Display(Name = "Small Breed Dog")]
        SmallBreedDog = 0,
        [Display(Name = "All Dogs")]
        AllDogs =1,
        [Display(Name = "Cats")]
        Cat = 2,
        [Display(Name = "Other Type")]
        OtherType = 3
    }
}
