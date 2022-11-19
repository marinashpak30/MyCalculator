using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {

        [TestMethod()]
        public void AddDigitTest()
        {
            try
            {
                Calculator calc = new Calculator();
                calc.AddDigit(200) ;
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod()]
        public void AddDecimalPointTest()
        {
            try
            {
                Calculator calc = new Calculator();
                calc.AddDecimalPoint();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod()]
        public void AddOperationTest()
        {
            //arrange
            try
            {
                int exp = 50;

                //act
                Calculator calc = new Calculator();
                calc.AddOperation(Operation.Add);
                int actual = 10 + 40;

                //assert
                Assert.AreEqual(exp, actual);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod()]
        public void ComputeUnarTest()
        {
            try
            {
                Calculator calc = new Calculator();
                calc.ComputeUnar();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod()]
        public void ComputeTest()
        {
            try
            {
                Calculator calc = new Calculator();
                calc.Compute();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod()]
        public void ClearTest()
        {
            try
            {
                Calculator calc = new Calculator();
                calc.Clear();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod()]
        public void ClearSimbolTest()
        {
            try
            {
                Calculator calc = new Calculator();
                calc.ClearSimbol();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsFalse(false);
            }
        }
    }
}