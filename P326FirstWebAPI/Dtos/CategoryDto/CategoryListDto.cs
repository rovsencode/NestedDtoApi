using P326FirstWebAPI.Dtos.CategoryDto;

namespace P326FirstWebAPI.Dtos.CategoryDto
{
    public class CategoryListDto
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<CategoryListItemDto> Items { get; set; }
    }
}
