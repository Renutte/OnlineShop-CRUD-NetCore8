using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineShop.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<StoreProduct> StoreProducts { get; set; } = new List<StoreProduct>();
}
