using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : Entity<int>
    {

        [Display(Name = "Profile Picture URL")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ypoughgjg")]
        public string? ProfilePicture { get; set; }


        [Display(Name = "Full Name")]
        public string? FullName { get; set; }


        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        // Relationships 
        public List<Actor_Movie>? Actors_Movies { get; set; }
        //public string ProfilePictureURL { get; internal set; }
    }
}
