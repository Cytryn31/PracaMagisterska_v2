using System;
using System.Collections.Generic;
using System.Drawing;

namespace PracaMagisterska_v2.Orientation
{
	class MinutiaImageDisplay
	{
		public static void DrawMinutia(List<Minutia> minutiae, Graphics g, bool rect = false)
		{
			int lineLength = 8;
			Pen greenPen = new Pen(Brushes.Green) { Width = 2 };
			Pen redPen = new Pen(Brushes.Red) { Width = 2 };
			Pen bluePen = new Pen(Brushes.Blue) { Width = 2 };
			foreach (var minutia in minutiae)
			{
				Point p0 = new Point
				{
					X = Convert.ToInt32(minutia.X - lineLength * Math.Cos(minutia.Angle)),
					Y = Convert.ToInt32(minutia.Y - lineLength * Math.Sin(minutia.Angle))
				};

				Point p1 = new Point
				{
					X = Convert.ToInt32(minutia.X + lineLength * Math.Cos(minutia.Angle)),
					Y = Convert.ToInt32(minutia.Y + lineLength * Math.Sin(minutia.Angle))
				};
				if (minutia.MinutiaType == MinutiaType.End)
				{
					g.DrawEllipse(greenPen, new Rectangle(minutia.X - 5, minutia.Y - 5, 10, 10));
					g.DrawLine(bluePen, p0, p1);
				}
				else if (minutia.MinutiaType == MinutiaType.Bifurcation)
				{
					g.DrawEllipse(redPen, new Rectangle(minutia.X - 5, minutia.Y - 5, 10, 10));
					g.DrawLine(bluePen, p0, p1);
				}
				if (rect)
				{
					g.DrawRectangle(new Pen(Color.Yellow,2), new Rectangle(minutia.X - 5, minutia.Y - 5, 10, 10));
				}
			}
		}
	}
}
