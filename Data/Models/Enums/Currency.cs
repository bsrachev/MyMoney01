namespace MyMoney.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Currency
    {
        [Display(Name = "BGN")]
        BGN = 1,

        [Display(Name = "USD")]
        USD = 2,

        [Display(Name = "EUR")]
        EUR = 3,

        [Display(Name = "GBP")]
        GBP = 4
    }
}
