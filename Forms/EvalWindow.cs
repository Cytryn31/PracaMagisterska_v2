using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracaMagisterska_v2.Orientation;

namespace PracaMagisterska_v2.Forms
{
	public partial class EvalWindow : Form
	{

		public EvalWindow()
		{
			InitializeComponent();

			textBox1.Text = MinutiaContainer.Instance.ReferenceMinutiaeList.Count(m => m.MinutiaType == MinutiaType.End).ToString();
			textBox2.Text = MinutiaContainer.Instance.ReferenceMinutiaeList.Count(m => m.MinutiaType == MinutiaType.Bifurcation).ToString();
			textBox3.Text = MinutiaContainer.Instance.CalculatedMinutiaeList.Count(m => m.MinutiaType == MinutiaType.End).ToString();
			textBox4.Text = MinutiaContainer.Instance.CalculatedMinutiaeList.Count(m => m.MinutiaType == MinutiaType.Bifurcation).ToString();

			customPictureBox1.Image = Form1.Instance.ReferencePictureBox.Image;
		}

		public List<Minutia> Check(List<Minutia> referenceList, List<Minutia> calculatedList, MinutiaType type)
		{
			List<Minutia> checkedList = new List<Minutia>();
			foreach (var refMinutia in referenceList.Where(p => p.MinutiaType == type))
			{
				foreach (var calcMinutia in calculatedList.Where(p => p.MinutiaType == type))
				{
					if (Distance(refMinutia, calcMinutia) <= float.Parse(textBox11.Text) &&
					    Math.Abs(refMinutia.Angle - calcMinutia.Angle) < float.Parse(textBox12.Text))
					{
						checkedList.Add(refMinutia);
						break;
					}
				}
			}
			return checkedList;
		}

		private static double Distance(Minutia m0, Minutia m1)
		{
			double diff0 = m0.Y - m1.Y;
			double diff1 = m0.X - m1.X;
			return Math.Sqrt(diff0 * diff0 + diff1 * diff1);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var ends = Check(MinutiaContainer.Instance.ReferenceMinutiaeList, MinutiaContainer.Instance.CalculatedMinutiaeList, MinutiaType.End);
			var bis = Check(MinutiaContainer.Instance.ReferenceMinutiaeList, MinutiaContainer.Instance.CalculatedMinutiaeList, MinutiaType.Bifurcation);
			customPictureBox1.Image = Form1.Instance.ReferencePictureBox.Image.Clone() as Image;
			textBox5.Text = ends.Count().ToString();
			textBox6.Text = bis.Count().ToString();
			textBox7.Text = (ends.Count() + bis.Count()).ToString();

			textBox8.Text = (ends.Count()/ float.Parse(textBox1.Text) * 100).ToString();
			textBox9.Text = (bis.Count() / float.Parse(textBox2.Text)*100).ToString();
			textBox10.Text = ((float.Parse(textBox8.Text) + float.Parse(textBox9.Text))/2).ToString();

			Bitmap tempBitmap = new Bitmap(customPictureBox1.Image.Width, customPictureBox1.Image.Height);

			// From this bitmap, the graphics can be obtained, because it has the right PixelFormat
			using (Graphics g = Graphics.FromImage(tempBitmap))
			{
				// Draw the original bitmap onto the graphics of the new bitmap
				g.DrawImage(customPictureBox1.Image, 0, 0);
				// Use g to do whatever you like
				MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.ReferenceMinutiaeList, g);
				MinutiaImageDisplay.DrawMinutia(ends.Concat(bis).ToList(), g, true);
			}
			customPictureBox1.Image = tempBitmap;
		}
	}
}
