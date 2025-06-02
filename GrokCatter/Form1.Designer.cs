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
			listView1 = new ListView();
			button2 = new Button();
			checkBox1 = new CheckBox();
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
			textBox1.Size = new Size(695, 23);
			textBox1.TabIndex = 1;
			textBox1.TextChanged += TextBox1_TextChanged;
			// 
			// listView1
			// 
			listView1.CheckBoxes = true;
			listView1.Dock = DockStyle.Fill;
			listView1.GridLines = true;
			listView1.HeaderStyle = ColumnHeaderStyle.None;
			listView1.Location = new Point(0, 0);
			listView1.Name = "listView1";
			listView1.Size = new Size(325, 330);
			listView1.TabIndex = 3;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			listView1.ItemChecked += ListView1_ItemChecked;
			listView1.SizeChanged += ListView_SizeChanged;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button2.Location = new Point(636, 39);
			button2.Name = "button2";
			button2.Size = new Size(73, 23);
			button2.TabIndex = 4;
			button2.Text = "CatCopy";
			button2.UseVisualStyleBackColor = true;
			button2.Click += Button2_Click;
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
			splitContainer1.Size = new Size(698, 330);
			splitContainer1.SplitterDistance = 325;
			splitContainer1.SplitterWidth = 8;
			splitContainer1.TabIndex = 8;
			// 
			// listView2
			// 
			listView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			listView2.CheckBoxes = true;
			listView2.GridLines = true;
			listView2.HeaderStyle = ColumnHeaderStyle.None;
			listView2.Location = new Point(3, 3);
			listView2.Name = "listView2";
			listView2.Size = new Size(359, 324);
			listView2.TabIndex = 4;
			listView2.UseCompatibleStateImageBehavior = false;
			listView2.View = View.Details;
			listView2.SizeChanged += ListView_SizeChanged;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] { "example1" });
			comboBox1.Location = new Point(119, 39);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(151, 23);
			comboBox1.TabIndex = 9;
			comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			// 
			// button5
			// 
			button5.Location = new Point(276, 39);
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
			ClientSize = new Size(722, 411);
			Controls.Add(button5);
			Controls.Add(comboBox1);
			Controls.Add(splitContainer1);
			Controls.Add(checkBox1);
			Controls.Add(button2);
			Controls.Add(textBox1);
			MinimumSize = new Size(700, 0);
			Name = "Form1";
			Text = "Cat the files";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox textBox1;
		private ListView listView1;
		private Button button2;
		private CheckBox checkBox1;
		private SplitContainer splitContainer1;
		private ListView listView2;
		private ComboBox comboBox1;
		private Button button5;
	}
}
