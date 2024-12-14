namespace BookSource.Models.ViewModel
{
    public class CategoryViewModel
    {
       public required int IdCategory { get; set; }
       public required string Category { get;set; }

        public static CategoryViewModel CategoryMapper(Category category)
        {
            return new CategoryViewModel
            {
                IdCategory = category.IdCategory,
                Category = category.CategoryName
            };
        }
        public static List<CategoryViewModel> ListCategoryMapper(List<Category> categoryList)
        {
            List<CategoryViewModel> viewList = new List<CategoryViewModel>();
            foreach (var category in categoryList)
                viewList.Add(CategoryMapper(category));
            return viewList;
        }
    }
}
