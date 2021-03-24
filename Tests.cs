using System.Collections.Generic;
using NUnit.Framework;

namespace Lab4
{
    public class Tests
    {
        [Test]
        public void MatrixDeterminantTest()
        {
                Assert.AreEqual(2.0, new Matrix(new List<List<double>>
                {
                    new List<double> {2, 2, -1, 1},
                    new List<double> {4, 3, -1, 2},
                    new List<double> {8, 5, -3, 4},
                    new List<double> {3, 3, -2, 2},
                }).GetDeterminant());
        }
        [Test]
        public void RedhefferDeterminantEqualToCommonDeterminantTest()
        {
            var matr = RedhefferMatrix.GenerateRedhefferMatrix(10);
            Assert.AreEqual(matr.GetDeterminant(), matr.GetRedhefferMatrixDeterminant());
        }
        
        [Test]
        public void CramerSolverTest()
        {
            var res = CramerSolver.SolveSystem(new Matrix(new List<List<double>>
            {
                new List<double> {2, 2, -1, 1},
                new List<double> {4, 3, -1, 2},
                new List<double> {8, 5, -3, 4},
                new List<double> {3, 3, -2, 2},
            }), new List<double> {4, 6, 12, 6});
            Assert.AreEqual(new List<double> {1.0d, 1.0d, -1.0d, -1.0d}, res);
        }
        
        [Test]
        public void CramerSolverReturnNullTest()
        {
            var res = CramerSolver.SolveSystem(new Matrix(new List<List<double>>
            {
                new List<double> {0, 2, -1, 1},
                new List<double> {0, 3, -1, 2},
                new List<double> {0, 5, -3, 4},
                new List<double> {0, 3, -2, 2},
            }), new List<double> {4, 6, 12, 6});
            Assert.AreEqual(null, res);
        }
    }
}