using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging.Filters;

namespace PracaMagisterska_v2.ImageProcessing
{
	public class BasicThresholding
	{
		public static Bitmap Apply(Bitmap bitmap, int threshold)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			bitmap = grayscaleFilter.Apply(bitmap);
			Threshold filter = new Threshold(threshold);
			bitmap = filter.Apply(bitmap);
			// check threshold value
			return bitmap;
		}
	}
}
