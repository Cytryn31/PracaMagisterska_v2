using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracaMagisterska_v2.Orientation;
using PracaMagisterska_v2.Utils;

namespace PracaMagisterska_v2.Frequency
{
	public class HongFrequencyEstimation
	{
		/// <summary>
		///     The block size in pixels.
		/// </summary>
		public byte BlockSize
		{
			get { return bSize; }
			set { bSize = value; }
		}

		/// <summary>
		///     Extract an orientation image from the specified bitmap image.
		/// </summary>
		/// <param name="image">The source bitmap image to extract features from.</param>
		/// <returns>The features extracted from the specified bitmap image.</returns>
		public OrientationImage ExtractFeatures(Bitmap image,OrientationImage orientationImage)
		{
			var windowSize = BlockSize*2;
			ImageMatrix matrix = new ImageMatrix(image);
			byte width = Convert.ToByte(image.Width / BlockSize);
			byte height = Convert.ToByte(image.Height / BlockSize);
			OrientationImage oi = new OrientationImage(width, height, BlockSize);
			for (int row = 0; row < height; row++)
				for (int col = 0; col < width; col++)
				{
					var angle = orientationImage.IsNullBlock(row, col) ? 0 : orientationImage.AngleInRadians(row, col);
					List<double> XSignature = new List<double>();
					int x, y;
					orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
					var nVal = 0;

					for (int k = 0; k < BlockSize; k++)
					{
						var sum = 0.0;
						for (int d = 0; d < windowSize; d++)
						{
							var u = x + (d - 0.5*BlockSize)*Math.Cos(angle) + (k - 0.5*windowSize)*Math.Sin(angle);

							var v = y + (d - 0.5*BlockSize)* Math.Sin(angle) + (0.5 - windowSize)*Math.Cos(angle);

							sum += matrix[ (int) u, (int)v];
							nVal++;
						}
						XSignature.Add(sum);
					}
//					oi[row, col] = Convert.ToByte(Math.Round(sum/ nVal));
				}
			return oi;
		}
		private byte bSize;
	}
}
