using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    public class OffsetAccount : AccountBase
    {
        public override void DescribeAccount()
        {
            Console.WriteLine("OffsetAccount has been opened");
        }

        public override void DescribeDetails()
        {
            Console.WriteLine($"OffsetAccount: {Balance:C} balance (non-interest-bearing)");
        }

    }
}
