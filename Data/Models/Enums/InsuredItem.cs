namespace MyMoney.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum InsuredItem
    {
        [Display(Name = "Casco")]
        BGN = 1,

        [Display(Name = "Home")]
        USD = 2,

        [Display(Name = "Travel")]
        EUR = 3,
    }
}
