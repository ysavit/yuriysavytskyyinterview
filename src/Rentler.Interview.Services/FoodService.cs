using Renter.Interview.Domain.Interfaces;
using Renter.Interview.Domain.Models;
using System.Diagnostics.Metrics;

namespace Rentler.Interview.Services
{
    public class FoodService: Renter.Interview.Domain.Services.IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public Task<Guid> CreateFood(CreateFoolModelRequest foodModel)
        {
            if(foodModel==null)
                throw new ArgumentNullException(nameof(foodModel));

               return _foodRepository.CreateFood(foodModel);
        }
        public Task<bool> UpdateFood(CreateFoolModelRequest foodModel, Guid Id)
        {
            if (foodModel == null)
                throw new ArgumentNullException(nameof(foodModel));

            if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));

            return _foodRepository.UpdateFood(foodModel, Id);
        }
        public Task<bool> DeleteFood(Guid Id)
        {
               if (Id == Guid.Empty)
                throw new ArgumentNullException(nameof(Id));

            return _foodRepository.DeleteFood(Id);
        }
        public Task<List<FoodModel>> GetAll(int pageNo, int pageSize)
        {
            if(pageNo<0)
                throw new ArgumentNullException(nameof(pageNo));
            if (pageSize < 0)
                throw new ArgumentNullException(nameof(pageSize));

            return _foodRepository.GetAll(pageNo, pageSize);
        }
        public Task<List<FoodModel>> Search(SearchModel searchData, int pageNo, int pageSize)
        {
            if (pageNo < 0)
                throw new ArgumentNullException(nameof(pageNo));
            if (pageSize < 0)
                throw new ArgumentNullException(nameof(pageSize));

            if (searchData == null)
                throw new ArgumentNullException(nameof(searchData));

            return _foodRepository.Search(r => r.Description == searchData.Description, pageNo, pageSize);

        }
    }
}