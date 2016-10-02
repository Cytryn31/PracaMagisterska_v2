using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracaMagisterska_v2.Forms
{
	public class CustomPictureBox : PictureBox
	{
		public event EventHandler ImageChanged;
		public Image Image
		{
			get
			{
				return base.Image;
			}
			set
			{
				base.Image = value;
				if (this.ImageChanged != null)
					this.ImageChanged(this, new EventArgs());
			}
		}
	}
}
