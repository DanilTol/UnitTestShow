using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SomeBL.Interface;

namespace UnitTestBL
{
    [TestClass]
    public class MockTest
    {
        //[TestMethod]
        public void Mock_Join()
        {
            var mock = new Moq.Mock<IBusinessClass>();
            mock.SetupSequence(classCall => classCall.Value()).Returns("_mock1_").Returns("_mock2_");
            var sut = new List<string>();

            sut.Add(mock.Object.Value());
            sut.Add(mock.Object.Value());

            var result = sut.Aggregate((i, j) => i + j);

            Assert.AreEqual("_mock1__mock2_", result);
            mock.Verify(classCall => classCall.Value(), Times.Exactly(2));
        }
    }
}