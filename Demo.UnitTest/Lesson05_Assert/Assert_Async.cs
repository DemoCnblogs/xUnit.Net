using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTest.Lesson05_Assert
{
    public class Assert_Async
    {
        [Fact]
        public async void CodeThrowsAsync()
        {
            Func<Task> testCode = () => Task.Factory.StartNew(ThrowingMethod);

            var ex = await Assert.ThrowsAsync<NotImplementedException>(testCode);

            Assert.IsType<NotImplementedException>(ex);
        }

        [Fact]
        public async void RecordAsync()
        {
            Func<Task> testCode = () => Task.Factory.StartNew(ThrowingMethod);

            var ex = await Record.ExceptionAsync(testCode);

            Assert.IsType<NotImplementedException>(ex);
        }

        void ThrowingMethod()
        {
            throw new NotImplementedException();
        }
    }
}
