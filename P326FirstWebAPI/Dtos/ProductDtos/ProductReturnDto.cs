namespace P326FirstWebAPI.Dtos.ProductDtos
{
    public class ProductReturnDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public bool IsActive { get; set; }
        public CategoryInProductReturnDto Category { get; set; }

    }
    public class CategoryInProductReturnDto 
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }


}
