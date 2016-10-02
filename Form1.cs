using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PracaMagisterska_v2.Orientation;
using PracaMagisterska_v2.Utils;
using Accord.Imaging.Filters;
using PracaMagisterska_v2.Frequency;
using PracaMagisterska_v2.ImageProcessing;

namespace PracaMagisterska_v2
{
	public partial class Form1 : Form
	{
		private enum GaborType
		{
			[Description("LHONG")]
			LHong = 0,
			[Description("FilterBank")]
			FilterBank = 1
		}
		public static Form1 Instance;

		public Form1()
		{
			Instance = this;
			InitializeComponent();
			comboBox1.DataSource = Enum.GetNames(typeof(GaborType));
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		private void refImageChanged_Event(object sender, EventArgs e)
		{
			sourceReferenceImage = (Image)ReferencePictureBox.Image.Clone();
		}

		private void calcImageChanged_Event(object sender, EventArgs e)
		{
			if (CalculatedPictureBox.Image != null) sourceCalculatedImage = (Image)CalculatedPictureBox.Image.Clone();
			else
			{
				sourceCalculatedImage = null;
			}
		}
		private Image sourceReferenceImage;
		private Image sourceCalculatedImage;

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


			if (comboBox1.SelectedText.Equals("LHong"))
			{
				var orientation = new HongOrientationEstimation();
				var freq = new HongFrequencyEstimation();
				orientation.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
				freq.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
				var orientaions = orientation.ExtractFeatures(input);
				var frequencies = freq.ExtractFeatures(input, orientaions);

				input = (Bitmap)GaborApplier.Apply(input, orientaions, frequencies,
					(double)decimal.Parse(textBox4.Text), (double)decimal.Parse(textBox3.Text), int.Parse(textBox1.Text));
			}
			else if (comboBox1.SelectedText.Equals("FilterBank"))
			{
				
			}
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
						sourceCalculatedImage = (Image)img.Clone();
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
			CalculatedPictureBox.Image = null;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (sourceReferenceImage == null) return;
			ReferencePictureBox.Image = (Image)sourceReferenceImage.Clone();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (Form1.Instance.ReferencePictureBox.Image != null)
			{
				bool[][] result = ImageProcessingHelper.Image2Bool(Form1.Instance.ReferencePictureBox.Image);
				result = ZhangSuen.ZhangSuenThinning(result);
				Form1.Instance.CalculatedPictureBox.Image = ImageProcessingHelper.Bool2Image(result);
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			var orientation = new HongOrientationEstimation { BlockSize = Convert.ToByte(int.Parse(textBox2.Text)) };
			if (CalculatedPictureBox.Image != null)
			{
				var orientaions = orientation.ExtractFeatures(new Bitmap(CalculatedPictureBox.Image));
				if (checkBox1.Checked && (textBox5.Text != null || textBox5.Text != null || textBox7.Text != null)) return;
				MinutiaContainer.Instance.CalculatedMinutiaeList =
					MinutiaExtractor.GetMinutiaes(new Bitmap(CalculatedPictureBox.Image), orientaions, checkBox1.Checked,
						int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text));
			}
			else return;
			CalculatedPictureBox.Image = (Image)sourceCalculatedImage.Clone();
			Graphics g = Graphics.FromImage(CalculatedPictureBox.Image);
			MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.CalculatedMinutiaeList, g);
		}
	}
}