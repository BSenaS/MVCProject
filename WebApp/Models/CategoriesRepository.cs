namespace WebApp.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { CategoryId = 1, Name = "Beverages", Description= "Beverage" },
            new Category { CategoryId = 2, Name = "Bakery", Description= "Bakery" },
            new Category { CategoryId = 3, Name = "Meat", Description= "Meat" }
        };

        //Adds New Category
        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        //Get all Categories
        public static List<Category> GetCategories()
        {
            return _categories;
        }

        //Get Category by Id
        public static Category? GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }
            return null;
        }

        //Update Category

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = GetCategoryById(categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        //Delete Category
        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}