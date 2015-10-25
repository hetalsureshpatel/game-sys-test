using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesSys.Logic;
using System.Collections.Generic;

namespace GamesSys.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        private Generator _generator;

        [TestInitialize()]
        public void Initialize()
        {
            _generator = new Generator();
        }

        [TestMethod]
        public void If_Size_Is_Zero_Should_Be_Empty()
        {
            var results = _generator.GenerateSeries(1, 0.5, 0);

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void Generated_Series_Should_Match_Expected_Size()
        {
            var results = _generator.GenerateSeries(1, 0.5, 2);

            Assert.IsTrue(results.Count == 2);
        }

        [TestMethod]
        public void Verfiy_Number_Is_Unique()
        {
            var one = 1;
            var list = new List<double> { 2, 3};

            Assert.IsTrue(_generator.IsUnique(list, one));
        }

        [TestMethod]
        public void Verfiy_Number_Not_Is_Unique()
        {
            var one = 1;
            var list = new List<double> { 1, 2, 3 };

            Assert.IsFalse(_generator.IsUnique(list, one));
        }

        [TestMethod]
        public void Should_Return_Third_Largest_If_List_Contains_Three_Items()
        {
            var result = _generator.GetNumberOne(1, 5062.5, 5);

            Assert.AreEqual(6.5, result);
        }

        [TestMethod]
        public void Should_Return_Zero_If_List_Contains_Two_Items()
        {
            var result = _generator.GetNumberOne(1, 5062.5, 2);

            Assert.AreEqual(0.0d, result);
        }
    }
}
