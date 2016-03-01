using Demo.UnitTest.Lesson03_Fixture;
using Demo.UnitTest.XunitExtensions;
using System;
using Xunit;
// The custom test framework enables the support
[assembly: TestFramework("Demo.UnitTest.XunitExtensions.XunitTestFrameworkWithAssemblyFixture", "Demo.UnitTest")]

// Add one of these for every fixture classes for the assembly.
// Just like other fixtures, you can implement IDisposable and it'll
// get cleaned up at the end of the test run.
[assembly: AssemblyFixture(typeof(MyAssemblyFixture))]

namespace Demo.UnitTest.Lesson03_Fixture
{
    #region Test Case

    public class Sample1
    {
        MyAssemblyFixture fixture;

        // Fixtures are injectable into the test classes, just like with class and collection fixtures
        public Sample1(MyAssemblyFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void EnsureSingleton()
        {
            Assert.Equal(1, MyAssemblyFixture.InstantiationCount);
        }
    }

    public class Sample2
    {
        MyAssemblyFixture fixture;

        public Sample2(MyAssemblyFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void EnsureSingleton()
        {
            Assert.Equal(1, MyAssemblyFixture.InstantiationCount);
        }
    }

    public class MyAssemblyFixture : IDisposable
    {
        public static int InstantiationCount;

        public MyAssemblyFixture()
        {
            InstantiationCount++;
        }

        public void Dispose()
        {
            // Uncomment this and it will surface as an assembly cleanup failure
            //throw new DivideByZeroException();
        }
    }
    #endregion
    class SharedContext_AssemblyFixture
    {
    }
}
