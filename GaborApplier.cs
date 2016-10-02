using System;
using System.Drawing;
using Accord.Imaging.Filters;
using Accord.Math;
using PracaMagisterska_v2.Orientation;
using PracaMagisterska_v2.Utils;

namespace PracaMagisterska_v2
{
	public class GaborApplier
	{
		static int apply_kernel_at(ImageMatrix imageMatrix, double[,] kernel, int i, int j)
		{
			var result = 0.0;
			for (int k = 0; k < kernel.GetLength(0); k++)
			{

				for (int l = 0; l < kernel.GetLength(1); l++)
				{
					if (i + l >= imageMatrix.Width)
					{
						break;
					}
					if (j + k >= imageMatrix.Height)
					{
						return (int)result;
					}
					var pixel = imageMatrix[j + k, i + l];
					result += pixel * kernel[k, l];

				}
			}
			return (int)result;
		}

		public static Image ApplyBank(Image matrix, double gamma, double sigma, int ksize)
		{

			ImageMatrix newImg = new ImageMatrix(new Bitmap(matrix));
			try
			{
				for (int row = 0; row < orientationImage.Height; row++)
				{
					for (int col = 0; col < orientationImage.Width; col++)
					{
						int x, y;
						var angle = orientationImage.IsNullBlock(row, col) ? 0 : orientationImage.AngleInRadians(row, col);
						var freq = freqImage[row, col];
						orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
						int maxLength = orientationImage.WindowSize / 2;
						var kernel = Gabor.Kernel2D(ksize, (20), angle, 1, sigma, gamma, false);

						for (int xi = x - maxLength; xi < x + maxLength; xi++)
						{
							for (int yi = y - maxLength; yi < y + maxLength; yi++)
							{
								newImg[yi, xi] = apply_kernel_at(newImg, kernel, xi, yi);
							}
						}

					}
				}
			}
			catch (Exception exception)
			{
				return newImg.ToBitmap();
			}
			return newImg.ToBitmap();
		}

		public static Image ApplyHong(Image matrix, OrientationImage orientationImage,
			 OrientationImage freqImage, double gamma, double sigma, int ksize)
		{

			ImageMatrix newImg = new ImageMatrix(new Bitmap(matrix));
			try
			{
				for (int row = 0; row < orientationImage.Height; row++)
				{
					for (int col = 0; col < orientationImage.Width; col++)
					{
						int x, y;
						var angle = orientationImage.IsNullBlock(row, col) ? 0 : orientationImage.AngleInRadians(row, col);
						var freq = freqImage[row, col];
						orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
						int maxLength = orientationImage.WindowSize / 2;
						var kernel = Gabor.Kernel2D(ksize,(20) , angle, 1, sigma, gamma, false);

						for (int xi = x - maxLength; xi < x + maxLength; xi++)
						{
							for (int yi = y - maxLength; yi < y + maxLength; yi++)
							{
								newImg[yi, xi] = apply_kernel_at(newImg, kernel, xi, yi);
							}
						}

					}
				}
			}
			catch (Exception exception)
			{
				return newImg.ToBitmap();
			}
			return newImg.ToBitmap();
		}
	}
}
