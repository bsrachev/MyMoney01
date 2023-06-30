using MyMoney.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Data.Models
{
    public class Insurrance : BaseProduct
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public decimal CoverageAmount { get; init; }

        [Required]
        public InsuredItem Item { get; init; }
    }
}

