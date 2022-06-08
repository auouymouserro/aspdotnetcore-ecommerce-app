using eTickets.DAL;
using eTickets.DTL;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class GenericController<T, TKey> : Controller where T : Entity<TKey>
    {
        public readonly IGenRepo<T, TKey> _repo;
        public GenericController(IGenRepo<T, TKey> repo)
        {
            _repo = repo;
        }

        public virtual IActionResult Index()
        {
            return View(_repo.GetList());
        }

        public virtual T Item(TKey key)
        {
            return _repo.Get(key);

        }
    }
}
