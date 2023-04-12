namespace P326FirstWebAPI.Dtos.ProductDtos
{
    public class ProductListItemDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public CategoryInProductListItemDto Category { get; set; }
    }
    public class CategoryInProductListItemDto 
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int ProductCount { get; set; }


    }

}
