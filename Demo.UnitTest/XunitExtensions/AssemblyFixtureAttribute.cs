using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UnitTest.XunitExtensions
{
    /// <summary>
    /// 定义AssemblyFixture Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class AssemblyFixtureAttribute : Attribute
    {
        public AssemblyFixtureAttribute(Type fixtureType)
        {
            FixtureType = fixtureType;
        }

        public Type FixtureType { get; private set; }
    }
}
