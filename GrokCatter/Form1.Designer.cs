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
			button1 = new Button();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			listView1 = new ListView();
			button2 = new Button();
			button3 = new Button();
			checkBox1 = new CheckBox();
			button4 = new Button();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(12, 41);
			button1.Name = "button1";
			button1.Size = new Size(79, 23);
			button1.TabIndex = 0;
			button1.Text = "List Files";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// textBox1
			// 
			textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox1.Location = new Point(12, 12);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(723, 23);
			textBox1.TabIndex = 1;
			textBox1.Text = "D:\\moneywise\\git\\2_ControllersCore\\MongoDb";
			// 
			// textBox2
			// 
			textBox2.AcceptsReturn = true;
			textBox2.AcceptsTab = true;
			textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			textBox2.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			textBox2.Location = new Point(247, 70);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = ScrollBars.Both;
			textBox2.Size = new Size(488, 344);
			textBox2.TabIndex = 2;
			// 
			// listView1
			// 
			listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			listView1.CheckBoxes = true;
			listView1.GridLines = true;
			listView1.Location = new Point(12, 70);
			listView1.Name = "listView1";
			listView1.Size = new Size(227, 344);
			listView1.TabIndex = 3;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button2.Location = new Point(247, 41);
			button2.Name = "button2";
			button2.Size = new Size(79, 23);
			button2.TabIndex = 4;
			button2.Text = "Cat";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// button3
			// 
			button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button3.Location = new Point(534, 41);
			button3.Name = "button3";
			button3.Size = new Size(79, 23);
			button3.TabIndex = 5;
			button3.Text = "Clear";
			button3.UseVisualStyleBackColor = true;
			button3.Click += button3_Click;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(108, 44);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(38, 19);
			checkBox1.TabIndex = 6;
			checkBox1.Text = "all";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox1.CheckedChanged += checkBox1_CheckedChanged;
			// 
			// button4
			// 
			button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button4.Location = new Point(656, 41);
			button4.Name = "button4";
			button4.Size = new Size(79, 23);
			button4.TabIndex = 7;
			button4.Text = "Copy";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(747, 426);
			Controls.Add(button4);
			Controls.Add(checkBox1);
			Controls.Add(button3);
			Controls.Add(button2);
			Controls.Add(listView1);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private TextBox textBox1;
		private TextBox textBox2;
		private ListView listView1;
		private Button button2;
		private Button button3;
		private CheckBox checkBox1;
		private Button button4;
	}
}
