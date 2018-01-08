namespace PawGuide.Test.Web.Areas.Business
{
    using System.Linq;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using PawGuide.Web;
    using PawGuide.Web.Areas.Business.Controllers;
    using Xunit;

    public class BusinessControllerTest
    {
        [Fact]
        public void CoursesControllerShouldBeInAdminArea()
        {
            // Arrange
            var controller = typeof(BusinessesController);

            // Act
            var areaAttribute = controller
                    .GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.RouteValue.Should().Be(WebConstants.BusinessArea);
        }
    }
}
