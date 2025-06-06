using Aryza.APAC.Lend.Test;
using System;
using Xunit;

namespace Aryza.APAC.Lend.UnitTest
{
    public class LoanAccountTests
    {
        [Theory]
        [InlineData(10000, 5, 82.19)]
        [InlineData(5000, 3, 24.66)]
        public void CalculateInterest_ReturnsCorrectInterest(decimal balance, decimal rate, decimal expectedInterest)
        {
            var loan = new LoanAccount { Balance = balance, InterestRate = rate };
            var from = new DateTime(2024, 1, 1);
            var to = new DateTime(2024, 3, 1);
            Assert.Equal(expectedInterest, loan.CalculateInterest(from, to));
        }
    }

}
