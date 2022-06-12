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


        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////


        // List Page
        public virtual IActionResult Index() { return View(_repo.GetListAsync()); }


        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////


        // Details Page
        [HttpGet]
        public async Task<IActionResult> Details(TKey id) 
        {
            var details = await _repo.GetAsync(id);
            if (details == null) return View("NotFound");
            return View(details); 
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////


        // Create Page
        public virtual IActionResult Create() { return View(); }

        // Action : Create T 
        [HttpPost]
        public virtual async Task<IActionResult> Create(T entity)
        {
            await _repo.PostAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////

        // Edit Page
        public virtual async Task<IActionResult> Edit(TKey id) 
        {
            var details = await _repo.GetAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        // Action : Edit T 
        [HttpPost, ActionName("Edit")]
        public virtual async Task<IActionResult> EditAction(T entity, TKey id)
        {
            await _repo.PutAsync(entity, id);
            return RedirectToAction(nameof(Index));
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////


        // Delete Page
        public virtual async Task<IActionResult> Delete(TKey id) 
        {
            var details = await _repo.GetAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        // Action : Delete T 
        [HttpPost, ActionName("Delete")]
        public virtual async Task<IActionResult> DeleteAction(T entity, TKey id)
        {
            var details = await _repo.GetAsync(id);
            if (details == null) return View("NotFound");
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
