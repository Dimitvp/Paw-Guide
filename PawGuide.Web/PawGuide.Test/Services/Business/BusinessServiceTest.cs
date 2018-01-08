namespace PawGuide.Test.Services.Business
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using PawGuide.Data;
    using Data.Models;
    using PawGuide.Services.Businesses.Implementations;
    using PawGuide.Test.Mocks;
    using Xunit;

    public class BusinessServiceTest
    {
        private PawGuideDbContext db;

        private const string FirstUserId = "1";
        private const string FirstUserUsername = "First";
        private const string SecondUserId = "2";
        private const string SecondUserUsername = "Second";

        public BusinessServiceTest()
        {
            Tests.Initialize();
            this.db = Tests.GetDatabase();
        }

        [Fact]
        public void TotalShouldReturnCorrectCount()
        {
            // Arrange
            var firstBusinessy = new Business { Id = 1, Name = "First" };
            var secondBusiness = new Business { Id = 2, Name = "Second" };
            var thirdBusiness= new Business { Id = 3, Name = "Third" };
            var userManager = this.GetUserManagerMock();

            this.db.AddRange(firstBusinessy, secondBusiness, thirdBusiness);
            this.db.SaveChanges();

            var businessService = new BusinessService(this.db, userManager.Object);

            // Act
            var result = businessService.TotalAsync();

            // Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public void CreateShouldReturnCorrectId()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();
            var businessService = new BusinessService(this.db, userManager.Object);
            var type = new List<PetType>()
            {
                PetType.AllDogs,
                PetType.Cat
            };

            // Act
            var result = businessService.CreateAsync("test", TypeBusiness.Cabin, "test", "test", 2d, 2d, type, "test", "test", true, "test", "test");

            // Assert
            result
                .Should()
                .Equals(1);
        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectResultWithFilterAndOrder()
        {
            // Arrange

            var userManager = this.GetUserManagerMock();

            var firstBusiness = new Business { Id = 1, City = "First", Type = TypeBusiness.Cabin, Address = "test", PetType = PetType.AllDogs};
            var secondBusiness = new Business { Id = 2, City = "Second", Type = TypeBusiness.Cabin, Address = "test", PetType = PetType.AllDogs };
            var thirdBusiness = new Business { Id = 3, City = "Third", Type = TypeBusiness.Cabin, Address = "test", PetType = PetType.AllDogs };

            db.AddRange(firstBusiness, secondBusiness, thirdBusiness);

            await db.SaveChangesAsync();

            var businessService = new BusinessService(this.db, userManager.Object);

            // Act
            var result = await businessService.FindAsync("t");

            // Assert
            result
                .Should()
                .Match(r => r.ElementAt(0).Id == 3
                            && r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task EditShouldReturnTrueIfItIsSuccessfull()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();
            var business = new Business()
            {
                Id = 1,
                Name = "Test"
            };

            var type = new List<PetType>()
            {
                PetType.AllDogs,
                PetType.Cat
            };

            this.db.Businesses.Add(business);
            await db.SaveChangesAsync();

            var businesService = new BusinessService(this.db, userManager.Object);

            // Act
            var result = await businesService.EditAsync(1, "test", TypeBusiness.Cabin, "test", "test", 2d, 2d, type, "test", "test", true, "test", "test");

            // Assert
            result
                .Should()
                .BeTrue();
        }

        private Mock<UserManager<User>> GetUserManagerMock()
        {
            var userManager = UserManagerMock.New;
            userManager
                .Setup(u => u.GetUsersInRoleAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<User>
                {
                    new User { Id = FirstUserId, UserName = FirstUserUsername },
                    new User { Id = SecondUserId, UserName = SecondUserUsername }
                });

            return userManager;
        }
    }
}
