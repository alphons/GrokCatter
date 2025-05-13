using System.Diagnostics;
using System.Text.Json;

namespace GrokCatter
{
	public partial class Form1 : Form
	{
		private readonly string Data = Path.Combine(AppContext.BaseDirectory, "Data");
		public Form1()
		{
			InitializeComponent();

			listView1.Columns.Add("Name", 150);

			listView2.Columns.Add("Name", 150);

			FillComboBox();
		}

		private void FillComboBox()
		{
			this.comboBox1.Items.Clear();
			var files = Directory.GetFiles(Data, "*.json");
			this.comboBox1.Items.AddRange([.. files.Select(x => Path.GetFileNameWithoutExtension(x))]);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			ShowFiles(sender, e);
		}

		private void ShowFiles(object sender, EventArgs e)
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

				CheckBox1_CheckedChanged(sender, e);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.textBox2.Clear();
		}

		private async void Button2_Click(object sender, EventArgs e)
		{
			var selectedItems = listView2.Items.Cast<ListViewItem>().ToList();
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

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in this.listView1.Items)
			{
				lvi.Checked = this.checkBox1.Checked;
			}
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(this.textBox2.Text);
		}

		private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			var item = this.listView2
					.Items
					.Cast<ListViewItem>()
					.Where(x => x.Tag?.ToString() == e.Item.Tag?.ToString())
					.FirstOrDefault();

			if (e.Item.Checked)
			{
				if (item == null)
					this.listView2.Items.Add(new ListViewItem(e.Item.Text)
					{
						Tag = e.Item.Tag,
						Checked = true
					});
			}
			else
			{
				if (item != null)
					this.listView2.Items.Remove(item);
			}
		}


		private async Task<bool> LoadExistingAsync(string name)
		{
			try
			{
				this.listView2.Items.Clear();

				var path = Path.Combine(Data, name + ".json");
				if (!File.Exists(path))
					return false;

				using var stream = File.OpenRead(path);
				var list = await JsonSerializer.DeserializeAsync<List<string>>(stream) ?? [];
				this.listView2.Items.AddRange(
					[.. list.Select(x => new ListViewItem(Path.GetFileName(x)) { Tag = x, Checked = true })]);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Er gaat iets goed foutig " + ex.Message);
				return false;
			}
		}

		private async Task BackupSaveAndDeleteBackupAsync(string newName)
		{
			var path = Path.Combine(Data, newName + ".json");
			var backup = Path.Combine(newName + ".json.bak");
			try
			{
				if (File.Exists(path))
				{
					if (File.Exists(backup))
						File.Delete(backup);
					File.Move(path, backup);
				}

				path = Path.Combine(Data, newName + ".json");

				var items = this.listView2
					.Items
					.Cast<ListViewItem>()
					.Where(x => x.Tag != null && x.Checked)
					.Select(x => x.Tag?.ToString())
					.ToList();

				if (items.Count > 0)
				{
					using var stream = File.OpenWrite(path);
					await JsonSerializer.SerializeAsync(stream, items);
				}

				var todelete = this.listView2
					.Items
					.Cast<ListViewItem>()
					.Where(x => x.Checked == false)
					.ToList();
				foreach (var item in todelete)
					this.listView2.Items.Remove(item);

				if (File.Exists(backup))
				{
					File.Delete(backup);
					Debug.WriteLine($"Save {path} deleted {backup}");
				}
				else
				{
					Debug.WriteLine($"Save {path} (no backup)");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Er gaat wat foutig " + ex.Message);
			}
		}

		private async void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			await LoadExistingAsync(this.comboBox1.Text);
		}

		private async void Button5_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.comboBox1.Text))
				return;

			await BackupSaveAndDeleteBackupAsync(this.comboBox1.Text);

			for(int i=0;i<this.comboBox1.Items.Count;i++)
			{
				if (this.comboBox1.Items[i]?.ToString() == this.comboBox1.Text)
					return;
			}
			this.comboBox1.Items.Add(this.comboBox1.Text);

		}
	}
}
