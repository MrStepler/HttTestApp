using HttTestApp.Shared;

namespace HttTestApp.Server.Repositories
{
    public interface ProductRepository
    {
        public List<Product> GetProducts();
        public List<Category> GetCategories();
        public long AddProduct(Product product);
        public void AddCategoryToProduct(long article, string category);
    }
}
