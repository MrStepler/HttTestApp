using HttTestApp.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HttTestApp.Server.Repositories
{
    public class ProductRepositoryImp: ProductRepository
    {
        private IDbContextFactory<DatabaseContext> _contextFactory;
        public ProductRepositoryImp(IDbContextFactory<DatabaseContext> contextFactory) 
        {
            _contextFactory = contextFactory;
        }   
        public List<Product> GetProducts()
        {
            var DBContext = _contextFactory.CreateDbContext();
            return DBContext.Products.ToList();

        }
        public List<Category> GetCategories()
        {
            var DBContext = _contextFactory.CreateDbContext();
            return DBContext.Categories.ToList();

        }
        public long AddProduct(Product product)
        {
            var DBContext = _contextFactory.CreateDbContext();
            DBContext.Products.Add(product);
            DBContext.SaveChanges();
            return product.Article;
        }
        public void AddCategoryToProduct(long article, string category)
        {
            var DBContext = _contextFactory.CreateDbContext();
            Category newCategory = new Category();
            newCategory.ProductArticle = article;
            newCategory.CategoryName = category;
            DBContext.Categories.Add(newCategory);
            DBContext.SaveChanges();
            
        }
    }
}
