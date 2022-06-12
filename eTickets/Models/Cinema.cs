using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema : Entity<int>
    {

        [Display(Name = "Cinema Logo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ypoughgjg")]
        public string? Logo { get; set; }


        [Display(Name = "Name")]
        public string? Name { get; set; }


        [Display(Name = "Description")]
        public string? Description { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; }
    }
}
