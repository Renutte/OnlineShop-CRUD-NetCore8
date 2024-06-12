using System;
using System.Collections.Generic;

namespace OnlineShop.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Location { get; set; } = null!;

    public string Name { get; set; } = null!;

}
