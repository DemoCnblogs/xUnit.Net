using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTest.RetryFact
{
    public class Samples
    {
        public class CounterFixture
        {
            public int RunCount;
        }

        public class RetryFactSample : IClassFixture<CounterFixture>
        {
            private readonly CounterFixture counter;

            public RetryFactSample(CounterFixture counter)
            {
                this.counter = counter;
                counter.RunCount++;
            }

            //[Fact]
            [RetryFact(MaxRetries = 10)]
            public void IWillPassTheSecondTime()
            {
                Assert.Equal(10, counter.RunCount);
            }
        }
    }
}
