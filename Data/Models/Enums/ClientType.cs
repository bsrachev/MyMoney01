namespace MyMoney.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ClientType
    {
        [Display(Name = "Senior")]
        Senior = 1,

        [Display(Name = "Regular")]
        Regular = 2,

        [Display(Name = "VIP")]
        VIP = 3,
    }
}
