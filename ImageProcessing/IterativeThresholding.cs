using System.Drawing;
using Accord.Imaging.Filters;

namespace PracaMagisterska_v2.ImageProcessing
{
	public class IterativeThresholding
	{
		public static Bitmap Apply(Bitmap bitmap, int threshold, int minimalError)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			bitmap = grayscaleFilter.Apply(bitmap);
			// create filter
			IterativeThreshold filter = new IterativeThreshold(minimalError, threshold);
			// apply the filter
			return filter.Apply(bitmap);
		}
	}
}
