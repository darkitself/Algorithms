using System.Text;
using NUnit.Framework;

namespace ConsoleApp1
{
    public class RSATests
    {
        [TestCase("hello", "3557", "2579")]
        [TestCase("hello again", "5037569", "5810011")]
        public void CorrectDecode(string value, string pIn, string qIn)
        {
            var p = new BigInt(pIn);
            var q = new BigInt(qIn);
            var keys = RSA.CreateKeys(p, q);
            var enc = RSA.Encrypt(Encoding.UTF8.GetBytes(value), keys[0].Item1, keys[0].Item2);
            var dec = Encoding.UTF8.GetString(RSA.Decrypt(enc, keys[1].Item1, keys[1].Item2));
            Assert.AreEqual(value, dec);
        }
    }
}