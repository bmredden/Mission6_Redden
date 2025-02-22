using System.ComponentModel.DataAnnotations;

namespace Mission7_Redden.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }  // PK for Categories table

        [Required]
        public required string CategoryName { get; set; }  // ✅ Use "CategoryName" from database

        // ✅ Navigation Property (One-to-Many)
        public List<Movie>? Movies { get; set; }
    }
}