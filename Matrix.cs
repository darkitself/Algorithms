using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public class Matrix
    {
        protected readonly List<List<double>> matrix;
        
        public Matrix(List<List<double>> matrix)
        {
            this.matrix = matrix;
        }

        public int Size => matrix.Count;
        
        public double GetDeterminant()
        {
            if (matrix.Count == 2)
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            double sum = 0;
            var sign = -1;
            for (var j = 0; j < matrix.Count; j++)
                sum += matrix[0][j] * ReduceMatrix(0, j).GetDeterminant() * (sign = -sign);
            return sum;
        }

        public Matrix CloneMatrix() => new Matrix(matrix.Select(list => new List<double>(list)).ToList());

        public Matrix ReplaceColumn(List<double> col, int n)
        {
            var matr = CloneMatrix();
            for (var i = 0; i < matr.matrix.Count; i++)
                matr.matrix[i][n] = col[i];
            return matr;
        }

        private Matrix ReduceMatrix(int i, int j) 
        {
            var matr = matrix.Select(list => new List<double>(list)).ToList();
            matr.RemoveAt(i);
            foreach (var line in matr)
                line.RemoveAt(j);
            return new Matrix(matr);
        }
    }
}