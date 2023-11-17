using Xunit;

namespace Rocket.xUnitTests
{
    public class EnumerableTest
    {
        [Fact]
        public void Test()
        {
            var firstNumber = CreateNumbers().Last(x => x % 2 == 0);
            Assert.Equal(8, firstNumber);
        }

        private IEnumerable<int> CreateNumbers()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
        }
    }
}
