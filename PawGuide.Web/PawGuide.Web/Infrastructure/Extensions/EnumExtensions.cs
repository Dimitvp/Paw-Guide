namespace PawGuide.Web.Infrastructure.Extensions
{
    using Data.Models;

    public static class EnumExtensions
    {
        public static string ToDisplayName(this PetType petType)
        {
            if (petType == PetType.SmallBreedDog)
            {
                return "Small Dogs Breeds";
            }

            if (petType == PetType.AllDogs)
            {
                return "All Kinds of Dogs";
            }

            if (petType == PetType.OtherType)
            {
                return "Other Types of Pets";
            }

            return petType.ToString();
        }
    }
}
