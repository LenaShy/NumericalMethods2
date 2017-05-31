using System;

namespace GausMethod
{
	public class SimpleIteration
	{
		public class Matrix
		        {
			            public double[,] matrix;
			            public Matrix(int n, int m)
			            {
				                matrix = new double[n,m];
				                for (int i = 0; i < n; i++) 
					                {
					                    for(int j=0; j < m;j++)
						                    {
						                        matrix [i, j] = 0;
						                    }
					                }
				            }
			            public Matrix(double[] vector)
			            {
				                this.matrix = new double[vector.Length,1];
				                for(int i=0; i<vector.Length; i++)
					                {
					                    this.matrix[i,1]=vector[i];
					                }
				            }
			            public Matrix(double[,] matrix)
			            {
				                this.matrix = matrix;
				            }

			            public static Matrix operator*(Matrix left, Matrix right)
			            {
				                Matrix result = new Matrix(right.matrix.GetLength(0),right.matrix.GetLength(1));
				                for (int i = 0; i < right.matrix.GetLength(0); i++) {
					                    for(int j=0; j < right.matrix.GetLength(1);j++){
						                        for (int k = 0; k < right.matrix.GetLength(0); k++) {
							                            result.matrix [i, j] += left.matrix [i, k] * right.matrix [k, j]; 
							                        }    
						                    }
					                }
				                return result;
				            }
			            public static Matrix operator*(Matrix matrix, double number)
			            {
				                for (int i = 0; i < matrix.matrix.GetLength(0); i++) {
					                    for(int j=0; j < matrix.matrix.GetLength(1);j++){
						                        matrix.matrix [i, j] = matrix.matrix [i, j] * number; 
						                    }
					                }
				                return matrix;
				            }
			            public static Matrix operator+(Matrix left, Matrix right)
			            {
				                for (int i = 0; i < left.matrix.GetLength(0); i++) {
					                    for(int j=0; j < left.matrix.GetLength(0);j++){
						                        left.matrix [i, j] = left.matrix [i, j] + right.matrix [i, j]; 
						                    }
					                }
				                return left;
				            }
			            public static Matrix operator-(Matrix left, Matrix right)
			            {
				                for (int i = 0; i < left.matrix.GetLength(0); i++) {
					                    for(int j=0; j < left.matrix.GetLength(0);j++){
						                        left.matrix [i, j] = left.matrix [i, j] - right.matrix [i, j]; 
						                    }
					                }
				                return left;
				            }

			        }
		        public static void Method(double[,] matrix, double epsilon)
		        {
			            Matrix myMatrix = new Matrix (matrix);
			            double alpha = 1 / CountNorm(Transpose (myMatrix) * myMatrix);
			            Matrix bMatrix = E (matrix.GetLength(0)) - Transpose (myMatrix) * myMatrix * alpha;
			            Matrix g = Transpose (myMatrix) * alpha * F (myMatrix);


			            Console.WriteLine (alpha);

			            Matrix xPrev;
			            Matrix xCur= new Matrix (matrix.GetLength(0),matrix.GetLength(0));
			            while((CountNorm(bMatrix) < 1 && CountNorm(bMatrix) > 0.5 && CountNorm(bMatrix)*CountNorm(xCur - xPrev)/(1-CountNorm(bMatrix))<epsilon)
				            {
					                    xPrev = xCur;
					                    xCur = 
						            }
				        }
				        public static Matrix Transpose(Matrix matrix)
				        {
					            Matrix helpMatrix = new Matrix(matrix.matrix.GetLength(0),matrix.matrix.GetLength(0));
					            for (int i = 0; i < matrix.matrix.GetLength(0); i++) {
						                for(int j=0; j < matrix.matrix.GetLength(0);j++){
							                    helpMatrix.matrix [j, i] = matrix.matrix [i, j];
							                }
						            }
					            return helpMatrix;
					        }

				        public static double CountNorm(Matrix matrix)
				        {
					            double matrixNorm = 0;
					            double summ = 0;
					            for(int i=0; i<matrix.matrix.GetLength(0);i++)
						            {
						                summ = 0;
						                for(int j=0; j < matrix.matrix.GetLength(0);j++){
							                    summ += matrix.matrix[i,j];
							                }
						                if (summ > matrixNorm)
							                    matrixNorm = summ;
						            }
					            return matrixNorm;
					        }
				        public static Matrix E(int n)
				        {
					            double[,] Ematrix = new double[n, n];
					            for(int i=0; i<n;i++)
						            {
						                for(int j=0; j < n;j++){
							                    Ematrix[i, j] = 0;
							                }
						                Ematrix [i, i] = 1;
						            }
					            Matrix E = new Matrix (Ematrix);
					            return E;
					        }
				        public static Matrix F(Matrix matrix)
				        {
					            double[] f = new double[matrix.matrix.GetLength(0)];
					            for (int i = 0; i < matrix.matrix.GetLength(0); i++) {
						                f [i] = matrix.matrix [i, matrix.matrix.GetLength(0) - 1];
						            }
					            Matrix fMatrix = new Matrix (f);
					            return fMatrix;
					        }
				    } 
	}
}


