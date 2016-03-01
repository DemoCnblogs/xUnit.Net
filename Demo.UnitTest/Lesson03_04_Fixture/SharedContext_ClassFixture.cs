using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.UnitTest.Lesson03_Fixture
{
    public class SingleBrowserFixture : IDisposable
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public static int ExecuteCount;

        public SingleBrowserFixture()
        {
            this.UserId = 1;
            this.UserName = "North";
            ExecuteCount++;

            //打开浏览器...
        }

        public void Dispose()
        {
            //关闭浏览器...
        }
    }
    public class SharedContext_ClassFixture : IClassFixture<SingleBrowserFixture>
    {
        ITestOutputHelper _output;
        SingleBrowserFixture _fixture;
        static int _count;
        public SharedContext_ClassFixture(ITestOutputHelper output, SingleBrowserFixture fixture)
        {
            _output = output;
            _fixture = fixture;
            _count++;
        }
        #region Test case
        [Fact(DisplayName = "SharedContext.ClassFixture.Case01")]
        public void TestCase01()
        {
            _output.WriteLine("Execute case 01! Current User:[{0}]-{1}", _fixture.UserId, _fixture.UserName);
            _output.WriteLine("Execute count! Constructor:[{0}] , ClassFixture:[{1}]", _count, SingleBrowserFixture.ExecuteCount);

        }

        [Fact(DisplayName = "SharedContext.ClassFixture.Case02")]
        public void TestCase02()
        {
            _output.WriteLine("Execute case 01! Current User:[{0}]-{1}", _fixture.UserId, _fixture.UserName);
            _output.WriteLine("Execute count! Constructor:[{0}] , ClassFixture:[{1}]", _count, SingleBrowserFixture.ExecuteCount);
        }
        #endregion Test case
    }
}
