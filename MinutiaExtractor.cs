using System;
using System.Collections.Generic;
using System.Drawing;
using PracaMagisterska_v2.Orientation;
using PracaMagisterska_v2.Utils;

namespace PracaMagisterska_v2
{
	class MinutiaExtractor
	{
		public static List<Minutia> GetMinutiaes(Bitmap bitmap, OrientationImage orientationImage, 
			bool removeFalseMinutia, double nearDistance, double brokenRidgeDistance, double spikeDistance)
		{
			ImageMatrix matrix = new ImageMatrix(bitmap);
			List<Minutia> minutiaes = new List<Minutia>();

			for (int row = 1; row < orientationImage.Height - 1; row++)
				for (int col = 1; col < orientationImage.Width - 1; col++)
					if (!orientationImage.IsNullBlock(row, col))
					{

						int x, y;
						orientationImage.GetPixelCoordFromBlock(row, col, out x, out y);

						int maxLength = orientationImage.WindowSize / 2;

						for (int xi = x - maxLength; xi < x + maxLength; xi++)
							for (int yi = y - maxLength; yi < y + maxLength; yi++)
								if (xi > 0 && xi < matrix.Width - 1 && yi > 0 && yi < matrix.Height - 1)
								{
									if (matrix[yi, xi] == 0)
									{
										List<int> values = new List<int>
															   {
																   matrix[yi, xi + 1] == 255 ? 0 : 1,
																   matrix[yi - 1, xi + 1] == 255 ? 0 : 1,
																   matrix[yi - 1, xi] == 255 ? 0 : 1,
																   matrix[yi - 1, xi - 1] == 255 ? 0 : 1,
																   matrix[yi, xi - 1] == 255 ? 0 : 1,
																   matrix[yi + 1, xi - 1] == 255 ? 0 : 1,
																   matrix[yi + 1, xi] == 255 ? 0 : 1,
																   matrix[yi + 1, xi + 1] == 255 ? 0 : 1

															   };

										int cn = 0;
										for (int i = 0; i < values.Count; i++)
										{
											int idx = i;
											if (i == 7)
												idx = -1;
											cn += Math.Abs(values[i] - values[idx + 1]);
										}
										cn = (int)(cn * 0.5);


										double angleminu;
										// end minutiae
										if (cn == 1)
										{
											angleminu = GetMinutiaeAngle(matrix, xi, yi, MinutiaType.End);
											if (angleminu != -1)
												minutiaes.Add(new Minutia
												{
													Angle = (float)angleminu,
													X = (short)xi,
													Y = (short)yi,
													MinutiaType = MinutiaType.End
												}
													);
										}
										//bifurcation minutiae
										if (cn == 3)
										{
											angleminu = GetMinutiaeAngle(matrix, xi, yi, MinutiaType.Bifurcation);
											if (!double.IsNaN(angleminu) && angleminu != -1)
												minutiaes.Add(new Minutia
												{
													Angle = (float)angleminu,
													X = (short)xi,
													Y = (short)yi,
													MinutiaType = MinutiaType.Bifurcation
												}
													);
										}
									}
								}
					}

			if (removeFalseMinutia)
			{
				List<Minutia> noInTheBorder = new List<Minutia>();

				for (int i = 0; i < minutiaes.Count; i++)
				{
					// boundary Effects (foreground areas)
					int row, col;
					orientationImage.GetBlockCoordFromPixel(minutiaes[i].X, minutiaes[i].Y, out row, out col);
					if (row >= 1 && col >= 1 && col < orientationImage.Width - 1 && row < orientationImage.Height - 1)
						if (!
							(orientationImage.IsNullBlock(row - 1, col) ||
							 orientationImage.IsNullBlock(row + 1, col) ||
							 orientationImage.IsNullBlock(row, col - 1) ||
							 orientationImage.IsNullBlock(row, col + 1) //||
							)
						)
							noInTheBorder.Add(minutiaes[i]);

				}

				bool[] toErase = new bool[noInTheBorder.Count];
				for (int i = 0; i < noInTheBorder.Count; i++)
				{
					Minutia mA = noInTheBorder[i];
					for (int j = 0; j < noInTheBorder.Count; j++)
					{
						if (i != j)
						{
							Minutia mB = noInTheBorder[j];
							// different to orientation image
							int row, col;
							orientationImage.GetBlockCoordFromPixel(mA.X, mA.Y, out row, out col);
							double angleOI = orientationImage.AngleInRadians(row, col);
							if (mA.MinutiaType == MinutiaType.End &&
								Math.Min(Angle.DifferencePi(mA.Angle, angleOI),
									Angle.DifferencePi(mA.Angle, angleOI + Math.PI)) > Math.PI / 6)
								toErase[i] = true;

							//  near minutiaes elimination
							if (mA.MinutiaType == mB.MinutiaType &&
								Distance(mA, mB) < nearDistance)
								toErase[i] = toErase[j] = true;

							//  Ridge break elimination (Ratha)
							if (mA.MinutiaType == MinutiaType.End &&
								mB.MinutiaType == MinutiaType.End &&
								mA.Angle == mB.Angle &&
								Distance(mA, mB) < brokenRidgeDistance)
								toErase[i] = toErase[j] = true;

							// Ridge break elimination (tavo - migue)
							if (mA.MinutiaType == MinutiaType.End &&
								mB.MinutiaType == MinutiaType.End &&
								Angle.DifferencePi(mA.Angle, mB.Angle) < Math.PI / 12 &&
								Distance(mA, mB) < brokenRidgeDistance)
								toErase[i] = toErase[j] = true;

							// spike elimination
							if (mA.MinutiaType == MinutiaType.End &&
								mB.MinutiaType == MinutiaType.Bifurcation &&
								Distance(mA, mB) < spikeDistance)
								if (RemoveSpikeOnMinutiae(matrix, mA, mB))
									toErase[i] = true;
						}

					}
				}

				List<Minutia> result = new List<Minutia>();
				for (int i = 0; i < noInTheBorder.Count; i++)
					if (!toErase[i])
						result.Add(noInTheBorder[i]);
				return result;
			}
				return minutiaes;
		}

		private static double GetMinutiaeAngle(ImageMatrix matrix, int x, int y, MinutiaType type)
		{
			double angle = 0;

			if (type == MinutiaType.End)
			{
				List<Point> points = new List<Point> { new Point(x, y) };
				for (int i = 0; i < 10; i++)
				{
					List<Point> neighbors = GetNeighboors(matrix, points[points.Count - 1].X, points[points.Count - 1].Y);
					foreach (var neighbor in neighbors)
						if (!points.Contains(neighbor))
							points.Add(neighbor);
				}
				if (points.Count < 10)
					return -1;
				angle = Angle.ComputeAngle(points[points.Count - 1].X - points[0].X,
										   points[points.Count - 1].Y - points[0].Y);
			}

			if (type == MinutiaType.Bifurcation)
			{
				List<Point> treeNeighboors = GetNeighboors(matrix, x, y);

				if (treeNeighboors.Count < 3)
					return double.NaN;

				List<Point> n1 = new List<Point> { new Point(x, y), treeNeighboors[0] };
				List<Point> n2 = new List<Point> { new Point(x, y), treeNeighboors[1] };
				List<Point> n3 = new List<Point> { new Point(x, y), treeNeighboors[2] };

				for (int i = 0; i < 10; i++)
				{
					List<Point> neighboors1 = GetNeighboors(matrix, n1[n1.Count - 1].X, n1[n1.Count - 1].Y);
					foreach (var neighbor in neighboors1)
						if (!n1.Contains(neighbor) && !treeNeighboors.Contains(neighbor))
							n1.Add(neighbor);

					List<Point> neighboors2 = GetNeighboors(matrix, n2[n2.Count - 1].X, n2[n2.Count - 1].Y);
					foreach (var neighbor in neighboors2)
						if (!n2.Contains(neighbor) && !treeNeighboors.Contains(neighbor))
							n2.Add(neighbor);

					List<Point> neighboors3 = GetNeighboors(matrix, n3[n3.Count - 1].X, n3[n3.Count - 1].Y);
					foreach (var neighbor in neighboors3)
						if (!n3.Contains(neighbor) && !treeNeighboors.Contains(neighbor))
							n3.Add(neighbor);
				}

				if (n1.Count < 10 || n2.Count < 10 || n3.Count < 10)
					return -1;

				double angleNeighboors1 = Angle.ComputeAngle(n1[n1.Count - 1].X - n1[0].X, n1[n1.Count - 1].Y - n1[0].Y);
				double angleNeighboors2 = Angle.ComputeAngle(n2[n2.Count - 1].X - n2[0].X, n2[n2.Count - 1].Y - n2[0].Y);
				double angleNeighboors3 = Angle.ComputeAngle(n3[n3.Count - 1].X - n3[0].X, n3[n3.Count - 1].Y - n3[0].Y);

				double diff1 = Angle.DifferencePi(angleNeighboors1, angleNeighboors2);
				double diff2 = Angle.DifferencePi(angleNeighboors1, angleNeighboors3);
				double diff3 = Angle.DifferencePi(angleNeighboors2, angleNeighboors3);

				if (diff1 <= diff2 && diff1 <= diff3)
				{
					angle = angleNeighboors2 + diff1 / 2;
					if (angle > 2 * Math.PI)
						angle -= 2 * Math.PI;
				}
				else if (diff2 <= diff1 && diff2 <= diff3)
				{
					angle = angleNeighboors1 + diff2 / 2;
					if (angle > 2 * Math.PI)
						angle -= 2 * Math.PI;
				}
				else
				{
					angle = angleNeighboors3 + diff3 / 2;
					if (angle > 2 * Math.PI)
						angle -= 2 * Math.PI;
				}
			}

			return angle;
		}

		private static List<Point> GetNeighboors(ImageMatrix matrix, int x, int y)
		{
			List<Point> result = new List<Point>();

			if (matrix[y, x + 1] == 0)
				result.Add(new Point(x + 1, y));
			if (matrix[y - 1, x + 1] == 0)
				result.Add(new Point(x + 1, y - 1));
			if (matrix[y - 1, x] == 0)
				result.Add(new Point(x, y - 1));
			if (matrix[y - 1, x - 1] == 0)
				result.Add(new Point(x - 1, y - 1));
			if (matrix[y, x - 1] == 0)
				result.Add(new Point(x - 1, y));
			if (matrix[y + 1, x - 1] == 0)
				result.Add(new Point(x - 1, y + 1));
			if (matrix[y + 1, x] == 0)
				result.Add(new Point(x, y + 1));
			if (matrix[y + 1, x + 1] == 0)
				result.Add(new Point(x + 1, y + 1));

			return result;
		}

		private static bool RemoveSpikeOnMinutiae(ImageMatrix matrix, Minutia end, Minutia bifurcation)
		{
			if (bifurcation.MinutiaType == MinutiaType.Bifurcation)
			{
				int xBifur = bifurcation.X;
				int yBifur = bifurcation.Y;

				List<Point> treeNeighboors = GetNeighboors(matrix, xBifur, yBifur);

				if (treeNeighboors.Count < 3)
					return false;

				List<Point> n1 = new List<Point> { new Point(xBifur, yBifur), treeNeighboors[0] };
				List<Point> n2 = new List<Point> { new Point(xBifur, yBifur), treeNeighboors[1] };
				List<Point> n3 = new List<Point> { new Point(xBifur, yBifur), treeNeighboors[2] };

				int xEnd = end.X;
				int yEnd = end.Y;

				for (int i = 0; i < 15; i++)
				{
					List<Point> neighboors1 = GetNeighboors(matrix, n1[n1.Count - 1].X, n1[n1.Count - 1].Y);
					foreach (var neighbor in neighboors1)
						if (!n1.Contains(neighbor) && !treeNeighboors.Contains(neighbor))
							if (neighbor.X == xEnd &&
								neighbor.Y == yEnd)
								return true;
							else
								n1.Add(neighbor);

					List<Point> neighboors2 = GetNeighboors(matrix, n2[n2.Count - 1].X, n2[n2.Count - 1].Y);
					foreach (var neighbor in neighboors2)
						if (!n2.Contains(neighbor) && !treeNeighboors.Contains(neighbor))
							if (neighbor.X == xEnd &&
								neighbor.Y == yEnd)
								return true;
							else
								n2.Add(neighbor);

					List<Point> neighboors3 = GetNeighboors(matrix, n3[n3.Count - 1].X, n3[n3.Count - 1].Y);
					foreach (var neighbor in neighboors3)
						if (!n3.Contains(neighbor) && !treeNeighboors.Contains(neighbor))
							if (neighbor.X == xEnd &&
								neighbor.Y == yEnd)
								return true;
							else
								n3.Add(neighbor);
				}
			}
			return false;
		}

		private static double Distance(Minutia m0, Minutia m1)
		{
			double diff0 = m0.Y - m1.Y;
			double diff1 = m0.X - m1.X;
			return Math.Sqrt(diff0 * diff0 + diff1 * diff1);
		}
	}
}
