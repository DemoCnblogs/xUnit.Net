using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTest.RetryFact
{
    public class RetryFactSamples
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

            [RetryFact(DisplayName = "RetryFactSamples.Demo01", MaxRetries = 5)]
            public void IWillPassTheSecondTime()
            {
                Assert.Equal(2, counter.RunCount);
            }
        }
    }
}
