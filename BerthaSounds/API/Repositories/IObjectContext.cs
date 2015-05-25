using Ninject;
using System;
using System.Collections;
using System.Data.Entity;

namespace API.Repositories
{
    public interface IObjectContext : IDisposable
    {
        IDbSet<T> CreateObjectSet<T>() where T : class;
        void SaveChanges();
        DbContext GetContext();
    }

    public class ObjectContext : IObjectContext
    {
        readonly DbContext _context;

        [Inject]
        public ObjectContext(DbContext context)
        {
            _context = context;
        }

        public IDbSet<T> CreateObjectSet<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public DbContext GetContext()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}