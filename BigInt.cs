using System.Numerics;

namespace ConsoleApp1
{
    public class BigInt
    {
        private BigInteger number;
        public BigInteger Value => number;

        private BigInt()
        {
        }

        public bool isSimple()
        {
            for (var i = new BigInteger(2); i < number/ 2 + 1; i++)
                if (number % i == 0)
                    return false;
            return true;
        }

        public BigInt(BigInteger number) => this.number = number;
        public BigInt(string number)=>this.number = BigInteger.Parse(number);
        public BigInt(long number) => this.number = new BigInteger(number);
        
        public static BigInt operator +(BigInt b1, BigInt b2) => new() { number = b1.Value + b2.Value };
        public static BigInt operator -(BigInt b1, BigInt b2) => new() { number = b1.Value - b2.Value };
        public static BigInt operator *(BigInt b1, BigInt b2) => new() { number = b1.Value * b2.Value };
        public static BigInt operator /(BigInt b1, BigInt b2) => new() { number = b1.Value / b2.Value };
        public static BigInt operator %(BigInt b1, BigInt b2) => new() { number = b1.Value % b2.Value };
        
        public static bool operator >(BigInt b1, BigInt b2) => b1.Value > b2.Value;
        public static bool operator <(BigInt b1, BigInt b2) => b1.Value < b2.Value;
        public static bool operator >=(BigInt b1, BigInt b2) => b1.Value >= b2.Value;
        public static bool operator <=(BigInt b1, BigInt b2) => b1.Value <= b2.Value;
        public static bool operator ==(BigInt b1, BigInt b2) => b1 != null && b2 != null && b1.Value == b2.Value;
        public static bool operator !=(BigInt b1, BigInt b2) => b1 != null && b2 != null && b1.Value != b2.Value;
    }
}