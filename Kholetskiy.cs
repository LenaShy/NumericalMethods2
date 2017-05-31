using System;

namespace GausMethod
{
	public static class Kholetskiy
	{
		public static void Method(double[,] matrix, int n)
		{
			double[,] matrixL = new double[n, n];
			double[,] matrixR = new double[n, n];
			double[] Y = new double[n]; 
			double[] X = new double[n]; 

			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					matrixL [i, j] = 0;
					matrixR [i, j] = 0;
				}
				matrixR [i, i] = 1;
			}
			double summ = 0;
			for (int i = 0; i < n; i++) {				
				for (int j = i; j < n; j++) {
					summ = 0;
					for (int k = 0; k < i; k++) {
						summ += matrixL [j, k] * matrixR [k, i];
					}
					matrixL [j, i] = Math.Round(matrix [j, i] - summ,2);

				}

				for (int j = i; j < n; j++) {
					summ = 0;
					for (int k = 0; k < i; k++) {
						summ += matrixL [i, k] * matrixR [k, j];
					}

					matrixR [i, j] = Math.Round((matrix [i, j] - summ)/matrixL[i,i],2);
				}
			}

			for(int i=0;i<n; i++)
			{
				double sum = 0;
				for(int j=0; j<i; j++)
				{
					sum += matrixL [i, j] * Y [j];
				}
				sum = matrix [i, n] - sum;
				Y[i]= Math.Round(sum/matrixL[i,i],2); 
			}
		
			for(int i=n-1; i>0; i--)
			{
				double sum = 0;
				for(int j=i+1; j<n; j++)
				{
					sum += matrixR [i, j] * X [j];
				}
				sum = Y [i] - sum;
				X[i]=sum/matrixR[i,i]; 
			}

			for(int i=0;i<n; i++)
			{
				for(int j=0; j<n; j++)
				{
					Console.Write (matrixL[i,j]+"\t");
				}
				Console.Write ("\n");
			}
			Console.Write ("\n");
			for(int i=0; i<n; i++)
			{
				Console.Write(X[i]+"\t");
			}

		}
	}
}

