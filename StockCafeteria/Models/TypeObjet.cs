using System.ComponentModel.DataAnnotations;

namespace StockCafeteria
{
    public class TypeObjet
    {
        [Key]
        public int IdTO
        { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Libelle
        { get; set; }

        [Required]
        public float PrixVente
        { get; set; }

        [Required]
        public float PrixAchat
        { get; set; }
    }
}