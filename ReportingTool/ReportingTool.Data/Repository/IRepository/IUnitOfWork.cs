using System;

namespace ReportingTool.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository productRepository { get; }
        void Save();
    }
}
