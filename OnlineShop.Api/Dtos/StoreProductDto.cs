namespace OnlineShop.Api.Dtos
{
    public class StoreProductDto
    {
        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public int Stock { get; set; }
        public ProductDto? Product { get; set; }
        public StoreDto? Store { get; set; }
    }
}
