using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Library.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; }



    }
}
