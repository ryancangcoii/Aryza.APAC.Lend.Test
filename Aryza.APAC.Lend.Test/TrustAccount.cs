using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    public class TrustAccount : AccountBase, ICalculatesInterest
    {
        public decimal InterestRate { get; set; } = 2m; // 2% by default

        public override void DescribeAccount()
        {
            Console.WriteLine("TrustAccount has been opened");
        }

        public override void DescribeDetails()
        {
            Console.WriteLine($"TrustAccount: {Balance:C} balance at {InterestRate}% interest");
        }

        public decimal CalculateInterest(DateTime fromDate, DateTime toDate)
        {
            var days = (toDate - fromDate).Days;
            var interest = Balance * (InterestRate / 100m) * days / 365m;
            return Math.Round(interest, 2);
        }

    }
}
