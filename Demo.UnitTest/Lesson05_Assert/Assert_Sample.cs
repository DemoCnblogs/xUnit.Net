using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTest.Lesson05_Assert
{
    public class Assert_Sample
    {
        class DateComparer : IEqualityComparer<DateTime>
        {
            public bool Equals(DateTime x, DateTime y)
            {
                return x.Date == y.Date;
            }

            public int GetHashCode(DateTime obj)
            {
                return obj.GetHashCode();
            }
        }

        [Fact(DisplayName = "Assert.DateComparer.Demo01")]
        public void Assert_DateComparer_Demo01()
        {
            var firstTime = DateTime.Now.Date;
            var later = firstTime.AddMinutes(90);

            Assert.NotEqual(firstTime, later);
            Assert.Equal(firstTime, later, new DateComparer());
        }
    }
}
