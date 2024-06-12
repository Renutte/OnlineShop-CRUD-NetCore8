using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineShop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
}

