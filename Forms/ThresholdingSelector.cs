using System;
using System.Drawing;
using System.Windows.Forms;
using PracaMagisterska_v2.ImageProcessing;

namespace PracaMagisterska_v2
{
	public partial class ThresholdingSelector : UserControl
	{
		public ThresholdingSelector()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (Form1.Instance.ReferencePictureBox.Image != null)
				Form1.Instance.CalculatedPictureBox.Image =
					OtsuThresholding.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image));
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != null)
				if (Form1.Instance.ReferencePictureBox.Image != null)
					Form1.Instance.CalculatedPictureBox.Image =
						BasicThresholding.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image), int.Parse(textBox1.Text));
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (textBox2.Text != null)
				if (textBox1.Text != null)
					if (Form1.Instance.ReferencePictureBox.Image != null)
						Form1.Instance.CalculatedPictureBox.Image =
							IterativeThresholding.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image), int.Parse(textBox1.Text), int.Parse(textBox2.Text));
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (Form1.Instance.ReferencePictureBox.Image != null)
				Form1.Instance.CalculatedPictureBox.Image =
					BradleyLocalThreshold.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image));
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (Form1.Instance.ReferencePictureBox.Image != null)
				Form1.Instance.CalculatedPictureBox.Image =
					SISThresholding.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image));
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (Form1.Instance.ReferencePictureBox.Image != null)
				Form1.Instance.CalculatedPictureBox.Image =
					AdaptiveThresholdingWithMean.Apply(new Bitmap(Form1.Instance.ReferencePictureBox.Image));
		}
	}
}
