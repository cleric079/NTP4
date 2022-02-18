using System;
using Model;
using NUnit.Framework;

namespace UnitTestProject1
{
    /// <summary>
    /// Набор тестов для класса Car
    /// </summary>
    [TestFixture]
    public class CarTest
    {
        /// <summary>
        /// Тестирование свойства S на позитивных тестах
        /// </summary>
        /// <param name="value">Значение свойства S</param>
        [Test]
        [TestCase(1000, TestName = "Тестирование S при присваивании 1000.")]
        [TestCase(double.MaxValue, TestName = "Тестирование S при присваивании max значения")]
        [TestCase(0, TestName = "Тестирование S при присваивании 0")]
        public void SPosTest(double value)
        {
            var car = new Car();
            car.S = value;
        }

        /// <summary>
        /// Тестирование свойства S на негативных тестах
        /// </summary>
        /// <param name="value">Значение свойства S</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        [TestCase(-1, typeof(Exception), TestName = "Тестирование S при присваивании -1")]
        [TestCase(double.MinValue, typeof(Exception), TestName = "Тестирование S при присваивании min значения")]
        public void SNegTest(double value, Type expectedException)
        {
            var car = new Car();
            Assert.Throws(expectedException, () => car.S = value);
        }

        /// <summary>
        /// Тестирование свойства Q на позитивных тестах
        /// </summary>
        /// <param name="value">Значение свойства Q</param>
        [Test]
        [TestCase(1000, TestName = "Тестирование Q при присваивании 1000.")]
        [TestCase(double.MaxValue, TestName = "Тестирование Q при присваивании max значения")]
        [TestCase(0, TestName = "Тестирование Q при присваивании 0")]
        public void QPosTest(double value)
        {
            var car = new Car();
            car.Q = value;
        }

        /// <summary>
        /// Тестирование свойства Q на негативных тестах
        /// </summary>
        /// <param name="value">Значение свойства Q</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        [TestCase(-1, typeof(Exception), TestName = "Тестирование Q при присваивании -1")]
        [TestCase(double.MinValue, typeof(Exception), TestName = "Тестирование Q при присваивании min значения")]
        public void QNegTest(double value, Type expectedException)
        {
            var car = new Car();
            Assert.Throws(expectedException, () => car.Q = value);
        }

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
        [TestCase(1000, 2500, 250000, TestName = "Тестирование Spend при значениях s = 1000 и q = 2500.")]

        public void SpendPosTest(double s, double q, double expected)
        {
            var car = new Car();
            car.S = s;
            car.Q = q;
            Assert.AreEqual(expected, car.Spend);
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
            var car = new Car();
            car.S = s;
            car.Q = q;
            try
            {
                checked
                {
                    double res = car.Spend;
                }
            }
            catch (OverflowException ex)
            {
                expectedException = ex.GetType();
            }
        }
    }
}