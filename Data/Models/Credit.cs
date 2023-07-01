using MyMoney.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Data.Models
{
    public class Credit : BaseProduct
    {
        [Required]
        [Display(Name = "Maximum Amount")]
        public decimal MaximumAmount { get; init; }
    }
}

