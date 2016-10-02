using System;
using System.Drawing;
using PracaMagisterska_v2.Utils;

namespace PracaMagisterska_v2.ImageProcessing
{
	class ImageNormalizator
	{
		public static Bitmap Normalize(Bitmap bitmap, double mean0, double variance0)
		{
			ImageMatrix matrix = new ImageMatrix(bitmap);

			var mean = matrix.Pixels.Mean();
			var variance = matrix.Pixels.Variance(mean);

			for (int i = 0; i < matrix.Height; i++)
			{
				for (int j = 0; j < matrix.Width; j++)
				{
					if (matrix[i, j] > mean)
						matrix[i, j] = (int)(mean0 + Math.Sqrt(variance0 * Math.Pow(matrix[i, j] - mean, 2) / variance));
					else
						matrix[i, j] = (int) (mean0 - Math.Sqrt(variance0 * Math.Pow(matrix[i, j] - mean, 2)/ variance));
				}
			}
			return matrix.ToBitmap();
		}
	}
}
