using System;

namespace GausMethod
{
	public static class Gauss
	{
		public static void Method(double[,] matrix, int row, int col)
		{
			double[] answers = new double[row]; 
			double temp = 0;
			for(int k=0; k < row; k++)
			{
				temp = matrix [k, k];
				for(int j=0; j<col; j++)
				{
					matrix [k, j] = Math.Round(matrix [k, j] / temp, 2);
				}
				for(int i=1+k; i<row; i++)
				{
					temp = matrix [i, k];
					for(int j=0; j<col; j++)
					{
						matrix [i, j] = Math.Round(matrix [i, j] - matrix [k, j]* temp,2);
					}
				}
			}
			for(int i=0; i<row; i++)
			{
				for(int j=0; j<col; j++)
				{
					Console.Write (matrix[i,j]+"\t");
				}
				Console.Write ("\n");
			}
			/*for (int i = 0; i < row; i++) {
				answers [i] = 0;
			}*/
			//обратный ход
			for(int i=row-1; i>=0; i--)
			{
				double summ = 0;
				for(int j=i+1; j<row; j++)
				{
					summ += matrix [i, j] * answers [j];
				}
				summ = matrix [i, row] - summ;
				answers[i]=summ/matrix[i,i]; 
			}
			Console.Write ("\n");
			for (int i = 0; i < row; i++) {
				Console.Write (answers[i]+"\t");
			}
		}
	}
}

