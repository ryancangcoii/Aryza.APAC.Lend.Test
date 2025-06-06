using Aryza.APAC.Lend.Test;
using Xunit;

namespace Aryza.APAC.Lend.UnitTest
{
    public class OffsetAccountTests
    {
        [Fact]
        public void Balance_CanBeSetAndRead()
        {
            var acct = new OffsetAccount { Balance = 1500m };
            Assert.Equal(1500m, acct.Balance);
        }
    }
}
