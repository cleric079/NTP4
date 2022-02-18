using System;
using Model;
using NUnit.Framework;

namespace UnitTestProject1
{
    /// <summary>
    /// Набор тестов для класса Helicopter
    /// </summary>
    [TestFixture]
    class HelicopterTest
    {
        /// <summary>
        /// Тестирование метода Spend на позитивных тестах
        /// </summary>
        /// <param name="s">Значение свойства S</param>
        /// <param name="q">Значение свойства Q</param>
        /// <param name="expected">Ожидаемое значение</param>
        [Test]
        [TestCase(0, 0, 0, TestName = "Тестирование Spend при значениях s = 0 и q = 0.")]
        [TestCase(0, 1000, 0, TestName = "Тестирование Spend при значениях s = 0 и q = 1000.")]
        [TestCase(1000, 0, 0, TestName = "Тестирование Spend при значениях s = 1000 и q = 0.")]
        [TestCase(1000, 2500, 12500, TestName = "Тестирование Spend при значениях s = 1000 и q = 2500.")]

        public void SpendPosTest(double s, double q, double expected)
        {
            var help = new Helicopter();
            help.S = s;
            help.Q = q;
            Assert.AreEqual(expected, help.Spend);
        }

        /// <summary>
        /// Тестирование метода Spend на негативном тесте
        /// </summary>
        /// <param name="s">Значение свойства S</param>
        /// <param name="q">Значение свойства Q</param>
        /// <param name="expectedException">Значение исключения</param>
        [Test]
        [TestCase(double.MaxValue, double.MaxValue, typeof(OverflowException), TestName = "Тестирование Spend при max значениях")]

        public void SpendNegTest(double s, double q, Type expectedException)
        {
            var help = new Helicopter();
            help.S = s;
            help.Q = q;
            try
            {
                checked
                {
                    double res = help.Spend;
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}