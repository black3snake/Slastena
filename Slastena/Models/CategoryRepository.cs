
namespace Slastena.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SlastenaPieShopDbContext _slastenaPieShopDbContext;

        public CategoryRepository(SlastenaPieShopDbContext slastenaPieShopDbContext)
        {
            _slastenaPieShopDbContext = slastenaPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories =>
            _slastenaPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
