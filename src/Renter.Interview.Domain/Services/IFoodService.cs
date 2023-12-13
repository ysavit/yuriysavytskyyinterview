using Renter.Interview.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renter.Interview.Domain.Services
{
    public interface IFoodService
    {
        Task<Guid> CreateFood(CreateFoolModelRequest foodModel);
        Task<bool> UpdateFood(CreateFoolModelRequest foodModel, Guid Id);
        Task<bool> DeleteFood(Guid Id);
        Task<List<FoodModel>> GetAll(int pageNo, int pageSize);
        Task<List<FoodModel>> Search(SearchModel searchData, int pageNo, int pageSize);
    }
}
