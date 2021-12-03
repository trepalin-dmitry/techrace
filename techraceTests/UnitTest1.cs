using System.Diagnostics;
using NUnit.Framework;
using techrace;

namespace techraceTests
{
    [SetUpFixture]
    public class SetupTrace
    {
        [OneTimeSetUp]
        public void StartTest()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }
    
        [OneTimeTearDown]
        public void EndTest()
        {
            Trace.Flush();
        }
    }
    
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("57,58", Calculator.Calculate("27,14,58,101,3"));
        }
    } 
}

