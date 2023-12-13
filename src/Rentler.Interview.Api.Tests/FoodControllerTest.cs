using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Renter.Interview.Domain.Models;
using Renter.Interview.Domain.Services;
using Rentler.Interview.Api.Controllers;
using Rentler.Interview.Api.Domain;
using Xunit;

namespace Rentler.Interview.Api.Tests
{
    public class FoodControllerTest
    {
        [Fact]
        public async Task Get_ReturnsOkWithFoods_WhenCalledWithValidParams()
        {
            // Arrange
            var mockFoodService = new Mock<IFoodService>();
            var testFoods = new List<FoodModel> { /* populate with test data */ };
            mockFoodService.Setup(s => s.GetAll(1, 10)).ReturnsAsync(testFoods);

            var controller = new FoodController(Mock.Of<ILogger<FoodController>>(), mockFoodService.Object);

            // Act
            var result = await controller.Get(1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(testFoods.Select(f => new Food(/* map fields from FoodModel */)).ToList(), okResult.Value);
        }

        [Fact]
        public async Task Search_ReturnsOkWithFoods_WhenSearchIsSuccessful()
        {
            // Arrange
            var mockFoodService = new Mock<IFoodService>();
            var searchData = new SearchModel { /* populate search data */ };
            var testFoods = new List<FoodModel> { /* populate with test data */ };
            mockFoodService.Setup(s => s.Search(searchData, 1, 10)).ReturnsAsync(testFoods);

            var controller = new FoodController(Mock.Of<ILogger<FoodController>>(), mockFoodService.Object);

            // Act
            var result = await controller.Search(searchData, 1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(testFoods.Select(f => new Food(/* map fields from FoodModel */)).ToList(), okResult.Value);
        }

        [Fact]
        public async Task Add_ReturnsOkWithId_WhenFoodIsCreated()
        {
            // Arrange
            var mockFoodService = new Mock<IFoodService>();
            var newFoodRequest = new CreateFoolModelRequest { /* populate with test data */ };
            var newFoodId = Guid.NewGuid();
            mockFoodService.Setup(s => s.CreateFood(newFoodRequest)).ReturnsAsync(newFoodId);

            var controller = new FoodController(Mock.Of<ILogger<FoodController>>(), mockFoodService.Object);

            // Act
            var result = await controller.Add(newFoodRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(newFoodId, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenFoodIsUpdated()
        {
            // Arrange
            var mockFoodService = new Mock<IFoodService>();
            var updateRequest = new CreateFoolModelRequest { /* populate with test data */ };
            var foodId = Guid.NewGuid();
            mockFoodService.Setup(s => s.UpdateFood(updateRequest, foodId)).ReturnsAsync(true);

            var controller = new FoodController(Mock.Of<ILogger<FoodController>>(), mockFoodService.Object);

            // Act
            var result = await controller.Update(updateRequest, foodId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenFoodIsDeleted()
        {
            // Arrange
            var mockFoodService = new Mock<IFoodService>();
            var foodId = Guid.NewGuid();
            mockFoodService.Setup(s => s.DeleteFood(foodId)).ReturnsAsync(true);

            var controller = new FoodController(Mock.Of<ILogger<FoodController>>(), mockFoodService.Object);

            // Act
            var result = await controller.Delete(foodId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.True((bool)okResult.Value);
        }
    }
}