using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryza.APAC.Lend.Test
{
    internal class Program
    {
        static FinancialSystem system = new FinancialSystem();

        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
        }

        /************************************************************************************************************
        Exercise 1 : Apply OOP concepts (abstraction and encapsulation) to the classes 
        modify the code to get the output below
        LoanAccount has been opened  
        OffsetAccount has been opened  
        TransactionAccount has been opened  
        TrustAccount has been opened  
        ***************************************************************************************************************/
        private static void Exercise1()
        {
            system = new FinancialSystem();
            Console.WriteLine("Exercise 1: Press any key to begin opening accounts");
            Console.ReadKey();

            var loanAccount = new LoanAccount();
            loanAccount.AccountId = "LN001";
            loanAccount.Balance = 10000m;
            loanAccount.AccountName = "Loan A";
            system.OpenAccount(loanAccount);

            var offsetAccount = new OffsetAccount();
            offsetAccount.AccountId = "OF001";
            offsetAccount.Balance = 5000m;
            offsetAccount.AccountName = "Offset A";
            system.OpenAccount(offsetAccount);

            var transactionAccount = new TransactionAccount();
            transactionAccount.AccountId = "TR001";
            transactionAccount.Balance = 2500m;
            transactionAccount.AccountName = "Transaction A";
            system.OpenAccount(transactionAccount);

            var trustAccount = new TrustAccount();
            trustAccount.AccountId = "TS001";
            trustAccount.Balance = 3000m;
            trustAccount.AccountName = "Trust A";
            system.OpenAccount(trustAccount);
        }

        /***************************************************************************************************************
        Test Exercise 2
        If you have completed the first test exercise, you can continue with the second one.
        Modify the program and the FinancialSystem.DescribeAllAccounts() method so that each account provides a detailed description of itself. This description should include:

        The type of account
        Its balance
        Its interest rate (if applicable)
        Accounts that do not earn interest (e.g. OffsetAccount) should clearly state that they are non-interest-bearing and should not include an InterestRate field.

        Expected Test 2 Program Output

        Exercise 2: Press any key to list account descriptions  
        LoanAccount: $10,000.00 balance at 5% interest  
        OffsetAccount: $5,000.00 balance (non-interest-bearing)  
        TransactionAccount: $2,500.00 balance at 1% interest  
        TrustAccount: $3,000.00 balance at 2% interest 

         *****************************************************************************************************************/
        private static void Exercise2()
        {
            Console.WriteLine("\nExercise 2: Press any key to list account descriptions");
            Console.ReadKey();
            system.DescribeAllAccounts();
        }

        /*****************************************************************************************************************
        Test Exercise 3
        If you have completed the previous test exercise, you can continue with this one 
        The project includes an interface ICalculatesInterest. Make use of this interface to implement on the relevant classes
        so that calling the CalculateInterest() method to get the below output

        Update the FinancialSystem.CalculateInterest() method so that it takes a date range and uses this interface to calculate and display daily interest for each applicable account using the following formula:
        Interest = Balance × InterestRate × NumberOfDays / 365

        Expected Test 3 Program Output

        Exercise 3: Press any key to calculate interest  
        LoanAccount calculated interest from 01/01/2024 to 01/03/2024: $82.19 (10000 × 5% × 60 / 365)  
        TransactionAccount calculated interest from 01/01/2024 to 01/03/2024: $4.11 (2500 × 1% × 60 / 365)  
        TrustAccount calculated interest from 01/01/2024 to 01/03/2024: $9.86 (3000 × 2% × 60 / 365)  
        ************************************************************************************************************/
        private static void Exercise3()
        {
            Console.WriteLine("\nExercise 3: Press any key to calculate interest");
            Console.ReadKey();
            var fromDate = new DateTime(2024, 1, 1);
            var toDate = new DateTime(2024, 6, 1);
            system.CalculateInterest(fromDate, toDate);
        }

        /****************************************************************************************************
        Test Exercise 4
        If you have completed the previous test exercise, you can continue with this one.

        Add internal storage to the FinancialSystem class to hold all opened accounts.
        Implement the CloseAllAccounts() method to:
	        Iterate through each stored account.
	        If it’s a LoanAccount, print a message like "LoanAccount has been discharged" and set its Balance to 0.
	        For other accounts, print a message like "TrustAccount has been closed", but keep their balances intact.
	        Remove all accounts from the system or clear the collection.
        Once all accounts have been processed, print:
	        All accounts have been finalised


        Expected Test 4 Program Output

        Exercise 4: Press any key to close all accounts  
        LoanAccount has been discharged  
        OffsetAccount has been closed  
        TransactionAccount has been closed  
        TrustAccount has been closed  
        All accounts have been finalised  

        ********************************************************************************************************************/
        private static void Exercise4()
        {
            Console.WriteLine("\nExercise 4: Press any key to close all accounts");
            Console.ReadKey();
            system.CloseAllAccounts();
        }
    }
}
