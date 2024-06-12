using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class StoreProduct
{
    public int StoreId { get; set; }

    public int ProductId { get; set; }

    public int Stock { get; set; }

    public virtual Product? Product { get; set; } = null!;

    public virtual Store? Store { get; set; } = null!;
}
