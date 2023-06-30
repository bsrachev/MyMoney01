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
        public decimal MinimalAmount { get; init; }

        [Required]
        public Currency Currency { get; init; }

        [Required]
        public int Term { get; init; }

        [Required]
        public decimal AnnualInterestRate { get; init; }
    }
}

