using HttTestApp.Server.Services;
using HttTestApp.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HttTestApp.Server.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService;
        public ProductController(ProductService productService) 
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("/products/categories")]
        public ActionResult<List<ProductsDTO>> GetProductListWithCategory()
        {
            var result = _productService.GetProductVithCategory();
            return Ok(result);
        }
        [HttpGet]
        [Route("/products")]
        public ActionResult<List<Product>> GetProductOnFilter(float cost, bool more)
        {
            List<Product> result = new List<Product>();
            if (cost<0)
            {
                return BadRequest();
            }
            if (more)
            {
                result = _productService.GetProductByCost(cost, ProductServiceImp.Filter.More);
            }
            else
            {
                result = _productService.GetProductByCost(cost, ProductServiceImp.Filter.Less);
            }
            
            return Ok(result);
        }
        [HttpGet]
        [Route("/categories")]
        public ActionResult<List<string>> GetCategories()
        {
            var result = _productService.GetListCategories();
            return Ok(result);
        }
        [HttpPost]
        [Route("/product")]
        public ActionResult<long> AddProduct([FromBody] Product newproduct)
        {
            if (newproduct.Count == null || newproduct.Count < 0)
            {
                return BadRequest();
            }
            if (newproduct.Cost == null || newproduct.Cost <=0 )
            {
                return BadRequest();
            }
            return Ok(_productService.AddProductToRepository(newproduct));
        }
        [HttpPost]
        [Route("/product/{article}/category")]
        public IActionResult AddCategoryToProduct([FromRoute] long? article, [FromBody] string? categoryname)
        {
            if (article == null || article < 0)
            {
                return BadRequest();
            }
            if (String.IsNullOrEmpty(categoryname))
            {
                return BadRequest();
            }
            if (!_productService.AddCategoryToProduct(article, categoryname))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
