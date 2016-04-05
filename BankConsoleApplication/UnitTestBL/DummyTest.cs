using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomeBL.Interface;

namespace UnitTestBL
{
    [TestClass]
    public class DummyTest
    {
        private class DummyClass : IBusinessClass
        {
            public string Value()
            {
                return null;
            }
        }

        List<string> DummyList;

        [TestInitialize]
        public void Initialize()
        {
            var dummyClass = new DummyClass();
            DummyList = new List<string>
            { 
                dummyClass.Value(),
                dummyClass.Value()
            };
        }

        //[TestMethod]
        public void Dummy_CallDummy_True()
        {
            Assert.AreEqual(2, DummyList.Count);
        }
    }
}