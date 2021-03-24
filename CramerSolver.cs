using System.Collections.Generic;

namespace Lab4
{
    public class CramerSolver
    {
        public static List<double> SolveSystem(Matrix system, List<double> columnVector)
        {
            var det = system.GetDeterminant();
            if (det == 0)
                return null;
            var results = new List<double>();
            for (var i = 0; i < system.Size; i++)
                results.Add(system.ReplaceColumn(columnVector, i).GetDeterminant() / det);
            return results;
        }
    }
}