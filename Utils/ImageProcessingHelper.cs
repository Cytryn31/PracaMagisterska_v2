using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PracaMagisterska_v2.Utils
{
	public class ImageProcessingHelper
	{

		public static bool[][] Image2Bool(Image img)
		{
			Bitmap bmp = new Bitmap(img);
			bool[][] s = new bool[bmp.Height][];
			for (int y = 0; y < bmp.Height; y++)
			{
				s[y] = new bool[bmp.Width];
				for (int x = 0; x < bmp.Width; x++)
					s[y][x] = bmp.GetPixel(x, y).GetBrightness() < 0.3;
			}
			return s;

		}

		public static Image Bool2Image(bool[][] s)
		{
			Bitmap bmp = new Bitmap(s[0].Length, s.Length);
			using (Graphics g = Graphics.FromImage(bmp)) g.Clear(Color.White);
			for (int y = 0; y < bmp.Height; y++)
				for (int x = 0; x < bmp.Width; x++)
					if (s[y][x]) bmp.SetPixel(x, y, Color.Black);

			return bmp;
		}
		/// <summary>
		/// Resize the image to the specified width and height.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <returns>The resized image.</returns>
		public static Bitmap ResizeImage(Image image, int height, int width)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			if (image != null)
			{
				destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

				using (var graphics = Graphics.FromImage(destImage))
				{
					graphics.CompositingMode = CompositingMode.SourceCopy;
					graphics.CompositingQuality = CompositingQuality.HighQuality;
					graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
					graphics.SmoothingMode = SmoothingMode.HighQuality;
					graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

					using (var wrapMode = new ImageAttributes())
					{
						wrapMode.SetWrapMode(WrapMode.TileFlipXY);
						graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
					}
				}
			}

			return destImage;
		}

		public static bool IsBinary(Image image, int height, int width)
		{
			using (Bitmap bmp = new Bitmap(image))
			{
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						Color clr = bmp.GetPixel(j, i);
						if (!clr.Equals(Color.White) && !clr.Equals(Color.Black)) return false;
					}
				}

			}
			return true;
		}
	}
}
