using MyMoney.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyMoney.Models.Deposits
{
    public class SingleDepositModel
    {
        public int Id { get; init; }

        [Display(Name = "Minimal Amount")]
        public decimal MinimalAmount { get; init; }

        public Currency Currency { get; init; }

        public int Term { get; init; }

        [Display(Name = "Annual Interest Rate")]
        public decimal AnnualInterestRate { get; init; }

        [Display(Name = "Client Type")]
        public ClientType ClientType { get; init; }

        [Display(Name = "Interest Payment")]
        public InterestPayment InterestPayment { get; init; }

        [Display(Name = "Fixed Interest")]
        public bool IsInterestFixed { get; init; }

        [Display(Name = "Overdraft Facility")]
        public bool OverdraftFacility { get; init; }

        [Display(Name = "Credit Facility")]
        public bool CreditFacility { get; init; }
    }
}
