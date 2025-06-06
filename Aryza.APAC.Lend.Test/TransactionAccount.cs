using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    public class TransactionAccount : AccountBase, ICalculatesInterest
    {
        public decimal InterestRate { get; set; } = 1m; // 1% nominal rate

        public override void DescribeAccount()
        {
            Console.WriteLine("TransactionAccount has been opened");
        }

        public override void DescribeDetails()
        {
            Console.WriteLine($"TransactionAccount: {Balance:C} balance at {InterestRate}% interest");
        }

        public decimal CalculateInterest(DateTime fromDate, DateTime toDate)
        {
            var days = (toDate - fromDate).Days;
            var interest = Balance * (InterestRate / 100m) * days / 365m;
            return Math.Round(interest, 2);
        }

    }
}
