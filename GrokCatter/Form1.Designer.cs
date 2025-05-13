namespace GrokCatter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			listView1 = new ListView();
			button2 = new Button();
			button3 = new Button();
			checkBox1 = new CheckBox();
			button4 = new Button();
			splitContainer1 = new SplitContainer();
			listView2 = new ListView();
			comboBox1 = new ComboBox();
			button5 = new Button();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(12, 12);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(900, 23);
			textBox1.TabIndex = 1;
			textBox1.TextChanged += TextBox1_TextChanged;
			// 
			// textBox2
			// 
			textBox2.AcceptsReturn = true;
			textBox2.AcceptsTab = true;
			textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox2.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			textBox2.Location = new Point(159, 3);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = ScrollBars.Both;
			textBox2.Size = new Size(579, 384);
			textBox2.TabIndex = 2;
			// 
			// listView1
			// 
			listView1.CheckBoxes = true;
			listView1.Dock = DockStyle.Fill;
			listView1.GridLines = true;
			listView1.HeaderStyle = ColumnHeaderStyle.None;
			listView1.Location = new Point(0, 0);
			listView1.Name = "listView1";
			listView1.Size = new Size(150, 390);
			listView1.TabIndex = 3;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			listView1.ItemChecked += ListView1_ItemChecked;
			listView1.SizeChanged += ListView1_SizeChanged;
			// 
			// button2
			// 
			button2.Location = new Point(396, 40);
			button2.Name = "button2";
			button2.Size = new Size(73, 23);
			button2.TabIndex = 4;
			button2.Text = "Cat";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Button2_Click;
			// 
			// button3
			// 
			button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button3.Location = new Point(728, 40);
			button3.Name = "button3";
			button3.Size = new Size(79, 23);
			button3.TabIndex = 5;
			button3.Text = "Clear";
			button3.UseVisualStyleBackColor = true;
			button3.Click += Button3_Click;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(12, 43);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(38, 19);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "all";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
			// 
			// button4
			// 
			button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button4.Location = new Point(833, 40);
			button4.Name = "button4";
			button4.Size = new Size(79, 23);
			button4.TabIndex = 7;
			button4.Text = "Copy";
			button4.UseVisualStyleBackColor = true;
			button4.Click += Button4_Click;
			// 
			// splitContainer1
			// 
			splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			splitContainer1.Location = new Point(12, 69);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(listView1);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(listView2);
			splitContainer1.Panel2.Controls.Add(textBox2);
			splitContainer1.Size = new Size(903, 390);
			splitContainer1.SplitterDistance = 150;
			splitContainer1.SplitterWidth = 8;
			splitContainer1.TabIndex = 8;
			// 
			// listView2
			// 
			listView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			listView2.CheckBoxes = true;
			listView2.GridLines = true;
			listView2.HeaderStyle = ColumnHeaderStyle.None;
			listView2.Location = new Point(3, 3);
			listView2.Name = "listView2";
			listView2.Size = new Size(150, 384);
			listView2.TabIndex = 4;
			listView2.UseCompatibleStateImageBehavior = false;
			listView2.View = View.Details;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] { "example1" });
			comboBox1.Location = new Point(172, 39);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(151, 23);
			comboBox1.TabIndex = 9;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			// 
			// button5
			// 
			button5.Location = new Point(329, 40);
			button5.Name = "button5";
			button5.Size = new Size(47, 23);
			button5.TabIndex = 10;
			button5.Text = "Save";
			button5.UseVisualStyleBackColor = true;
			button5.Click += Button5_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(927, 471);
			Controls.Add(button5);
			Controls.Add(comboBox1);
			Controls.Add(splitContainer1);
			Controls.Add(button4);
			Controls.Add(checkBox1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(textBox1);
			MinimumSize = new Size(700, 0);
			Name = "Form1";
			Text = "Cat the files";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox textBox1;
		private TextBox textBox2;
		private ListView listView1;
		private Button button2;
		private Button button3;
		private CheckBox checkBox1;
		private Button button4;
		private SplitContainer splitContainer1;
		private ListView listView2;
		private ComboBox comboBox1;
		private Button button5;
	}
}
