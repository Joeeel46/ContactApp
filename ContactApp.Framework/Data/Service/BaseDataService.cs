using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Framework.Data.Service
{
    public abstract class BaseDataService : IDataService
    {
        
        public IUnitOfWork UnitOfWork;
        
        public BaseDataService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private bool _disposed;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                UnitOfWork.Dispose();
            }

            _disposed = true;
        }
    }
}
