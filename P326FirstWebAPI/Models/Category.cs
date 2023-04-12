namespace P326FirstWebAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
