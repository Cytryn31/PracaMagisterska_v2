using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Imaging.Filters;
//using Accord.Imaging.Filters;
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


		static double[,] kernel_from_function(int size, Func<int, int, double> f)
		{

			double[,] kernel = new double[size, size];
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					kernel[i, j] = (f(i - size / 2, j - size / 2));
				}
			}
			return kernel;
		}
		public static Image Apply(Image matrix, OrientationImage orientationImage, double gamma, double sigma, int ksize)
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
						orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
						int maxLength = orientationImage.WindowSize / 2;
						var kernel = Gabor.Kernel2D(ksize, 20, angle, 1, sigma, gamma, false);

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

		public static int[] GetArgbValues(Color c)
		{
			int[] Argb = { (int)c.R, (int)c.G, (int)c.B };
			return Argb;
		}

		static Bitmap CropImage(int x, int y, Bitmap originalImage, int window)
		{
			Bitmap newImg = new Bitmap(window, window, originalImage.PixelFormat);
			for (int i = 0; i < newImg.Height; i++)
			{
				for (int j = 0; j < newImg.Width; j++)
				{
					newImg.SetPixel(j, i, originalImage.GetPixel(x + j, y + i));
				}
			}
			var grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			var grey = grayscaleFilter.Apply(newImg);
			//			using (Form form = new Form())
			//			{
			//
			//				form.StartPosition = FormStartPosition.CenterScreen;
			//				form.Size = grey.Size;
			//
			//				PictureBox pb = new PictureBox();
			//				pb.Dock = DockStyle.Fill;
			//				pb.Image = grey;
			//
			//				form.WindowState = FormWindowState.Maximized;
			//				form.Controls.Add(pb);
			//				form.ShowDialog();
			//			}
			return grey;
		}

		public static Image RepleaceArea(Image fragment, Image refImage, Rectangle cropArea)
		{
			Bitmap bmpRef = new Bitmap(refImage);
			Bitmap bmpFrag = new Bitmap(fragment);
			for (int i = 0; i < cropArea.Height; i++)
			{
				for (int j = 0; j < cropArea.Width; j++)
				{
					bmpRef.SetPixel(cropArea.Y + i, cropArea.X + j, bmpFrag.GetPixel(i, j));
				}
			}
			return bmpRef;
		}

		public static GaborFilter ReconfGabor(GaborFilter gaborFilter, double theta, double lambda)
		{
			gaborFilter.Theta = theta;
			gaborFilter.Lambda = lambda;
			return gaborFilter;
		}
	}
}
