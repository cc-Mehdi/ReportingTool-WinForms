using ReportingTool.Data.Repository.IRepository;

namespace ReportingTool.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportingTool_DbEntities _db;

        public UnitOfWork(ReportingTool_DbEntities db)
        {
            _db = db;
            productRepository = new ProductRepository(_db);
        }

        public IProductRepository productRepository { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
