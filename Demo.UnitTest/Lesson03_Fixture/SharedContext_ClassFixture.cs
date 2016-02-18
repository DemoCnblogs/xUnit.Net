using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.UnitTest.Lesson03_Fixture
{
    public class CurrentUserFixture
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public static int ExecuteCount;
        
        public CurrentUserFixture()
        {
            this.UserId = 1;
            this.UserName = "North";
            ExecuteCount++;
        }
    }
    public class SharedContext_ClassFixture : IClassFixture<CurrentUserFixture>
    {
        ITestOutputHelper _output;
        CurrentUserFixture _currentUser;
        static int _count;
        public SharedContext_ClassFixture(ITestOutputHelper output,CurrentUserFixture user)
        {
            _output = output;
            _currentUser = user;
            _count++;
        }
        #region Test case
        [Fact(DisplayName = "SharedContext.ClassFixture.Case01")]
        public void TestCase01()
        {
            _output.WriteLine("Execute case 01! Current User:[{0}]-{1}", _currentUser.UserId, _currentUser.UserName);
            _output.WriteLine("Execute count! Constructor:[{0}] , ClassFixture:[{1}]", _count, CurrentUserFixture.ExecuteCount);

        }

        [Fact(DisplayName = "SharedContext.ClassFixture.Case02")]
        public void TestCase02()
        {
            _output.WriteLine("Execute case 01! Current User:[{0}]-{1}", _currentUser.UserId, _currentUser.UserName);
            _output.WriteLine("Execute count! Constructor:[{0}] , ClassFixture:[{1}]", _count, CurrentUserFixture.ExecuteCount);
        }
        #endregion Test case
    }
}
