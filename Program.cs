using System;

namespace GausMethod
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			double[,] arr1 = { {6, -1, -2, -10 }, {1, 5, 1, 10 }, {3, -1, 5, 0 } };
			double[,] arr2 = { {2, -2, -2, -8 }, {3, 5, 4, 11 }, {3, -6, 5, -10 } };

			//Gauss.Method (arr1, 3, 4);
			//Gauss.Method (arr2, 3, 4);
			Kholetskiy.Method(arr1, 3);

			//SimpleIteration.Method(arr1, 0.01);
		}
	}
}
