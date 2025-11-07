using Application.IGenericRepository;
using Application.IUnitOfWork;
using Infrastructure.Context;
using Infrastructure.GenericRepository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories = new();
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repoInstance = new GenericRepository<T>(_context);
                _repositories.TryAdd(typeof(T), repoInstance);
            }

            return (IGenericRepository<T>)_repositories[typeof(T)];
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
