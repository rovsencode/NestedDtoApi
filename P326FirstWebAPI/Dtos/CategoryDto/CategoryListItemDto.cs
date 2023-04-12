namespace P326FirstWebAPI.Dtos.CategoryDto
{
    public class CategoryListItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
