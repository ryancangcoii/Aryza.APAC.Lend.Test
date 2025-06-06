using Aryza.APAC.Lend.Test;
using System;
using Xunit;

namespace Aryza.APAC.Lend.UnitTest
{
    public class TransactionAccountTests
    {
        [Theory]
        [InlineData(2500, 1, 4.11)]
        [InlineData(5000, 2, 16.44)]
        public void CalculateInterest_ReturnsCorrectInterest(decimal balance, decimal rate, decimal expectedInterest)
        {
            var acct = new TransactionAccount { Balance = balance, InterestRate = rate };
            var from = new DateTime(2024, 1, 1);
            var to = new DateTime(2024, 3, 1);
            Assert.Equal(expectedInterest, acct.CalculateInterest(from, to));
        }
    }
}
