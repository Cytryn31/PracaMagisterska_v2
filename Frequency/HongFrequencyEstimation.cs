using System;
using System.Collections.Generic;
using System.Drawing;
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
		public double ExtractFeatures(Bitmap image, OrientationImage orientationImage)
		{
			var windowSize = BlockSize * 2;
			double sumsumsum = 0;
			int count = 0;
			ImageMatrix matrix = new ImageMatrix(image);
			byte width = Convert.ToByte(image.Width / BlockSize);
			byte height = Convert.ToByte(image.Height / BlockSize);
			OrientationImage oi = new OrientationImage(width, height, BlockSize);
			for (int row = 0; row < height; row++)
				for (int col = 0; col < width; col++)
				{
					var angle = orientationImage.IsNullBlock(row, col) ? 0 : orientationImage.AngleInRadians(row, col);
					List<int> XSignature = new List<int>();
					int x, y;
					orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
					var nVal = 0;

					for (int k = 0; k < windowSize; k++)
					{
						var sum = 0.0;
						for (int d = 0; d < BlockSize; d++)
						{
							var u = x + (d - 0.5 * BlockSize) * Math.Cos(angle) + (k - 0.5 * windowSize) * Math.Sin(angle);

							var v = y + (d - 0.5 * BlockSize) * Math.Sin(angle) + (0.5 * windowSize - k) * Math.Cos(angle);
							if (!(u < 0) && !(v < 0) && !(u >= matrix.Height) && !(v >= matrix.Width))
							{
								sum += matrix[(int)u, (int)v];
								nVal++;
							}

						}
						XSignature.Add((int)sum);
					}

					var peaks = FindPeakElementRecursion(XSignature.ToArray(),350);
					var peaksLength = peaks.Count;
					if (peaksLength > 1)
					{
						var dist = Math.Abs(peaks[0] - peaks[peaksLength - 1]);
						sumsumsum += (double)(dist / (peaksLength - 1));
						count++;
						//oi[row, col] = Convert.ToByte(Math.Round((double)(dist / (peaksLength - 1))));
					}
					else
					{
						//oi[row, col] = Convert.ToByte(Math.Round((double)(0)));
					}
					//					var divider = (double) (BlockSize*windowSize*255);
					//					var sumD = (double)XSignature.Sum();
					//					double value = sumD == 0 ? 0: (sumD/divider);
					//					oi[row, col] = Convert.ToByte(value);
				}

			return sumsumsum/count;
		}

		private static List<int> FindPeakElementRecursion(int[] num, double delta)
		{
			List<int> maxtab = new List<int>();
			List<int> mintab = new List<int>();

			int mn = int.MaxValue;
			int mx = int.MinValue;
			int mxPos = 0;
			int mnPos = 0;

			bool lookformax = true;
			for (int i = 0; i < num.Length; i++)
			{
				var value = num[i];
				if (value > mx)
				{
					mx = value;
					mxPos = i;
				}

				if (value < mn)
				{
					mn = value;
					mnPos = i;
				}

				if (lookformax)
				{
					if (value < mx - delta)
					{
						maxtab.Add(mxPos);
						mn = value;
						lookformax = false;
					}
				}
				else
				{
					if (value > mn + delta)
					{
						mintab.Add(mnPos);
						mx = value;
						lookformax = true;
					}
				}
			}
			return mintab;
		}

		private byte bSize;
	}
}
