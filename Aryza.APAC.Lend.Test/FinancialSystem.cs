using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    public class FinancialSystem
    {
        private List<AccountBase> accounts = new List<AccountBase>();

        // TEST 1
        public void OpenAccount(AccountBase account)
        {
            accounts.Add(account);
            account.DescribeAccount();
        }

        // TEST 2
        public void DescribeAllAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("No descriptions available for the accounts");
                return;
            }
            foreach (var acc in accounts)
            {
                acc.DescribeDetails();
            }
        }


        // TEST 3
        public void CalculateInterest(DateTime fromDate, DateTime toDate)
        {
            
            bool found = false;

            foreach (var acc in accounts)
            {
                if (acc is ICalculatesInterest interestAcc)
                {
                    var days = (toDate - fromDate).Days;
                    var interest = interestAcc.CalculateInterest(fromDate, toDate);
                    string rateStr = interestAcc.InterestRate.ToString();
                    Console.WriteLine($"{acc.GetType().Name} calculated interest from {fromDate:dd/MM/yyyy} to {toDate:dd/MM/yyyy}: {interest:C} ({acc.Balance} × {rateStr}% × {days} / 365)");
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("No interest calculations implemented");
        }


        // TEST 4
        public void CloseAllAccounts()
        {
            foreach (var acc in accounts)
            {
                if (acc is LoanAccount)
                {
                    Console.WriteLine("LoanAccount has been discharged");
                    acc.Balance = 0;
                }
                else
                {
                    // This will output, e.g., "TrustAccount has been closed"
                    Console.WriteLine($"{acc.GetType().Name} has been closed");
                }
            }
            accounts.Clear();
            Console.WriteLine("All accounts have been finalised");
        }

    }
}
