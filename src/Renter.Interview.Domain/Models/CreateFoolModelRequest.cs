using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renter.Interview.Domain.Models
{
    //TODO Rename it 
    public class CreateFoolModelRequest
    {
        public string Brand { get; set; } = null!;

        public string? Description { get; set; }

        public int ServiceSize { get; set; }

        public int Calories { get; set; }

        public int Fat { get; set; }

        public int CarboHydrates { get; set; }

        public int Proteint { get; set; }
    }
}
