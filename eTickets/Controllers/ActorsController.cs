using eTickets.DTL;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : GenericController<Actor, int>
    {
        public ActorsController(IGenRepo<Actor, int> repo) : base(repo) { }

    }
}

