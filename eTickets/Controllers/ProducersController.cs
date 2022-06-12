
using eTickets.DTL;
using eTickets.Models;

namespace eTickets.Controllers
{
    public class ProducersController : GenericController<Producer, int>
    {
        public ProducersController(IGenRepo<Producer, int> repo) : base(repo)
        {
        }
    }
}
