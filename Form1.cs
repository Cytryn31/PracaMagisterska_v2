using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PracaMagisterska_v2.Orientation;
using PracaMagisterska_v2.Utils;
using Accord.Imaging.Filters;
using PracaMagisterska_v2.Frequency;

namespace PracaMagisterska_v2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private Image source;
		private void button1_Click_1(object sender, EventArgs e)
		{
			pictureBox1.Image = ImageProcessingHelper.ResizeImage(pictureBox1.Image, pictureBox1.Height, pictureBox1.Width);
			Graphics g = Graphics.FromImage(pictureBox1.Image);

			var features = new HongOrientationEstimation();
			features.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
			var orientaions = features.ExtractFeatures(new Bitmap(pictureBox1.Image));
			OrientationImageDisplay.DrawLines(orientaions, g);
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			if (pictureBox1.Image == null) return;
			Bitmap input = new Bitmap((Image)pictureBox1.Image.Clone());
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			var features = new HongOrientationEstimation();
			var freq = new HongFrequencyEstimation();
			if (textBox2 == null) return;
			features.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
			freq.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
			Median medianFilter = new Median(4);
			input = grayscaleFilter.Apply(input);
			input = medianFilter.Apply(input);

			var orientaions = features.ExtractFeatures(input);
			var frequencies = freq.ExtractFeatures(input,orientaions);
			// Create a new Gabor filter
			GaborFilter filter = new GaborFilter();
			if (textBox3.Text == null) return;
			filter.Sigma = float.Parse(textBox3.Text);
			if (textBox1.Text == null) return;
			if (textBox4.Text == null) return;
			filter.Size = int.Parse(textBox1.Text);
			input = (Bitmap) GaborApplier.Apply(input, orientaions, frequencies,
				float.Parse(textBox4.Text), float.Parse(textBox3.Text), int.Parse(textBox1.Text));
			pictureBox2.Image = input;
		}

		private void loadPictureButton_Click(object sender, EventArgs e)
		{
			try
			{
				var pictureBox = pictureBox1;
				// Wrap the creation of the OpenFileDialog instance in a using statement,
				// rather than manually calling the Dispose method to ensure proper disposal
				using (var dlg = new OpenFileDialog())
				{
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						var img = FromFile(dlg.FileName);
						img = ImageProcessingHelper.ResizeImage(img, pictureBox.Height, pictureBox.Width);
						pictureBox1.Image = img;
						pictureBox.Image = (Image)img.Clone();
						source = (Image)img.Clone();
					}
				}
			}
			catch (Exception exception)
			{
			}
		}

		private void loadPicture2Button_Click(object sender, EventArgs e)
		{
			try
			{
				var pictureBox = pictureBox2;
				// Wrap the creation of the OpenFileDialog instance in a using statement,
				// rather than manually calling the Dispose method to ensure proper disposal
				using (var dlg = new OpenFileDialog())
				{
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						var img = FromFile(dlg.FileName);
						img = ImageProcessingHelper.ResizeImage(img, pictureBox.Height, pictureBox.Width);
						pictureBox.Image = img;
						pictureBox.Image = (Image)img.Clone();
					}
				}
			}
			catch (Exception exception)
			{
			}
		}

		private void savePictureButton_Click(object sender, EventArgs e)
		{
			if (pictureBox2.Image == null) return;
			try
			{
				var sfd = new SaveFileDialog();
				sfd.Filter = "Images|*.png;*.bmp;*.jpg";
				var format = ImageFormat.Png;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					var ext = Path.GetExtension(sfd.FileName);
					switch (ext)
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
					}
					pictureBox1.Image.Save(sfd.FileName, format);
				}
			}
			catch (Exception exception)
			{
			}
		}

		public static Image FromFile(string path)
		{
			var bytes = File.ReadAllBytes(path);
			var ms = new MemoryStream(bytes);
			var img = Image.FromStream(ms);
			return img;
		}

		private void button4_Click(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			pictureBox1.Image = (Image)pictureBox2.Image.Clone();
			source = (Image)pictureBox2.Image.Clone();
			pictureBox2.Image = null;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (source == null) return;
			pictureBox1.Image = (Image)source.Clone();
		}
	}
}
