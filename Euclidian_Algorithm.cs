using System.Numerics;

namespace ConsoleApp1
{
    public class Euclidian_Algorithm
    {
        public static BigInt gcdex(BigInt a, BigInt b, out BigInt x, out BigInt y) {
            if (a.Value == 0) {
                x = new BigInt(0);
                y = new BigInt(1);
                return b;
            }
            BigInt x1, y1;
            BigInt d = gcdex(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }
        
        public static BigInt ReverseElement(BigInt a, BigInt N) {
            BigInt x, y, d;
            d = gcdex(a, N, out x, out y);
            return d.Value != 1 ? null : (x % N + N) % N;
        }
    }
}