using System;
using System.Drawing;
using System.Windows.Forms;
using Accord.Imaging.Filters;
using PracaMagisterska_v2.Filters;
using PracaMagisterska_v2.ImageProcessing;

namespace PracaMagisterska_v2.Forms
{
	public partial class NormalizationForm : UserControl
	{
		public NormalizationForm()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != null)
				if (textBox2.Text != null)
					if (Form1.Instance.ReferencePictureBox.Image != null)
					{
						Form1.Instance.CalculatedPictureBox.Image =
							ImageNormalizator.Normalize(new Bitmap(Form1.Instance.ReferencePictureBox.Image), int.Parse(textBox1.Text), int.Parse(textBox2.Text));
					}
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (textBox3.Text != null)
				if (textBox4.Text != null)
					if (Form1.Instance.ReferencePictureBox.Image != null)
					{
						GaussianBlur filter = new GaussianBlur(float.Parse(textBox4.Text), int.Parse(textBox3.Text));
						Form1.Instance.CalculatedPictureBox.Image =
							filter.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image));
					}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox3.Text != null)
				if (Form1.Instance.ReferencePictureBox.Image != null)
				{

					var bmp = new Bitmap(Form1.Instance.ReferencePictureBox.Image);
					bmp = bmp.MedianFilter(int.Parse(textBox3.Text));
					Form1.Instance.CalculatedPictureBox.Image = bmp;
				}
		}
	}
}
