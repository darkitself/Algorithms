using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    public static class RSA
    {
        public static List<Tuple<BigInt, BigInt>> CreateKeys(BigInt p, BigInt q)
        {
            var n = p * q;
            var f = new BigInt((p.Value - 1) * (q.Value - 1));
            var d = GetPrivateExponent(f);
            var e = Euclidian_Algorithm.ReverseElement(d, f);
            return new List<Tuple<BigInt, BigInt>> {new(e, n), new(d, n)};
        }

        private static BigInt GetPrivateExponent(BigInt f)
        {
            var d = new BigInt(17);
            while (true)
            {
                if (BigInteger.GreatestCommonDivisor(d.Value, f.Value) == 1)
                    return d;
                d = d + new BigInt(1);
            }
        }

        public static byte[] Encrypt(byte[] data, BigInt e, BigInt n)
            => data.Select(d => BigInteger.ModPow(d, e.Value, n.Value).ToByteArray())
                .Select(b =>
                {
                    var l = n.Value.ToByteArray().Length;
                    var t = new LinkedList<byte>(b);
                    if (b.Length >= l) return t.ToArray();
                    for (var i = 0; i < l - b.Length; i++)
                        t.AddFirst(0);
                    return t.ToArray();
                }).SelectMany(s => s).ToArray();

        public static byte[] Decrypt(byte[] data, BigInt d, BigInt n)
            => data.Select((value, index) => new {Value = value, Index = index})
                .GroupBy(p => p.Index / n.Value.ToByteArray().Length)
                .Select(g => g.SkipWhile(v => v.Value == 0))
                .Select(v => v.Select(b => b.Value).ToArray())
                .Select(b => BigInteger.ModPow(new BigInteger(b), d.Value, n.Value))
                .Select(num => byte.Parse(num.ToString())).ToArray();

        public static void CryptFile(string filePathInput, string filePathOutput, BigInt e, BigInt n, Func<byte[], BigInt, BigInt, byte[]> fileAction)
            => File.WriteAllBytes(filePathOutput, fileAction(File.ReadAllBytes(filePathInput), e, n));
    }
}