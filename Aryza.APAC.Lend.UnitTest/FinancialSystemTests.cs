using Aryza.APAC.Lend.Test;
using System;
using Xunit;


namespace Aryza.APAC.Lend.UnitTest
{ 
    public class FinancialSystemTests
    {
        [Fact]
        public void CanOpenAndCloseAccounts()
        {
            var system = new FinancialSystem();
            var loan = new LoanAccount { Balance = 1000m };
            var offset = new OffsetAccount { Balance = 2000m };

            system.OpenAccount(loan);
            system.OpenAccount(offset);

            system.CloseAllAccounts();

            Assert.Equal(0, loan.Balance);        // Loan is discharged
            Assert.Equal(2000m, offset.Balance);  // Offset remains
        }

        [Theory]
        [InlineData(10000, 5, 2500, 1, 3000, 2, "2024-01-01", "2024-03-01", 82.19, 4.11, 9.86)]
        [InlineData(20000, 6, 1000, 1.5, 5000, 2.5, "2024-04-01", "2024-06-01", 200.55, 2.51, 20.89)]
        public void CalculateInterest_AppliesToAllRelevantAccounts(
            decimal loanBalance, decimal loanRate,
            decimal transBalance, decimal transRate,
            decimal trustBalance, decimal trustRate,
            string fromStr, string toStr,
            decimal expectedLoanInterest, decimal expectedTransInterest, decimal expectedTrustInterest)
        {
            var system = new FinancialSystem();
            var loan = new LoanAccount { Balance = loanBalance, InterestRate = loanRate };
            var transaction = new TransactionAccount { Balance = transBalance, InterestRate = transRate };
            var trust = new TrustAccount { Balance = trustBalance, InterestRate = trustRate };

            system.OpenAccount(loan);
            system.OpenAccount(transaction);
            system.OpenAccount(trust);

            var from = DateTime.Parse(fromStr);
            var to = DateTime.Parse(toStr);

            Assert.Equal(expectedLoanInterest, loan.CalculateInterest(from, to));
            Assert.Equal(expectedTransInterest, transaction.CalculateInterest(from, to));
            Assert.Equal(expectedTrustInterest, trust.CalculateInterest(from, to));

            // Optionally: Just run system.CalculateInterest to ensure it runs
            system.CalculateInterest(from, to);
        }
    }
}
