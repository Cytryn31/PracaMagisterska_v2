using System.ComponentModel;
using System.Windows.Forms;
using PracaMagisterska_v2.Forms;

namespace PracaMagisterska_v2
{
	partial class ThresholdingSelector
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.CustomTextBox1 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.CustomTextBox2 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.CustomTextBox4 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.CustomTextBox3 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.panel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Thresholding";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(79, 225);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(54, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "OTSU";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(102, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(76, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "STANDARD";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(15, 225);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(54, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "MEAN";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(126, 66);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(70, 23);
			this.button4.TabIndex = 4;
			this.button4.Text = "BRADLEY";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(120, 42);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 5;
			this.button5.Text = "ITERATIVE";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(145, 225);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(48, 23);
			this.button6.TabIndex = 6;
			this.button6.Text = "SIST";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// CustomTextBox1
			// 
			this.CustomTextBox1.Location = new System.Drawing.Point(63, 3);
			this.CustomTextBox1.Name = "CustomTextBox1";
			this.CustomTextBox1.Size = new System.Drawing.Size(33, 20);
			this.CustomTextBox1.TabIndex = 7;
			this.CustomTextBox1.Text = "128";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Threshold";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(119, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Error";
			// 
			// CustomTextBox2
			// 
			this.CustomTextBox2.Location = new System.Drawing.Point(154, 71);
			this.CustomTextBox2.Name = "CustomTextBox2";
			this.CustomTextBox2.Size = new System.Drawing.Size(33, 20);
			this.CustomTextBox2.TabIndex = 9;
			this.CustomTextBox2.Text = "2";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.CustomTextBox2);
			this.panel1.Location = new System.Drawing.Point(3, 20);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 100);
			this.panel1.TabIndex = 11;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.CustomTextBox1);
			this.flowLayoutPanel1.Controls.Add(this.button2);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 24);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(186, 36);
			this.flowLayoutPanel1.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.label5);
			this.panel2.Controls.Add(this.CustomTextBox4);
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.CustomTextBox3);
			this.panel2.Location = new System.Drawing.Point(3, 126);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(202, 96);
			this.panel2.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(157, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Pixel Brightness Difference Limit";
			// 
			// CustomTextBox4
			// 
			this.CustomTextBox4.Location = new System.Drawing.Point(175, 40);
			this.CustomTextBox4.Name = "CustomTextBox4";
			this.CustomTextBox4.Size = new System.Drawing.Size(21, 20);
			this.CustomTextBox4.TabIndex = 11;
			this.CustomTextBox4.Text = "0,2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Window";
			// 
			// CustomTextBox3
			// 
			this.CustomTextBox3.Location = new System.Drawing.Point(175, 9);
			this.CustomTextBox3.Name = "CustomTextBox3";
			this.CustomTextBox3.Size = new System.Drawing.Size(21, 20);
			this.CustomTextBox3.TabIndex = 9;
			this.CustomTextBox3.Text = "5";
			// 
			// ThresholdingSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "ThresholdingSelector";
			this.Size = new System.Drawing.Size(213, 257);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label label1;
		private Button button1;
		private Button button2;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button button6;
		private CustomTextBox CustomTextBox1;
		private Label label2;
		private Label label3;
		private CustomTextBox CustomTextBox2;
		private Panel panel1;
		private FlowLayoutPanel flowLayoutPanel1;
		private Panel panel2;
		private Label label5;
		private CustomTextBox CustomTextBox4;
		private Label label4;
		private CustomTextBox CustomTextBox3;
	}
}
