using eTickets.DTL;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class CinemasController : GenericController<Cinema, int>
    {
        public CinemasController(IGenRepo<Cinema, int> context) : base(context)
        {
        }

    }
}
