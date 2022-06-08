using eTickets.DTL;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class MoviesController : GenericController<Movie, int>
    {
        public MoviesController(IGenRepo<Movie, int> context) : base(context)
        {
        }
    }
}
