using Repository.Database_storage;
using Repository.Interfaces;

namespace Repository.Implementation
{   
    public class UnitOfWork<T> : IUnitOfWork<T>, System.IDisposable where T : class
    {
        private readonly e_commDb _context;
        private IRepository<T> _modelRepository;

        public UnitOfWork()
        {
            _context = new e_commDb();
        }

        public IRepository<T> ModelRepository
        {
            get { return _modelRepository ?? (_modelRepository = new Repository<T>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
