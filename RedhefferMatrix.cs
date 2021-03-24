using System.Collections.Generic;

namespace Lab4
{
    public class RedhefferMatrix : Matrix
    {
        private RedhefferMatrix(List<List<double>> matrix) : base(matrix)
        {
        }

        public static RedhefferMatrix GenerateRedhefferMatrix(int size)
        {
            var matrix = new List<List<double>>();
            
            for (var i = 0; i < size; i++)
            {
                matrix.Add(new List<double>());
                for (var j = 0; j < size; j++)
                    if (j == 0 || (j + 1) % (i + 1) == 0)
                        matrix[i].Add(1);
                    else
                        matrix[i].Add(0);
            }

            return new RedhefferMatrix(matrix);
        }

        public long GetRedhefferMatrixDeterminant()
        {
            long sum = 0;
            for (var i = 0; i < matrix.Count; i++)
            {
                sum += GetMoebiusFunctionValue(i + 1);
            }

            return sum;
        }

        public static long GetMoebiusFunctionValue(int n)
        {
            if (n == 1)
                return 1;
            var nums = new HashSet<int>();
            var div = 2;
            while (n != 1)
            {
                if (n % div != 0)
                {
                    div++;
                    continue;
                }
                n /= div;
                if (nums.Contains(div))
                    return 0;
                nums.Add(div);
            }

            return nums.Count % 2 == 0 ? 1 : -1;
        }
    }
}