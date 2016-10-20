using System.ComponentModel;
using System.Windows.Forms;
using PracaMagisterska_v2.Forms;

namespace PracaMagisterska_v2
{
	partial class Form1
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.Gabor = new System.Windows.Forms.TabPage();
			this.button14 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button9 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox7 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.textBox6 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.textBox5 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.thresholdingSelector1 = new PracaMagisterska_v2.ThresholdingSelector();
			this.normalizationForm1 = new PracaMagisterska_v2.Forms.NormalizationForm();
			this.textBox4 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.textBox3 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.textBox2 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.textBox1 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.CalculatedPictureBox = new PracaMagisterska_v2.Forms.CustomPictureBox();
			this.ReferencePictureBox = new PracaMagisterska_v2.Forms.CustomPictureBox();
			this.customTextBox2 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.customTextBox1 = new PracaMagisterska_v2.Forms.CustomTextBox();
			this.Gabor.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CalculatedPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ReferencePictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// Gabor
			// 
			this.Gabor.Controls.Add(this.button14);
			this.Gabor.Controls.Add(this.button12);
			this.Gabor.Controls.Add(this.button13);
			this.Gabor.Controls.Add(this.button11);
			this.Gabor.Controls.Add(this.button10);
			this.Gabor.Controls.Add(this.comboBox1);
			this.Gabor.Controls.Add(this.panel2);
			this.Gabor.Controls.Add(this.panel1);
			this.Gabor.Controls.Add(this.thresholdingSelector1);
			this.Gabor.Controls.Add(this.normalizationForm1);
			this.Gabor.Controls.Add(this.label4);
			this.Gabor.Controls.Add(this.textBox4);
			this.Gabor.Controls.Add(this.label3);
			this.Gabor.Controls.Add(this.textBox3);
			this.Gabor.Controls.Add(this.label2);
			this.Gabor.Controls.Add(this.textBox2);
			this.Gabor.Controls.Add(this.label1);
			this.Gabor.Controls.Add(this.textBox1);
			this.Gabor.Controls.Add(this.button7);
			this.Gabor.Controls.Add(this.button6);
			this.Gabor.Controls.Add(this.button5);
			this.Gabor.Controls.Add(this.button4);
			this.Gabor.Controls.Add(this.button3);
			this.Gabor.Controls.Add(this.CalculatedPictureBox);
			this.Gabor.Controls.Add(this.ReferencePictureBox);
			this.Gabor.Controls.Add(this.button2);
			this.Gabor.Controls.Add(this.button1);
			this.Gabor.Location = new System.Drawing.Point(4, 22);
			this.Gabor.Name = "Gabor";
			this.Gabor.Padding = new System.Windows.Forms.Padding(3);
			this.Gabor.Size = new System.Drawing.Size(1292, 729);
			this.Gabor.TabIndex = 1;
			this.Gabor.Text = "Gabor";
			this.Gabor.UseVisualStyleBackColor = true;
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(694, 8);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(44, 23);
			this.button14.TabIndex = 39;
			this.button14.Text = "Test";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.button14_Click);
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(1152, 8);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(94, 23);
			this.button12.TabIndex = 38;
			this.button12.Text = "Load minutiae";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(1064, 9);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(82, 23);
			this.button13.TabIndex = 37;
			this.button13.Text = "Save minutiae";
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.button13_Click);
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(585, 8);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(89, 23);
			this.button11.TabIndex = 36;
			this.button11.Text = "Load minutiae";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(495, 9);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(84, 23);
			this.button10.TabIndex = 35;
			this.button10.Text = "Save minutiae";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(122, 69);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(97, 21);
			this.comboBox1.TabIndex = 26;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label9);
			this.panel2.Controls.Add(this.textBox7);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.textBox6);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.textBox5);
			this.panel2.Controls.Add(this.checkBox1);
			this.panel2.Controls.Add(this.button9);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Location = new System.Drawing.Point(6, 620);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(225, 106);
			this.panel2.TabIndex = 25;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(5, 85);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(124, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Spike detection distance";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(5, 63);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(110, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Broken ridge distance";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(5, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "To near distance";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(8, 20);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(127, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Remove false minutia";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(141, 4);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(84, 49);
			this.button9.TabIndex = 1;
			this.button9.Text = "Crossing Number";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(5, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Minutia Extraction";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.button8);
			this.panel1.Location = new System.Drawing.Point(6, 568);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(225, 46);
			this.panel1.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 13);
			this.label5.TabIndex = 23;
			this.label5.Text = "Thinning";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(3, 18);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 22;
			this.button8.Text = "ZhangSuen";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label4.Location = new System.Drawing.Point(30, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Gamma";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label3.Location = new System.Drawing.Point(30, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Sigma";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(15, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Window Size";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(20, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Kernel Size";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(318, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 8;
			this.button7.Text = "Refresh";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(759, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(44, 23);
			this.button6.TabIndex = 7;
			this.button6.Text = "<-";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(890, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 6;
			this.button5.Text = "Save";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.savePictureButton_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(809, 8);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Load";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.loadPicture2Button_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(237, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Load";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.loadPictureButton_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.button2.Location = new System.Drawing.Point(121, 92);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(97, 22);
			this.button2.TabIndex = 1;
			this.button2.Text = "Gabor";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.button1.Location = new System.Drawing.Point(121, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(97, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Draw Orientaions";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.Gabor);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(13, 13);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1300, 755);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.customTextBox2);
			this.tabPage1.Controls.Add(this.customTextBox1);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1292, 729);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Filters Bank";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(21, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 13);
			this.label11.TabIndex = 2;
			this.label11.Text = "Frequencies";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(21, 19);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "Angles(Degrees)";
			// 
			// textBox7
			// 
			this.textBox7.AllowSpace = false;
			this.textBox7.Location = new System.Drawing.Point(135, 82);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(22, 20);
			this.textBox7.TabIndex = 7;
			this.textBox7.Text = "15";
			// 
			// textBox6
			// 
			this.textBox6.AllowSpace = false;
			this.textBox6.Location = new System.Drawing.Point(121, 60);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(22, 20);
			this.textBox6.TabIndex = 5;
			this.textBox6.Text = "10";
			// 
			// textBox5
			// 
			this.textBox5.AllowSpace = false;
			this.textBox5.Location = new System.Drawing.Point(112, 39);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(22, 20);
			this.textBox5.TabIndex = 3;
			this.textBox5.Text = "5";
			// 
			// thresholdingSelector1
			// 
			this.thresholdingSelector1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.thresholdingSelector1.Location = new System.Drawing.Point(6, 296);
			this.thresholdingSelector1.Name = "thresholdingSelector1";
			this.thresholdingSelector1.Size = new System.Drawing.Size(225, 266);
			this.thresholdingSelector1.TabIndex = 21;
			// 
			// normalizationForm1
			// 
			this.normalizationForm1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.normalizationForm1.Location = new System.Drawing.Point(6, 124);
			this.normalizationForm1.Name = "normalizationForm1";
			this.normalizationForm1.Size = new System.Drawing.Size(225, 166);
			this.normalizationForm1.TabIndex = 20;
			// 
			// textBox4
			// 
			this.textBox4.AllowSpace = false;
			this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.textBox4.Location = new System.Drawing.Point(86, 98);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(29, 20);
			this.textBox4.TabIndex = 15;
			this.textBox4.Text = "1";
			// 
			// textBox3
			// 
			this.textBox3.AllowSpace = false;
			this.textBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.textBox3.Location = new System.Drawing.Point(86, 72);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(29, 20);
			this.textBox3.TabIndex = 13;
			this.textBox3.Text = "4";
			// 
			// textBox2
			// 
			this.textBox2.AllowSpace = false;
			this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.textBox2.Location = new System.Drawing.Point(86, 18);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 11;
			this.textBox2.Text = "16";
			// 
			// textBox1
			// 
			this.textBox1.AllowSpace = false;
			this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.textBox1.Location = new System.Drawing.Point(86, 46);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(29, 20);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "3";
			// 
			// CalculatedPictureBox
			// 
			this.CalculatedPictureBox.BackColor = System.Drawing.Color.Black;
			this.CalculatedPictureBox.Image = null;
			this.CalculatedPictureBox.Location = new System.Drawing.Point(759, 44);
			this.CalculatedPictureBox.Name = "CalculatedPictureBox";
			this.CalculatedPictureBox.Size = new System.Drawing.Size(516, 672);
			this.CalculatedPictureBox.TabIndex = 3;
			this.CalculatedPictureBox.TabStop = false;
			this.CalculatedPictureBox.ImageChanged += new System.EventHandler(this.calcImageChanged_Event);
			// 
			// ReferencePictureBox
			// 
			this.ReferencePictureBox.BackColor = System.Drawing.Color.Black;
			this.ReferencePictureBox.Image = null;
			this.ReferencePictureBox.Location = new System.Drawing.Point(237, 44);
			this.ReferencePictureBox.Name = "ReferencePictureBox";
			this.ReferencePictureBox.Size = new System.Drawing.Size(516, 672);
			this.ReferencePictureBox.TabIndex = 2;
			this.ReferencePictureBox.TabStop = false;
			this.ReferencePictureBox.ImageChanged += new System.EventHandler(this.refImageChanged_Event);
			this.ReferencePictureBox.Click += new System.EventHandler(this.ReferencePictureBox_Click);
			// 
			// customTextBox2
			// 
			this.customTextBox2.AllowSpace = true;
			this.customTextBox2.Location = new System.Drawing.Point(112, 52);
			this.customTextBox2.Name = "customTextBox2";
			this.customTextBox2.Size = new System.Drawing.Size(145, 20);
			this.customTextBox2.TabIndex = 5;
			this.customTextBox2.Text = "0,2 0,11 0,09";
			// 
			// customTextBox1
			// 
			this.customTextBox1.AllowSpace = true;
			this.customTextBox1.Location = new System.Drawing.Point(112, 19);
			this.customTextBox1.Name = "customTextBox1";
			this.customTextBox1.Size = new System.Drawing.Size(145, 20);
			this.customTextBox1.TabIndex = 4;
			this.customTextBox1.Text = "0 15 60 95 135 170";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1309, 741);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "GeTuP";
			this.Gabor.ResumeLayout(false);
			this.Gabor.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CalculatedPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ReferencePictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private TabPage Gabor;
		private TabControl tabControl1;
		private Button button3;
		private Button button4;
		private Button button5;
		private Button button6;
		private Button button7;
		private NormalizationForm normalizationForm1;
		private ThresholdingSelector thresholdingSelector1;
		private Panel panel1;
		private Label label5;
		private Button button8;
		private Panel panel2;
		private Button button9;
		private Label label6;
		public CustomPictureBox CalculatedPictureBox;
		public CustomPictureBox ReferencePictureBox;
		private Label label9;
		private Label label8;
		private Label label7;
		private CheckBox checkBox1;
		private ComboBox comboBox1;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private Button button2;
		private Button button1;
		private Button button10;
		private Button button12;
		private Button button13;
		private Button button11;
		private Button button14;
		private CustomTextBox textBox7;
		private CustomTextBox textBox6;
		private CustomTextBox textBox5;
		private CustomTextBox textBox4;
		private CustomTextBox textBox3;
		private CustomTextBox textBox2;
		private CustomTextBox textBox1;
		private TabPage tabPage1;
		private Label label11;
		private Label label10;
		private CustomTextBox customTextBox2;
		private CustomTextBox customTextBox1;
	}
}

