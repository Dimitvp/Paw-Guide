namespace PawGuide.Web.Infrastructure.Extensions
{
    using Data.Models;

    public static class EnumExtensions
    {
        public static string ToDisplayName(this PetType petType)
        {
            if (petType == PetType.SmallBreedDog)
            {
                return "Small BreedDog";
            }

            return petType.ToString();
        }
    }
}
