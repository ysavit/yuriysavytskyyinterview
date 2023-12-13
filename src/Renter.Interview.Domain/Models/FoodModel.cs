using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renter.Interview.Domain.Models
{
    public class FoodModel
    {
        public Guid Id { get; set; }

        public string Brand { get; set; } = null!;

        public string? Description { get; set; }

        public int ServiceSize { get; set; }

        public int Calories { get; set; }

        public int Fat { get; set; }

        public int CarboHydrates { get; set; }

        public int Proteint { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }
    }
}
