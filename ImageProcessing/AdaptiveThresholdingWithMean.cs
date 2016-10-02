using System.Drawing;
using Accord.Imaging.Filters;
using PracaMagisterska_v2.Utils;

namespace PracaMagisterska_v2.ImageProcessing
{
	class AdaptiveThresholdingWithMean
	{
		public static Bitmap Apply(Bitmap bitmap)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			bitmap = grayscaleFilter.Apply(bitmap);
			ImageMatrix matrix = new ImageMatrix(bitmap);

			var mean = matrix.Pixels.Mean();
			Threshold filter = new Threshold(mean);
			bitmap = filter.Apply(bitmap);
			// check threshold value
			return bitmap;
		}
	}
}
