using System.Drawing;
using Accord.Imaging.Filters;

namespace PracaMagisterska_v2.ImageProcessing
{
	public class OtsuThresholding
	{
		public static Bitmap Apply(Bitmap bitmap)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			bitmap = grayscaleFilter.Apply(bitmap);
			OtsuThreshold filter = new OtsuThreshold();
			bitmap = filter.Apply(bitmap);
			// check threshold value
			return bitmap;
		}
	}
}
