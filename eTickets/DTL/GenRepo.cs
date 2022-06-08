using eTickets.DAL;
using Microsoft.EntityFrameworkCore;
using eTickets.Models;

namespace eTickets.DTL
{
    public interface IGenRepo<T, TKey>
    {
        T Add(T entity);
        List<T> GetList();
        T Put(T entity);
        T Get(TKey id);
    }

    public class GenRepo<T, TKey> : IGenRepo<T, TKey> where T : Entity<TKey>
    {
        public DbSet<T> _DbSet { get; set; }

        public AppDbContext _context;

        public GenRepo(AppDbContext context)
        {
            _context = context;
            _DbSet = context.Set<T>();
        }

        public List<T> GetList() => _DbSet.ToList();

        public T Get(TKey key)
        {
            return _DbSet.Find(key);
        }

        public T Put(T entity)
        {
            _context.SaveChanges();
            return entity;
        }

        public T Add(T entity)
        {
            _DbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        

    }
}

