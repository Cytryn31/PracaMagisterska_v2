﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace PracaMagisterska_v2.Utils
{
	public static class MatrixExtensions
	{
		public static T Mean<T>(this T[,] matrix)
		{
			var oneD = matrix.Flatten();

			int index = oneD.Length/2;
			return oneD[index];
		}

		public static double Variance(this int[,] values, double mean)
		{
			var oneD = values.Flatten();
			return oneD.Variance(mean, 0, oneD.Length());
		}


		public static double Variance(this int[] values, double mean, int start, int end)
		{
			double variance = 0;

			for (int i = start; i < end; i++)
			{
				variance += Math.Pow((values[i] - mean), 2);
			}

			int n = end - start;
			if (start > 0) n -= 1;

			return variance / (n);
		}
	}
}
