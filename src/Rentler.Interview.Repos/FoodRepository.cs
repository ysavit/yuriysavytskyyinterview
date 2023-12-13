using Renter.Interview.Domain.Interfaces;
using Renter.Interview.Domain.Models;
using Rentler.Interview.Data;
using Rentler.Interview.Data.DataContext;
using Rentler.Interview.Data.Models;

namespace Rentler.Interview.Repos
{
    public class FoodRepository : IFoodRepository
    {
        public Task<Guid> CreateFood(CreateFoolModelRequest foodModel)
        {
            using(var context = new InterviewContext())
            {
                var id = Guid.NewGuid();
                var food = new Food
                {
                    Id = id,
                    Brand = foodModel.Brand,
                    Description = foodModel.Description,
                    ServiceSize = foodModel.ServiceSize,
                    Calories = foodModel.Calories,
                    Fat = foodModel.Fat,
                    CarboHydrates = foodModel.CarboHydrates,
                    Proteint = foodModel.Proteint
                };

                context.Foods.Add(food);
                context.SaveChanges();

                return Task.FromResult(id);
            }
        }

        public Task<bool> DeleteFood(Guid Id)
        {
            using (var context = new InterviewContext())
            {
                var food = context.Foods.FirstOrDefault(r=>r.Id == Id);
                if (food == null)
                    return Task.FromResult(false);

                context.Foods.Remove(food);
                context.SaveChanges();

                return Task.FromResult(true);
            }
        }
        public Task<List<FoodModel>> GetAll(int pageNo, int pageSize)
        {
            using (var context = new InterviewContext())
            {
                var foods = context.Foods.Take(pageSize)
                    .Skip(pageNo * pageSize)
                    .Select(r => new FoodModel { Brand = r.Brand, 
                        Calories = r.Calories, CarboHydrates = r.CarboHydrates,
                        Fat = r.Fat, 
                        Proteint = r.Proteint, Id = r.Id, 
                        ServiceSize = r.ServiceSize }).ToList();               
                return Task.FromResult(foods);
            }
        }

        public Task<List<FoodModel>> Search(Func<FoodModel, bool> predicate, int pageNo, int pageSize)
        {
            using (var context = new InterviewContext())
            {
                var foods = context.Foods.Take(pageSize)
                    .Skip(pageNo * pageSize)
                    .Select(r => new FoodModel
                    {
                        Brand = r.Brand,
                        Calories = r.Calories,
                        CarboHydrates = r.CarboHydrates,
                        Fat = r.Fat,
                        Proteint = r.Proteint,
                        Id = r.Id,
                        ServiceSize = r.ServiceSize, Description = r.Description,
                        DateCreated = r.DateCreated, DateUpdated = r.DateUpdated
                    }).Where(predicate).ToList();
                return Task.FromResult(foods);    
            }
        }

        public Task<bool> UpdateFood(CreateFoolModelRequest foodModel, Guid Id)
        {
            using (var context = new InterviewContext())
            {
                var food = context.Foods.FirstOrDefault(r => r.Id == Id);
                if (food == null)
                    return Task.FromResult(false);

                food.Brand = foodModel.Brand;
                food.Description = foodModel.Description;
                food.ServiceSize = foodModel.ServiceSize;
                food.Calories = foodModel.Calories;
                food.Fat = foodModel.Fat;
                food.CarboHydrates = foodModel.CarboHydrates;
                food.Proteint = foodModel.Proteint;       
                food.DateUpdated = DateTime.UtcNow;
                context.SaveChanges();
                return Task.FromResult(true);
            }
        }
    }
}