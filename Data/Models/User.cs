namespace MyMoney.Data.Models
{
    using static DataConstants.User;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser<int>
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
