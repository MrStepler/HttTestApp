using HttTestApp.Shared;
using static HttTestApp.Server.Services.ProductServiceImp;

namespace HttTestApp.Server.Services
{
    public interface ProductService
    {
        public List<ProductsDTO> GetProductVithCategory();
        public List<Product>? GetProductByCost(float cost, Filter filter);
        public List<string> GetListCategories();
        public long AddProductToRepository(Product product);
        public bool AddCategoryToProduct(long? article, string? category);
    }
}
