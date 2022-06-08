using eTickets.DTL;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class ActorsController : GenericController<Actor, int>
    {
        public ActorsController(IGenRepo<Actor, int> context) : base(context) { }

    }
}
