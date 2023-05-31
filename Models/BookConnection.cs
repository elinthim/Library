using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Library.Models
{
    public class BookConnection
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookConnectionId { get; set; }
        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Book")]
        public int FK_BookId { get; set; }
        public virtual Book Book { get; set; }
        [Required]
        public bool IsReturned { get; set; }
        [DisplayName("Loan day")]
        public DateTime Barrowed { get; set; } = DateTime.Now.Date;
        [DisplayName("Last Day")]
        public string ReturnDate => Barrowed.AddDays(30).Date.ToString("yyyy-MM-dd");
    }
}
