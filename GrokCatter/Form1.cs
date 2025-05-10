namespace GrokCatter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			listView1.Columns.Add("Name", 200);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Doit();
		}

		private void Doit()
		{
			try
			{
				this.listView1.Items.Clear();


				if (!Directory.Exists(this.textBox1.Text))
				{
					MessageBox.Show("Invalid directory path!", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}


				var files = Directory.GetFiles(textBox1.Text);

				foreach (var file in files)
				{
					var item = new ListViewItem(Path.GetFileName(file))
					{
						Tag = file
					};

					listView1.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.textBox2.Clear();
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			var selectedItems = listView1.CheckedItems.Cast<ListViewItem>().ToList();
			foreach (var selectedItem in selectedItems)
			{
				var file = selectedItem?.Tag?.ToString();
				if (file == null)
					continue;
				var text = await File.ReadAllTextAsync(file);
				this.textBox2.AppendText(Environment.NewLine);
				this.textBox2.AppendText($"// {Path.GetFileName(file)}{Environment.NewLine}");
				this.textBox2.AppendText($"// ------------------------{Environment.NewLine}");
				this.textBox2.AppendText(text);
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in this.listView1.Items)
			{
				lvi.Checked = this.checkBox1.Checked;
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.textBox2.Text);
		}
	}
}
