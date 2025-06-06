using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    public class LoanAccount : AccountBase, ICalculatesInterest
    {
        public decimal InterestRate { get; set; } = 5m; // 5% by default

        public override void DescribeAccount()
        {
            Console.WriteLine("LoanAccount has been opened");
        }

        public override void DescribeDetails()
        {
            Console.WriteLine($"LoanAccount: {Balance:C} balance at {InterestRate}% interest");
        }

        public decimal CalculateInterest(DateTime fromDate, DateTime toDate)
        {
            var days = (toDate - fromDate).Days;
            var interest = Balance * (InterestRate / 100m) * days / 365m;
            return Math.Round(interest, 2);
        }
    }
}
