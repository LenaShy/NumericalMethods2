using System;

namespace GausMethod
{
	public class SimpleIteration
	{
		public static void Method(Matrix matrix, Matrix f, double epsilon)
		{
			int count = 0;

			double alpha = 1 / (matrix.Transposed()*matrix).FirstNorm;
			alpha = 0.01;
			Matrix bMatrix = Matrix.UnaryMatrix(matrix.ColumnsCount) - alpha * matrix.Transposed()*matrix;
			Matrix g = alpha * matrix.Transposed() * f;

			Matrix xPrev;
			Matrix xCur= new double [matrix.ColumnsCount];

			do {
				xPrev = xCur;
				xCur = bMatrix * xPrev + g;
				++count;
			} while(!(bMatrix.FirstNorm < 1 && bMatrix.FirstNorm > 0.5 && bMatrix.FirstNorm * (xCur - xPrev).FirstNorm / (1 - bMatrix.FirstNorm) < epsilon));
			for (int i = 0; i < xCur.RowsCount; i++) {
				Console.Write (xCur [i,0] + "\t");
			}
		}
	}
}


