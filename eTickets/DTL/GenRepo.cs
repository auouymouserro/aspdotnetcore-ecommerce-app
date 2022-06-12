using eTickets.DAL;
using Microsoft.EntityFrameworkCore;
using eTickets.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.DTL
{
    public interface IGenRepo<T, TKey>
    {
        IEnumerable<T> GetListAsync(); // read list of T from db
        Task<T> GetAsync(TKey id); // read element T by its id TKey from db
        Task PostAsync(T entity); // create element T in db
        Task PutAsync(T entity, TKey id); // update element in db
        Task DeleteAsync(TKey id); // delete element from db
    }

    public class GenRepo<T, TKey> : IGenRepo<T, TKey> where T : Entity<TKey>
    {
        public DbSet<T> DbSet { get; set; }
        public AppDbContext _context;

        // Repository constructor
        public GenRepo(AppDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }


        // GetList of T from db /////////////////////////////////////////////////////////////////////////
        public IEnumerable<T> GetListAsync() => DbSet.ToList();



        // Get T by id from db //////////////////////////////////////////////////////////////////////////
        public async Task<T> GetAsync(TKey id) => await DbSet.FindAsync(id);



        // Post T in db /////////////////////////////////////////////////////////////////////////////////
        public async Task PostAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            _context.SaveChanges();
        }


        // Put T in db //////////////////////////////////////////////////////////////////////////////////
        public async Task PutAsync(T entity, TKey id)
        {
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }


        // Delete T from db ////////////////////////////////////////////////////////////////////////////
        public async Task DeleteAsync(TKey id)
        {
            var entity = await DbSet.FindAsync(id);
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = EntityState.Deleted;
            _context.SaveChanges();

        }

    }
}

