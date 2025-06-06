using Aryza.APAC.Lend.Test;
using System;
using Xunit;

namespace Aryza.APAC.Lend.UnitTest
{
    public class TrustAccountTests
    {
        [Theory]
        [InlineData(3000, 2, 9.86)]
        [InlineData(7000, 4, 46.03)]
        public void CalculateInterest_ReturnsCorrectInterest(decimal balance, decimal rate, decimal expectedInterest)
        {
            var acct = new TrustAccount { Balance = balance, InterestRate = rate };
            var from = new DateTime(2024, 1, 1);
            var to = new DateTime(2024, 3, 1);
            Assert.Equal(expectedInterest, acct.CalculateInterest(from, to));
        }
    }
}
