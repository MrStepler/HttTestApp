using HttTestApp.Server.Repositories;
using HttTestApp.Shared;

namespace HttTestApp.Server.Services
{
    public class ProductServiceImp : ProductService
    {
        ProductRepository _repository;
        
        public ProductServiceImp(ProductRepository repository)
        {
            _repository = repository;
        }
        public List<ProductsDTO> GetProductVithCategory()
        {
            var existingCategories = _repository.GetCategories();
            var Products = _repository.GetProducts().Select(x => new ProductsDTO
            {
                Article = x.Article,
                ProductName = x.ProductName,
                Cost = x.Cost,
                Description = x.Description,
                Count = x.Count,
                Categories = existingCategories.Where(y => y.ProductArticle == x.Article).Select(x=>x.CategoryName).ToList(),
            }).ToList();
            return Products;
        }
        public List<Product>? GetProductByCost(float cost, Filter filter)
        {
            if (filter == Filter.More)
            {
                var products = _repository.GetProducts().Where(x => x.Cost > cost).OrderBy(x => x.Cost).ToList();
                return products;
            }
            else if (filter == Filter.Less)
            {
                var products = _repository.GetProducts().Where(x => x.Cost < cost).OrderBy(x => x.Cost).ToList();
                return products;
            }
            return null;
        }
        public long AddProductToRepository(Product product)
        {
             return _repository.AddProduct(product);
        }
        public bool AddCategoryToProduct(long? article, string? category)
        {
            if (_repository.GetProducts().Any(x => x.Article ==article))
            {
                _repository.AddCategoryToProduct((long)article, (string)category);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public List<string> GetListCategories()
        {
            var categories = _repository.GetCategories().Distinct();
            return categories.Select(x => x.CategoryName).ToList();
        }
        public enum Filter
        {
            More,
            Less
        }
    }
}
