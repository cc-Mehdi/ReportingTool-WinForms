using System;

namespace ReportingTool.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        void Save();
    }
}
