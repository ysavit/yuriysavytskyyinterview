using System;
using System.Collections.Generic;

namespace Rentler.Interview.Data.Models;

public partial class Food
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
