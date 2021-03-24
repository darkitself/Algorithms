using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3
{
    public class RationalNumber
    {
        private BigInteger numerator;
        private BigInteger denominator;
        private int sign = 1;
        private static Regex regex = new Regex("(-)?(\\d+)\\,(\\d+)?\\((\\d+)\\)", RegexOptions.Compiled);

        public RationalNumber(BigInteger numerator, BigInteger denominator)
        {
            var gcd = FindGCD(BigInteger.Abs(numerator), BigInteger.Abs(denominator));
            sign = numerator.Sign * denominator.Sign;
            this.numerator = BigInteger.Abs(numerator) / gcd;
            this.denominator = BigInteger.Abs(denominator) / gcd;
            if (this.numerator == 0)
                sign = 1;
        }

        public string GetPeriodicFraction()
        {
            var num = numerator;
            var dem = denominator;
            var res = new StringBuilder();
            var remainders = new Dictionary<BigInteger, int>();
            if (sign < 0)
                res.Append('-');
            res.Append((num / dem).ToString()).Append(',');
            num %= dem;
            var i = res.Length;
            while (!remainders.ContainsKey(num))
            {
                remainders[num % dem] = i++;
                res.Append((num * 10 / dem).ToString());
                num = (num * 10) % dem;
            }

            return res.Insert(remainders[num], '(').Append(')').ToString();
        }

        public static RationalNumber ParsePeriodicFraction(string fraction)
        {
            var result = regex.Match(fraction);
            var values = result.Groups.Values.Skip(1).Select(g => g.Value).ToArray();
            var den = new StringBuilder();

            for (var i = 0; i < values[3].Length; i++)
                den.Append('9');
            for (var i = 0; i < values[2].Length; i++)
                den.Append('0');
            
            var denominator = BigInteger.Parse(den.ToString());
            return new RationalNumber(BigInteger.Parse(values[2] + values[3]) -
                                      BigInteger.Parse(values[2] != "" ? values[2] : "0") +
                                      BigInteger.Parse(values[1]) * denominator, denominator, values[0] == "" ? 1 : -1);
        }

        public static RationalNumber operator +(RationalNumber n1, RationalNumber n2)
        {
            switch (n1.sign + n2.sign)
            {
                case 2:
                    return new RationalNumber(n1.numerator * n2.denominator + n1.denominator * n2.numerator,
                        n1.denominator * n2.denominator);
                case -2:
                    return new RationalNumber(n1.numerator * n2.denominator + n1.denominator * n2.numerator,
                        n1.denominator * n2.denominator, -1);
                default:
                    return n1.sign > 0 ? n1 - n2.Negate() : n2 - n1.Negate();
            }
        }

        public static RationalNumber operator -(RationalNumber n1, RationalNumber n2)
        {
            switch (n1.sign + n2.sign)
            {
                case 2:
                    return new RationalNumber(n1.numerator * n2.denominator - n1.denominator * n2.numerator,
                        n1.denominator * n2.denominator);
                case -2:
                    return new RationalNumber(n1.denominator * n2.numerator - n1.numerator * n2.denominator,
                        n1.denominator * n2.denominator);
                default:
                    return n1.sign > 0 ? n1 + n2.Negate() : (n1.Negate() + n2).Negate();
            }
        }

        public static RationalNumber operator *(RationalNumber n1, RationalNumber n2)
            => new RationalNumber(n1.numerator * n2.numerator, n1.denominator * n2.denominator, n1.sign * n2.sign);

        public static RationalNumber operator /(RationalNumber n1, RationalNumber n2)
            => new RationalNumber(n1.numerator * n2.denominator, n1.denominator * n2.numerator, n1.sign * n2.sign);

        public override string ToString() => numerator == 0 ? "0" : (sign > 0 ? "" : "-") + numerator + "/" + denominator;

        private RationalNumber(BigInteger numerator, BigInteger denominator, int sign)
        {
            var gcd = FindGCD(numerator, denominator);
            this.sign = sign;
            this.numerator = BigInteger.Abs(numerator) / gcd;
            this.denominator = BigInteger.Abs(denominator) / gcd;
        }

        private RationalNumber Negate() => new RationalNumber(numerator, denominator, -sign);

        private static BigInteger FindGCD(BigInteger numerator, BigInteger denominator)
        {
            while (numerator != 0 && denominator != 0)
                if (numerator > denominator)
                    numerator %= denominator;
                else
                    denominator %= numerator;

            return BigInteger.Max(numerator, denominator);
        }
    }
}