namespace Aryza.APAC.Lend.Test
{
    public abstract class AccountBase
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }

        public abstract void DescribeAccount();

        public abstract void DescribeDetails();

    }
}
