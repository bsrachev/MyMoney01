using MyMoney.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMoney.Data.Models
{
    public class Deposit : BaseProduct
    {
        [Required]
        public ClientType ClientType { get; init; }

        [Required]
        public InterestPayment InterestPayment { get; init; }

        [Required]
        public bool IsInterestFixed { get; init; }

        [Required]
        public bool OverdraftFacility { get; init; }

        [Required]
        public bool CreditFacility { get; init; }
    }
}

