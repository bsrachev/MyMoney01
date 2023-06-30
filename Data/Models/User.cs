namespace MyMoney.Data.Models
{
    using static DataConstants.User;

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser<int>
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }
    }
}
