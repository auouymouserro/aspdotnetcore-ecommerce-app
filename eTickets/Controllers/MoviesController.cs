using eTickets.DAL;
using eTickets.DTL;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : GenericController<Movie, int>
    {
        public AppDbContext _context;

        public MoviesController(IGenRepo<Movie, int> repo, AppDbContext context) : base(repo)
        {
            _context = context;
        }

        public override IActionResult Index()
        {
            var movies = _context.Movies.Include(movie => movie.Cinema).OrderBy(movie => movie.Name)
                .ToList();
            return base.View(movies);
        }

    }
}
