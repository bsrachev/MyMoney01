namespace MyMoney.Data
{
    public class DataConstants
    {
        public class Roles
        {
            public const string AdministratorAreaName = "Admin";

            public const string AdministratorRoleName = "Administrator";
        }

        public class User
        {
            public const int FullNameMinLength = 10;
            public const int FullNameMaxLength = 50;
            public const int UsernameMinLength = 6;
            public const int UsernameMaxLength = 100;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }

        public class ErrorMessages
        {
            public const string InvalidCurrencyCode = "The currency code is invalid.";
        }

        public class SuccessMessages
        {
            public const string SuccessfullyAddedCurrency = "Successfully added the currency.";
        }
    }
}