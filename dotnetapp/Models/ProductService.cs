using dotnetapp.Models;
using System.Linq;

namespace dotnetapp.Models
{
    public interface IProductService
    {
        public IQueryable<Product> GetProductList();
        public bool AddProduct(Product product);
        public bool DeleteProduct(int Id);
    }
    //Fill ur code
    public class ProductService : IProductService
    {
       private readonly ProductDBContext _dbContext;

        public ProductService(ProductDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Product> GetProductList()
        {
           return _dbContext.Products.As
        }

        public bool AddProduct(Product product)
        {
            var newProduct =  _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int Id)
        {
            var productToRemove = _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            if(productToRemove != null)
            {
                _dbContext.Products.Remove(productToRemove);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}