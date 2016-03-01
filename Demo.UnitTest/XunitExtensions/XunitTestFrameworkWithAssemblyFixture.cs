using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Demo.UnitTest.XunitExtensions
{
    public class XunitTestFrameworkWithAssemblyFixture : XunitTestFramework
    {
        public XunitTestFrameworkWithAssemblyFixture(IMessageSink messageSink)
            : base(messageSink)
        { }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
        {
            return new XunitTestFrameworkExecutorWithAssemblyFixture(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
        }
    }
}
