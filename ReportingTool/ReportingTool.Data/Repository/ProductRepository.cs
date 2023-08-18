using ReportingTool.Data.Repository.IRepository;
using System.Linq;

namespace ReportingTool.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ReportingTool_DbEntities _db;

        public ProductRepository(ReportingTool_DbEntities db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == product.Id);
            objFromDb.ProductName = product.ProductName;
            objFromDb.QuantityInStock = product.QuantityInStock;
            objFromDb.Price = product.Price;
        }
    }
}
