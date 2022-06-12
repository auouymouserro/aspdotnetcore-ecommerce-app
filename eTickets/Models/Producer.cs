﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : Entity<int>
    {
        public string? ProfilePicture { get; set; }
        public string? FullName { get; set; }
        public string? Bio { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; }
    }

    
}

