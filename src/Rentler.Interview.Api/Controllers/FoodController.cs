using Microsoft.AspNetCore.Mvc;
using Renter.Interview.Domain.Models;
using Renter.Interview.Domain.Services;
using Rentler.Interview.Api.Domain;

namespace Rentler.Interview.Api.Controllers;

[ApiController]
[Route("api/food")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;
    private readonly ILogger<FoodController> _logger;

    public FoodController(ILogger<FoodController> logger, IFoodService foodService)
    {
        _logger = logger;
        _foodService = foodService;
    }

    [HttpGet, Route("{pageNo}/{pageSize}")]
    public async Task<ActionResult<List<Food>>> Get(int pageNo, int pageSize)
    {
        try
        {
            var foods = await _foodService.GetAll(pageNo, pageSize);
            return Ok(foods.Select(ConvertToFood).ToList());
        }catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting all food");
            return BadRequest();
        }
    }

    [HttpPost, Route("search/{pageNo}/{pageSize}")]
    public async Task<ActionResult<List<Food>>> Search(SearchModel searchData, int pageNo, int pageSize)
    {
        try
        {
            var foods = await _foodService.Search(searchData, pageNo, pageSize);
            return Ok(foods.Select(ConvertToFood).ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while searching food");
            return BadRequest();
        }
    }

    [HttpPut, Route("create")]
    public async Task<ActionResult<Guid>> Add(CreateFoolModelRequest searchData)
    {
        try
        {
            return Ok(await _foodService.CreateFood(searchData));
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Error while creating food");
            return BadRequest();
        }
       
    }

    [HttpPost, Route("update/{Id}")]
    public async Task<ActionResult<bool>> Update(CreateFoolModelRequest searchData, Guid Id)
    {
        try
        {
            return Ok(await _foodService.UpdateFood(searchData, Id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while updating food");
            return BadRequest();
        }
    }

    [HttpPost, Route("delete/{Id}")]
    public async Task<ActionResult<bool>> Delete( Guid Id)
    {
        try
        {
            return Ok(await _foodService.DeleteFood(Id));
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Error while deleting food");
            return BadRequest();
        }
    }

    private Food ConvertToFood(FoodModel foodModel)
    {
        return new Food
        {
            Brand = foodModel.Brand,
            Calories = foodModel.Calories,
            Carbohydrates = foodModel.CarboHydrates,
            Fat = foodModel.Fat,
            Protein = foodModel.Proteint,
            ServingSize = foodModel.ServiceSize,
            Description = foodModel.Description
        };
    }
}
