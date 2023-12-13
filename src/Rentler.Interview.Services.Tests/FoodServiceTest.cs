using System.Diagnostics.Metrics;
using Moq;
using Renter.Interview.Domain.Interfaces;
using Renter.Interview.Domain.Models;
using Xunit;
namespace Rentler.Interview.Services.Tests
{
    public class FoodServiceTest
    {
        [Fact]
        public async Task CreateFood_ThrowsArgumentNullException_WhenFoodModelIsNull()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var service = new FoodService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateFood(null));
        }

        [Fact]
        public async Task CreateFood_CallsRepository_WhenValidRequest()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var foodModel = new CreateFoolModelRequest { /* populate with data */ };
            var expectedId = Guid.NewGuid();

            mockRepository.Setup(r => r.CreateFood(foodModel)).ReturnsAsync(expectedId);
            var service = new FoodService(mockRepository.Object);

            var result = await service.CreateFood(foodModel);

            Assert.Equal(expectedId, result);
            mockRepository.Verify(r => r.CreateFood(foodModel), Times.Once);
        }

        [Fact]
        public async Task UpdateFood_ThrowsArgumentNullException_WhenFoodModelIsNull()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var service = new FoodService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateFood(null, Guid.NewGuid()));
        }

        [Fact]
        public async void UpdateFood_ThrowsArgumentNullException_WhenIdIsEmpty()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var service = new FoodService(mockRepository.Object);
            var foodModel = new CreateFoolModelRequest { /* populate with data */ };

           await Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateFood(foodModel, Guid.Empty));
        }

        [Fact]
        public async void DeleteFood_ThrowsArgumentNullException_WhenIdIsEmpty()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var service = new FoodService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteFood(Guid.Empty));
        }
        [Fact]
        public async void GetAll_ThrowsArgumentNullException_WhenPageNoOrPageSizeIsInvalid()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var service = new FoodService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.GetAll(-1, 10));
            await Assert.ThrowsAsync<ArgumentNullException>(() => service.GetAll(1, -1));
        }

        [Fact]
        public async void Search_ThrowsArgumentNullException_WhenSearchDataIsNull()
        {
            var mockRepository = new Mock<IFoodRepository>();
            var service = new FoodService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Search(null, 1, 10));
        }
    }
}