using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    public interface ICalculatesInterest
    {
        decimal CalculateInterest(DateTime fromDate, DateTime toDate);
        decimal InterestRate { get; }
    }
}
