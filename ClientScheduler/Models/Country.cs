using System;
using System.Collections.Generic;

namespace ClientScheduler.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public string LastUpdateBy { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
