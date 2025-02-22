using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission7_Redden.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; } //Primary Key

        [Required]
        public required string Title { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }  // FK to Categories table

        public Category? Category { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }  // Must be 1888 or later

       
        public string? Director { get; set; }

        [Required]
        public required string Rating { get; set; }

        public bool Edited { get; set; }  // Nullable bool for checkbox
        
        [Required]
        public required bool CopiedToPlex { get; set; }
        
        public string? LentTo { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}