using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.UnitTest.Lesson05_Assert
{
    class DateComparer : IEqualityComparer<DateTime>
    {
        private DateComparer() { }

        private static DateComparer _instance;
        public static DateComparer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DateComparer();
                }
                return _instance;
            }
        }

        public bool Equals(DateTime x, DateTime y)
        {
            return x.Date == y.Date;
        }

        public int GetHashCode(DateTime obj)
        {
            return obj.GetHashCode();
        }
    }

    class SingletonFactory
    {
        public static DateComparer CreateDateComparer()
        {
            return DateComparer.Instance;
        }
        //Other Comparer ... ...
    }
    public class SingletonFactory_Demo
    {
        [Fact(DisplayName = "Assert.Singleton.DateComparer.Demo01")]
        public void Assert_Singleton_DateComparer_Demo01()
        {
            var firstTime = DateTime.Now.Date;
            var later = firstTime.AddMinutes(90);

            Assert.NotEqual(firstTime, later);
            Assert.Equal(firstTime, later, SingletonFactory.CreateDateComparer());
        }
    }
}
