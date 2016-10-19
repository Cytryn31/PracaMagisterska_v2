using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Accord.Imaging.Filters;
using Newtonsoft.Json;
using PatternRecognition.FingerprintRecognition.FeatureExtractors;
using PracaMagisterska_v2.Forms;
using PracaMagisterska_v2.Frequency;
using PracaMagisterska_v2.ImageProcessing;
using PracaMagisterska_v2.Orientation;
using PracaMagisterska_v2.Utils;

namespace PracaMagisterska_v2
{
	public partial class Form1 : Form
	{
		private enum GaborType
		{
			[Description("LHONG")]
			LHong = 0,
			[Description("FilterBank")]
			FilterBank = 1,
			[Description("BestResponse")]
			BestResponse = 2
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
			if (!_lockSwapingRefImage)
			{
				sourceReferenceImage = (Image)ReferencePictureBox.Image.Clone();
			}
			else
			{
				_lockSwapingRefImage = false;
			}
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


			if (comboBox1.Text.Equals("LHong"))
			{
				var orientation = new HongOrientationEstimation();
				var freq = new HongFrequencyEstimation();
				orientation.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
				freq.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
				var orientaions = orientation.ExtractFeatures(input);
				var frequencies = freq.ExtractFeatures(input, orientaions);

				input = (Bitmap)GaborApplier.ApplyHong(input, orientaions, frequencies,
					float.Parse(textBox4.Text), float.Parse(textBox3.Text), int.Parse(textBox1.Text));
			}
			else if (comboBox1.Text.Equals("BestResponse"))
			{
				input = (Bitmap)GaborApplier.ApplyBestResponse(input,
					float.Parse(textBox4.Text), float.Parse(textBox3.Text), int.Parse(textBox1.Text));

			}
			else if (comboBox1.Text.Equals("FilterBank"))
			{
				var orientation = new HongOrientationEstimation();
				var freq = new HongFrequencyEstimation();
				orientation.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
				freq.BlockSize = Convert.ToByte(int.Parse(textBox2.Text));
				var orientaions = orientation.ExtractFeatures(input);
				var frequencies = freq.ExtractFeatures(input, orientaions);

				input = (Bitmap)GaborApplier.ApplyHong(input, orientaions, frequencies,
					float.Parse(textBox4.Text), float.Parse(textBox3.Text), int.Parse(textBox1.Text));

			}
			CalculatedPictureBox.Image = input;
		}

		private void loadPictureButton_Click(object sender, EventArgs e)
		{
			Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
			MinutiaContainer.Instance.ReferenceMinutiaeList.Clear();
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
					CalculatedPictureBox.Image.Save(sfd.FileName, format);
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
			MinutiaContainer.Instance.CalculatedMinutiaeList.Clear();
			MinutiaContainer.Instance.ReferenceMinutiaeList.Clear();
			CalculatedPictureBox.Image = null;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (sourceReferenceImage == null) return;
			MinutiaContainer.Instance.ReferenceMinutiaeList.Clear();
			ReferencePictureBox.Image = (Image)sourceReferenceImage.Clone();
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (Instance.ReferencePictureBox.Image != null)
			{
				bool[][] result = ImageProcessingHelper.Image2Bool(Instance.ReferencePictureBox.Image);
				result = ZhangSuen.ZhangSuenThinning(result);
				Instance.CalculatedPictureBox.Image = ImageProcessingHelper.Bool2Image(result);
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			MinutiaContainer.Instance.CalculatedMinutiaeList.Clear();
			var orientation = new HongOrientationEstimation { BlockSize = Convert.ToByte(int.Parse(textBox2.Text)) };
			CalculatedPictureBox.Image = (Image)sourceCalculatedImage.Clone();
			if (CalculatedPictureBox.Image != null)
			{
				var orientaions = orientation.ExtractFeatures(new Bitmap(CalculatedPictureBox.Image));
				if (checkBox1.Checked && (textBox5.Text == null || textBox5.Text == null || textBox7.Text == null)) return;
				MinutiaContainer.Instance.CalculatedMinutiaeList =
					MinutiaExtractor.GetMinutiaes(new Bitmap(CalculatedPictureBox.Image), orientaions, checkBox1.Checked,
						int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text));
			}
			else return;
			Graphics g = Graphics.FromImage(CalculatedPictureBox.Image);
			MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.CalculatedMinutiaeList, g);
		}

		private void ReferencePictureBox_Click(object sender, EventArgs e)
		{
			var mouseEventArgs = e as MouseEventArgs;
			if (mouseEventArgs != null)
			{
				var clickPosition = new Point()
				{
					X = mouseEventArgs.X,
					Y = mouseEventArgs.Y
				};
				if (mouseEventArgs.Button == MouseButtons.Left)
				{
					if (sourceReferenceImage == null) return;
					if (ReferencePictureBox.Image == null) return;
					if (!_wasFirstClick)
					{
						var point = ReferencePictureBox.PointToScreen(Point.Empty);
						Cursor.Clip = new Rectangle(point.X, point.Y, ReferencePictureBox.Width, ReferencePictureBox.Height);
						_wasFirstClick = true;
						ReferencePictureBox.Image = (Image)sourceReferenceImage.Clone();
						Bitmap tempBitmap = new Bitmap(ReferencePictureBox.Image.Width, ReferencePictureBox.Image.Height);

						// From this bitmap, the graphics can be obtained, because it has the right PixelFormat
						using (Graphics g = Graphics.FromImage(tempBitmap))
						{
							// Draw the original bitmap onto the graphics of the new bitmap
							g.DrawImage(ReferencePictureBox.Image, 0, 0);
							// Use g to do whatever you like
							g.DrawEllipse(new Pen(Color.Yellow, 2), new Rectangle(clickPosition.X - 5, clickPosition.Y - 5, 10, 10));
						}
						_lockSwapingRefImage = true;
						ReferencePictureBox.Image = tempBitmap;
					}
					else
					{
						var minutiaeType = MinutiaType.End;
						if (ModifierKeys.HasFlag(Keys.Control))
						{
							minutiaeType = MinutiaType.Bifurcation;
						}
						Cursor.Clip = Rectangle.Empty;

						MinutiaContainer.Instance.ReferenceMinutiaeList.Add(
							new Minutia()
							{
								Angle = Angle(new Point(clickPosition.X - 5, clickPosition.Y - 5), new Point(_lastClickPosition.X - 5, _lastClickPosition.Y - 5)),
								X = (short)_lastClickPosition.X,
								Y = (short)_lastClickPosition.Y,
								MinutiaType = minutiaeType
							});

						_wasFirstClick = false;
						Bitmap tempBitmap = new Bitmap(ReferencePictureBox.Image.Width, ReferencePictureBox.Image.Height);

						// From this bitmap, the graphics can be obtained, because it has the right PixelFormat
						using (Graphics g = Graphics.FromImage(tempBitmap))
						{
							// Draw the original bitmap onto the graphics of the new bitmap
							g.DrawImage(ReferencePictureBox.Image, 0, 0);
							// Use g to do whatever you like
							MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.ReferenceMinutiaeList, g);
						}
						_lockSwapingRefImage = true;
						ReferencePictureBox.Image = tempBitmap;
					}
				}

				if (mouseEventArgs.Button == MouseButtons.Right && !_wasFirstClick)
				{
					Remove(clickPosition.X, clickPosition.Y);
					ReferencePictureBox.Image = (Image)sourceReferenceImage.Clone();
					Bitmap tempBitmap = new Bitmap(ReferencePictureBox.Image.Width, ReferencePictureBox.Image.Height);

					// From this bitmap, the graphics can be obtained, because it has the right PixelFormat
					using (Graphics g = Graphics.FromImage(tempBitmap))
					{
						// Draw the original bitmap onto the graphics of the new bitmap
						g.DrawImage(ReferencePictureBox.Image, 0, 0);
						// Use g to do whatever you like
						MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.ReferenceMinutiaeList, g);
					}
					_lockSwapingRefImage = true;
					ReferencePictureBox.Image = tempBitmap;
				}
				_lastClickPosition = clickPosition;
			}
		}

		private double Angle(Point p1, Point p2)
		{
			float xDiff = p1.X - p2.X;
			float yDiff = p1.Y - p2.Y;
			return Math.Atan2(yDiff, xDiff);
		}

		private void Remove(int x, int y)
		{

			if (MinutiaContainer.Instance.ReferenceMinutiaeList == null) return;
			for (int i = 0; i < MinutiaContainer.Instance.ReferenceMinutiaeList.Count; i++)
			{
				var minutiae = MinutiaContainer.Instance.ReferenceMinutiaeList[i];
				var point = new Point(minutiae.X, minutiae.Y);
				var rect = new Rectangle(x - 15, y - 15, 20, 20);
				if (rect.Contains(point))
				{
					MinutiaContainer.Instance.ReferenceMinutiaeList.RemoveAt(i);
				}
			}
		}

		private bool _wasFirstClick = false;
		private bool _lockSwapingRefImage = false;
		private Point _lastClickPosition;

		private void button10_Click(object sender, EventArgs e)
		{
			try
			{
				var sfd = new SaveFileDialog();
				sfd.Filter = "Minucje|*.txt;*";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					var output = "";
					if (MinutiaContainer.Instance.ReferenceMinutiaeList.Any())
					{
						output = JsonConvert.SerializeObject(MinutiaContainer.Instance.ReferenceMinutiaeList);
					}
					File.WriteAllText(sfd.FileName, output);
					
				}
			}
			catch (Exception exception)
			{
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			try
			{
				using (var dlg = new OpenFileDialog())
				{
					dlg.Title = "Plik z minucjami";

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						var dlgFileName = dlg.FileName;
						var output = File.ReadAllText(dlgFileName);
						MinutiaContainer.Instance.ReferenceMinutiaeList = JsonConvert.DeserializeObject<List<Minutia>>(output);
						Bitmap tempBitmap = new Bitmap(ReferencePictureBox.Image.Width, ReferencePictureBox.Image.Height);

						// From this bitmap, the graphics can be obtained, because it has the right PixelFormat
						using (Graphics g = Graphics.FromImage(tempBitmap))
						{
							// Draw the original bitmap onto the graphics of the new bitmap
							g.DrawImage(ReferencePictureBox.Image, 0, 0);
							// Use g to do whatever you like
							MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.ReferenceMinutiaeList, g);
						}
						_lockSwapingRefImage = true;
						ReferencePictureBox.Image = tempBitmap;
					}
				}
			}
			catch (Exception exception)
			{
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			try
			{
				var sfd = new SaveFileDialog();
				sfd.Filter = "Minucje|*.txt;*";
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					var output = "";
					if (MinutiaContainer.Instance.CalculatedMinutiaeList.Any())
					{
						output = JsonConvert.SerializeObject(MinutiaContainer.Instance.CalculatedMinutiaeList);
					}
					File.WriteAllText(sfd.FileName, output);

				}
			}
			catch (Exception exception)
			{
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			try
			{
				using (var dlg = new OpenFileDialog())
				{
					dlg.Title = "Plik z minucjami";

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						var dlgFileName = dlg.FileName;
						var output = File.ReadAllText(dlgFileName);
						MinutiaContainer.Instance.CalculatedMinutiaeList = JsonConvert.DeserializeObject<List<Minutia>>(output);
						Bitmap tempBitmap = new Bitmap(CalculatedPictureBox.Image.Width, CalculatedPictureBox.Image.Height);

						// From this bitmap, the graphics can be obtained, because it has the right PixelFormat
						using (Graphics g = Graphics.FromImage(tempBitmap))
						{
							// Draw the original bitmap onto the graphics of the new bitmap
							g.DrawImage(CalculatedPictureBox.Image, 0, 0);
							// Use g to do whatever you like
							MinutiaImageDisplay.DrawMinutia(MinutiaContainer.Instance.CalculatedMinutiaeList, g);
						}
						_lockSwapingRefImage = true;
						CalculatedPictureBox.Image = tempBitmap;
					}
				}
			}
			catch (Exception exception)
			{
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			if(ReferencePictureBox.Image == null || CalculatedPictureBox.Image == null) return;
			
			EvalWindow frmAbout = new EvalWindow();
			frmAbout.ShowDialog();
		}
	}
}