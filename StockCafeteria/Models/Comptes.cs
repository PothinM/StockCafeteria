using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockCafeteria
{
    public class Comptes
    {
        [Key]
        public int Id
        { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        public string Password
            //PasswordPropertyTextAttribute
        { get; set; }
    }
}