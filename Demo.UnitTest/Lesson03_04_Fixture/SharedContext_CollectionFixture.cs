using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Demo.UnitTest.Lesson03_Fixture
{

    public class DatabaseFixture : IDisposable
    {
        public object DatabaseContext { get; set; }

        public static int ExecuteCount { get; set; }

        public DatabaseFixture()
        {
            ExecuteCount++;
            //初始化数据连接
        }

        public void Dispose()
        {
            //销毁数据连接
        }
    }

    /// <summary>
    /// 定义Collection名称，标明使用的Fixture
    /// </summary>
    [CollectionDefinition("DatabaseCollection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }

        
    [Collection("DatabaseCollection")]
    public class SharedContext_CollectionFixture_01
    {
        private DatabaseFixture _dbFixture;
        private ITestOutputHelper _output;
        public SharedContext_CollectionFixture_01(ITestOutputHelper output, DatabaseFixture dbFixture)
        {
            _dbFixture = dbFixture;
            _output = output;
        }

        [Fact(DisplayName = "SharedContext.CollectionFixture.Case01")]
        public void TestCase01()
        {
            _output.WriteLine("Execute CollectionFixture case 01!");
            _output.WriteLine("DatabaseFixture ExecuteCount is : {0}", DatabaseFixture.ExecuteCount);
        }
    }

    [Collection("DatabaseCollection")]
    public class SharedContext_CollectionFixture_02
    {
        private DatabaseFixture _dbFixture;
        private ITestOutputHelper _output;
        public SharedContext_CollectionFixture_02(DatabaseFixture dbFixture, ITestOutputHelper output)
        {
            _dbFixture = dbFixture;
            _output = output;
        }

        [Fact(DisplayName = "SharedContext.CollectionFixture.Case02")]
        public void TestCase01()
        {
            _output.WriteLine("Execute CollectionFixture case 02!");
            _output.WriteLine("DatabaseFixture ExecuteCount is : {0}", DatabaseFixture.ExecuteCount);
        }
    }
}
