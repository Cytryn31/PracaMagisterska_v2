﻿using System;
using System.Collections.Generic;
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

		public static Image ApplyBestResponse(Image matrix, double gamma, double sigma, int ksize)
		{
			GC.Collect();
			List<ImageMatrix> processedImages = new List<ImageMatrix>();
			ImageMatrix acumm = new ImageMatrix(matrix.Width, matrix.Height);
			try
			{
				int index = 0;
				var kernels = BuildFilters(gamma, sigma, ksize);
				Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
				var grayscale = grayscaleFilter.Apply(new Bitmap(matrix));
				foreach (var gaborFilter in kernels)
				{
					var gabor = gaborFilter.Apply(grayscale);
					processedImages.Add(new ImageMatrix(gabor));
				}

				foreach (var processedImage in processedImages)
				{
					acumm = Maximum(acumm, processedImage);
				}
			}
			catch (Exception exception)
			{
				return acumm.ToBitmap();
			}
			return acumm.ToBitmap();
		}

		public static ImageMatrix Maximum(ImageMatrix first, ImageMatrix second)
		{
			for (int i = 0; i < first.Height; i++)
			{
				for (int j = 0; j < first.Width; j++)
				{
					first[i, j] = first[i, j] >= second[i, j] ? first[i, j] : second[i, j];
				}
			}
			return first;
		}

		public static Image ApplyHong(Image matrix, OrientationImage orientationImage,
			double freqImage, double gamma, double sigma, int ksize)
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
					//	var freq = freqImage[row, col];
						orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
						int maxLength = orientationImage.WindowSize / 2;
						var kernel = Gabor.Kernel2D(ksize, (freqImage), angle, 1, sigma, gamma, false);
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

		public static Image ApplyBank(Image matrix, OrientationImage orientationImage,
			double freqImage, double gamma, double sigma, int ksize)
		{
			ImageMatrix newImg = new ImageMatrix(new Bitmap(matrix));
			try
			{
				var kernels = BuildFiltersDictionary(gamma, sigma, ksize);
				for (int row = 0; row < orientationImage.Height; row++)
				{
					for (int col = 0; col < orientationImage.Width; col++)
					{
						int x, y;
						var angle = orientationImage.IsNullBlock(row, col) ? 0 : orientationImage.AngleInRadians(row, col);
					//	var freq = freqImage[row, col];
						orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);
						int maxLength = orientationImage.WindowSize / 2;
						var kernel = FindKernel(freqImage, angle, kernels);
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

		private static List<GaborFilter> BuildFilters(double gamma, double sigma, int ksize)
		{
			List<GaborFilter> kernels = new List<GaborFilter>();
			foreach (var lambda in Form1.Instance.Freqs)
			{
				foreach (var theta in Form1.Instance.Angles)
				{
					kernels.Add(new GaborFilter
					{
						Gamma = gamma,
						Lambda = lambda,
						Sigma = sigma,
						Size = ksize,
						Theta = theta
					});
				}
			}
			return kernels;
		}

		private static Dictionary<KeyValuePair<double, double>, double[,]> BuildFiltersDictionary(double gamma, double sigma, int ksize)
		{
			Dictionary<KeyValuePair<double, double>, double[,]> kernels =
				new Dictionary<KeyValuePair<double, double>, double[,]>();
			foreach (var lambda in Form1.Instance.Freqs)
			{
				foreach (var theta in Form1.Instance.Angles)
				{
					var kernel = Gabor.Kernel2D(ksize, lambda, theta, 1, sigma, gamma, false);
					kernels.Add(new KeyValuePair<double, double>(lambda, theta),kernel );
				}
			}
			return kernels;
		}

		private static double[,] FindKernel(double calculatedLambda, double angle, Dictionary<KeyValuePair<double, double>, double[,]> kernels)
		{
			var tmpLamda = 0.0;
			var tmpAngle = 0.0;
			var prevDifrencce = double.MaxValue;
			var difrence = double.MaxValue;
			var difrenceMin = double.MaxValue;
			foreach (var lambda in Form1.Instance.Freqs)
			{
				difrence = Math.Abs(lambda - calculatedLambda);
				if (difrence <= difrenceMin)
				{
					tmpLamda = lambda;
					difrenceMin = difrence;
				}
				prevDifrencce = difrence;
			}
			difrence = double.MaxValue;
			prevDifrencce = double.MaxValue;
			difrenceMin = double.MaxValue;
			foreach (var theta in Form1.Instance.Angles)
			{
				difrence = Math.Abs(theta - angle);
				if (difrence <= difrenceMin)
				{
					tmpAngle = theta;
					difrenceMin = difrence;
				}
				prevDifrencce = difrence;
			}
			return kernels[new KeyValuePair<double, double>(tmpLamda, tmpAngle)];
		}
	}
}