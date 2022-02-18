using System;
using Model;
using NUnit.Framework;

namespace UnitTestProject1
{
    /// <summary>
    /// Набор тестов для класса Hybrid
    /// </summary>
    [TestFixture]
    class HybridTest
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
        [TestCase(1000, 2500, 125000, TestName = "Тестирование Spend при значениях s = 1000 и q = 2500.")]

        public void SpendPosTest(double s, double q, double expected)
        {
            var hype = new Hybrid();
            hype.S = s;
            hype.Q = q;
            Assert.AreEqual(expected, hype.Spend);
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
            var hype = new Hybrid();
            hype.S = s;
            hype.Q = q;
            try
            {
                checked
                {
                    double res = hype.Spend;
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}