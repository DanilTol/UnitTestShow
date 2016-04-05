using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeBL.Interface;

namespace UnitTestBL
{
    [TestClass]
    public class StubTest
    {
        private class StubClass : IBusinessClass
        {
            public string Value()
            {
                return "_stub_here";
            }
        }

        //[TestMethod]
        public void Stub_CallStub_JoinedStubs()
        {
            var stubClass = new StubClass();
            var stubList = new List<string>
            {
                stubClass.Value(),
                stubClass.Value()
            };

            var result = stubList.Aggregate((i, j) => i + j);

            Assert.AreEqual("_stub_here_stub_here", result);
        }
    }
}