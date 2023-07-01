using MyMoney.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Data.Models
{
    public class Deposit : BaseProduct
    {
        [Required]
        [Display(Name = "Client Type")]
        public ClientType ClientType { get; init; }

        [Required]
        [Display(Name = "Interest Payment")]
        public InterestPayment InterestPayment { get; init; }

        [Required]
        [Display(Name = "Is Interest Fixed")]
        public bool IsInterestFixed { get; init; }

        [Required]
        [Display(Name = "Overdraft Facility")]
        public bool OverdraftFacility { get; init; }

        [Required]
        [Display(Name = "Credit Facility")]
        public bool CreditFacility { get; init; }
    }
}

