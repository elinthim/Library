using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Library.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string PhoneNr { get; set; }
    }
}