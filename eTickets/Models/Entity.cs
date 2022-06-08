using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Entity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
