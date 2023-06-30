namespace MyMoney.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum InterestPayment
    {
        [Display(Name = "Monthly")]
        Monthly = 1,

        [Display(Name = "Quarterly")]
        Quarterly = 2,

        [Display(Name = "Yearly")]
        Yearly = 3,

        [Display(Name = "End of Term")]
        EndOfTerm = 4
    }
}
