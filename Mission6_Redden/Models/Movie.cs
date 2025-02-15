using System.ComponentModel.DataAnnotations;

namespace Mission6_Redden.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; } //Primary Key

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public required string Director { get; set; }

        [Required]
        public required string Rating { get; set; }

        public bool Edited { get; set; }  // Nullable bool for checkbox
        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}