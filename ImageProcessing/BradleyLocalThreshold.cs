using System.Drawing;
using Accord.Imaging.Filters;

namespace PracaMagisterska_v2.ImageProcessing
{
	public class BradleyLocalThreshold
	{
		public static Bitmap Apply(Bitmap bitmap, int windowSize, float limit)
		{
			// create the filter
			BradleyLocalThresholding filter = new BradleyLocalThresholding
			{
				WindowSize = windowSize,
				PixelBrightnessDifferenceLimit = limit
			};
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			bitmap = grayscaleFilter.Apply(bitmap);
			// apply the filter
			return  filter.Apply(bitmap);
		}
	}
}
