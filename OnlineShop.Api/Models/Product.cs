using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineShop.Models;

public partial class Product
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Size { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<StoreProduct> StoreProducts { get; set; } = new List<StoreProduct>();


}
