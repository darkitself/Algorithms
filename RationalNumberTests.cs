using NUnit.Framework;

namespace Lab3
{
    internal class RationalNumberTests
    {
        [Test]
        public void RationalNumber_ToString()
        {
            Assert.AreEqual("1/3", new RationalNumber(1, 3).ToString());
        }

        [Test]
        public void RationalNumber_Sum()
        {
            var aP = new RationalNumber(2, 5);
            var aM = new RationalNumber(-1, 5);
            Assert.AreEqual("1/5", (aP + aM).ToString());
            Assert.AreEqual("1/5", (aM + aP).ToString());
            Assert.AreEqual("4/5", (aP + aP).ToString());
            Assert.AreEqual("-2/5", (aM + aM).ToString());
        }

        [Test]
        public void RationalNumber_Minus()
        {
            var aP = new RationalNumber(2, 5);
            var aM = new RationalNumber(-1, 5);
            Assert.AreEqual("0", (aP - aP).ToString());
            Assert.AreEqual("0", (aM - aM).ToString());
            Assert.AreEqual("3/5", (aP - aM).ToString());
            Assert.AreEqual("-3/5", (aM - aP).ToString());
        }

        [Test]
        public void RationalNumber_Multiply()
        {
            var aP = new RationalNumber(2, 5);
            var aM = new RationalNumber(-1, 5);
            Assert.AreEqual("4/25", (aP * aP).ToString());
            Assert.AreEqual("1/25", (aM * aM).ToString());
            Assert.AreEqual("-2/25", (aP * aM).ToString());
            Assert.AreEqual("-2/25", (aM * aP).ToString());
        }

        [Test]
        public void RationalNumber_Divide()
        {
            var aP = new RationalNumber(2, 5);
            var aM = new RationalNumber(-1, 5);
            Assert.AreEqual("1/1", (aP / aP).ToString());
            Assert.AreEqual("1/1", (aM / aM).ToString());
            Assert.AreEqual("-2/1", (aP / aM).ToString());
            Assert.AreEqual("-1/2", (aM / aP).ToString());
        }

        [Test]
        public void RationalNumber_Reduction()
        {
            Assert.AreEqual("1/3", new RationalNumber(3, 9).ToString());
        }

        [Test]
        public void RationalNumber_ParsePeriodic()
        {
            Assert.AreEqual("1/3", RationalNumber.ParsePeriodicFraction("0,(3)").ToString());
        }

        [Test]
        public void RationalNumber_GetPeriodic()
        {
            Assert.AreEqual("0,(3)", new RationalNumber(3, 9).GetPeriodicFraction());
        }
    }
}