namespace P326FirstWebAPI.Dtos.ProductDtos
{
    public class ProductListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<ProductListItemDto> productListItemDtos { get; set; }
    }
}
