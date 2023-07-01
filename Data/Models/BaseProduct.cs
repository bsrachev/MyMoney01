using MyMoney.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Data.Models
{
    public class BaseProduct
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [Display(Name = "Minimal Amount")]
        public decimal MinimalAmount { get; init; }

        [Required]
        public Currency Currency { get; init; }

        [Required]
        public int Term { get; init; }

        [Required]
        [Display(Name = "Annual Interest Rate")]
        public decimal AnnualInterestRate { get; init; }
    }
}

