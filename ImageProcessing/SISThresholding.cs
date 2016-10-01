using System.Drawing;
using Accord.Imaging.Filters;

namespace PracaMagisterska_v2.ImageProcessing
{
	public class SISThresholding
	{
		public static Bitmap Apply(Bitmap bitmap)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			bitmap = grayscaleFilter.Apply(bitmap);
			SISThreshold filter = new SISThreshold();
			return filter.Apply(bitmap);
		}
	}
}
