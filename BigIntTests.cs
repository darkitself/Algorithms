using NUnit.Framework;

namespace ConsoleApp1
{
    public class BigIntTests
    {
        [TestCase("256", "256", true)]
        [TestCase("256", "26", false)]
        [TestCase("256", "-26", false)]
        public void CorrectEqual(string value1, string value2, bool isEqual)
        {
            Assert.AreEqual(isEqual, (new BigInt(value1)) == (new BigInt(value2)));
        }

        [TestCase("256", "256", false)]
        [TestCase("256", "26", true)]
        [TestCase("-256", "-256", false)]
        [TestCase("-26", "-256", true)]
        [TestCase("26", "-256", true)]
        public void CorrectCompare_GreaterThan(string value1, string value2, bool isEqual)
        {
            Assert.AreEqual(isEqual, new BigInt(value1) > new BigInt(value2));
        }

        [TestCase("264", "264", false)]
        [TestCase("25", "26", true)]
        [TestCase("-256", "-256", false)]
        [TestCase("-257", "-256", true)]
        [TestCase("-26", "26", true)]
        public void CorrectCompare_LessThan(string value1, string value2, bool isEqual)
        {
            Assert.AreEqual(isEqual, new BigInt(value1) < new BigInt(value2));
        }

        [TestCase("847", "178", "1025")]
        [TestCase("-847", "-178", "-1025")]
        [TestCase("-95841", "177478", "81637")]
        [TestCase("17747984891984498489498489", "-41949818749849848949840984", "-24201833857865350460342495")]
        public void AdditionTest(string value1, string value2, string expectedValue)
        {
            var number1 = new BigInt(value1);
            var number2 = new BigInt(value2);

            var actual = number1 + number2;

            Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
        }
        
        [TestCase("847", "178", "669")]
        [TestCase("-177478", "95841", "-273319")]
        [TestCase("95841", "-177478", "273319")]
        [TestCase("-847", "-178", "-669")]
        [TestCase("-17747984891984498489498489", "-41949818749849848949840984", "24201833857865350460342495")]
        public void SubtractionTest(string value1, string value2, string expectedValue)
        {
            var actual = new BigInt(value1) - new BigInt(value2);

            Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
        }

        [TestCase("847", "178", "150766")]
        [TestCase("-1478", "-95841", "141652998")]
        [TestCase("-177478", "15841", "-2811428998")]
        [TestCase("17747984891984498489498489", "-41949818749849848949840984",
            "-744524749393823160874372569351363330891430458273176")]
        public void MultiplicationTest(string value1, string value2, string expectedValue)
        {
            var actual = new BigInt(value1) * new BigInt(value2);

            Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
        }

        [TestCase("847", "178", "4")]
        [TestCase("-1478", "-95841", "0")]
        [TestCase("177478", "-15841", "-11")]
        [TestCase("17747984891984498489498489", "188840984", "93983755623644168")]
        public void DivisionTest(string value1, string value2, string expectedValue)
        {
            var actual = new BigInt(value1) / new BigInt(value2);

            Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
        }

        [TestCase("847", "178", "135")]
        [TestCase("-1478", "-95841", "-1478")]
        [TestCase("177478", "-15841", "3227")]
        [TestCase("17747984891984498489498489", "188840984", "138517177")]
        public void ModuloTest(string value1, string value2, string expectedValue)
        {
            var actual = new BigInt(value1) % new BigInt(value2);

            Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
        }

        [TestCase("7", "13", "2")]
        [TestCase("8948456163", "8942", "1605")]
        public void ReverseElementInModuloTest(string value, string modulo, string expectedValue)
        {
            var actual = Euclidian_Algorithm.ReverseElement(new BigInt(value), new BigInt(modulo));

            Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
        }
    }
}