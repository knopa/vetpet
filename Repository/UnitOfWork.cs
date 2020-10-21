using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPet.Data;

namespace VetPet.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;

        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        #region Private Repositories
        private AnimalRepository _animalRepository;
        #endregion

        public R CreateRepository<R>() => (R)Activator.CreateInstance(typeof(R), db);
        public void Save() => db.SaveChanges();

        #region Public Repositories
        public AnimalRepository AnimalRepository => _animalRepository ??= CreateRepository<AnimalRepository>();
        #endregion

        #region IDisposable

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        #endregion IDisposable
    }
}
