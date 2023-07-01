using MyMoney.Data.Models.Enums;
using NBUniforms.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyMoney.Models.Deposits
{
    public class AllDepositsQueryModel
    {
        public Currency CurrencySearch { get; init; }

        public DepositsSorting Sorting { get; init; }

        public IEnumerable<SingleDepositModel> Deposits { get; set; }

        public int? SelectedDepositId { get; set; }

        public decimal DesiredAmount { get; set; }

        public decimal CalculatedAmount { get; set; }
    }
}
