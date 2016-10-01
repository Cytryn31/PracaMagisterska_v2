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
		public static Form1 Instance;
		public Form1()
		{
			Instance = this;
			InitializeComponent();
		}

		private Image source;

		private void button1_Click_1(object sender, EventArgs e)
		{
			ReferencePictureBox.Image = ImageProcessingHelper.ResizeImage(ReferencePictureBox.Image, ReferencePictureBox.Height, ReferencePictureBox.Width);
			Graphics g = Graphics.FromImage(ReferencePictureBox.Image);
			var features = new HongOrientationEstimation();
			features.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
			var orientaions = features.ExtractFeatures(new Bitmap(ReferencePictureBox.Image));
			OrientationImageDisplay.DrawLines(orientaions, g);
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			if (ReferencePictureBox.Image == null) return;
			if (textBox1.Text == null) return;
			if (textBox2.Text == null) return;
			if (textBox3.Text == null) return;
			if (textBox4.Text == null) return;
			Bitmap input = new Bitmap((Image)ReferencePictureBox.Image.Clone());
			
			
			var features = new HongOrientationEstimation();
			var freq = new HongFrequencyEstimation();
			features.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
			freq.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
			var orientaions = features.ExtractFeatures(input);
			var frequencies = freq.ExtractFeatures(input, orientaions);

			input = (Bitmap)GaborApplier.Apply(input, orientaions, frequencies,
				float.Parse(textBox4.Text), float.Parse(textBox3.Text), int.Parse(textBox1.Text));
			CalculatedPictureBox.Image = input;
		}

		private void loadPictureButton_Click(object sender, EventArgs e)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			try
			{
				var pictureBox = ReferencePictureBox;
				// Wrap the creation of the OpenFileDialog instance in a using statement,
				// rather than manually calling the Dispose method to ensure proper disposal
				using (var dlg = new OpenFileDialog())
				{
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						var img = FromFile(dlg.FileName);
						img = ImageProcessingHelper.ResizeImage(img, pictureBox.Height, pictureBox.Width);
						img = grayscaleFilter.Apply(new Bitmap(img));
						ReferencePictureBox.Image = img;
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
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721); try
			{
				var pictureBox = CalculatedPictureBox;
				// Wrap the creation of the OpenFileDialog instance in a using statement,
				// rather than manually calling the Dispose method to ensure proper disposal
				using (var dlg = new OpenFileDialog())
				{
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						var img = FromFile(dlg.FileName);
						img = ImageProcessingHelper.ResizeImage(img, pictureBox.Height, pictureBox.Width);
						img = grayscaleFilter.Apply(new Bitmap(img));
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
			if (CalculatedPictureBox.Image == null) return;
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
					ReferencePictureBox.Image.Save(sfd.FileName, format);
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

		private void button6_Click(object sender, EventArgs e)
		{
			ReferencePictureBox.Image = (Image)CalculatedPictureBox.Image.Clone();
			source = (Image)CalculatedPictureBox.Image.Clone();
			CalculatedPictureBox.Image = null;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (source == null) return;
			ReferencePictureBox.Image = (Image)source.Clone();
		}
	}
}