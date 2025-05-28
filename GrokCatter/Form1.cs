
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

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

			ListView_SizeChanged(this.listView1, null);
			ListView_SizeChanged(this.listView2, null);

			this.textBox1.Text = GetSolFile();

			FillComboBox();
		}

		private void FillComboBox()
		{
			this.comboBox1.Items.Clear();
			var files = Directory.GetFiles(Data, "*.json");
			this.comboBox1.Items.AddRange([.. files.Select(x => Path.GetFileNameWithoutExtension(x))]);
		}

		private string GetSolFile()
		{
			try
			{
				// Zoek alle Visual Studio-processen (devenv.exe)
				var processes = Process.GetProcessesByName("devenv");
				if (processes.Length == 0)
				{
					Console.WriteLine("Geen Visual Studio-processen gevonden.");
					return string.Empty;
				}

				foreach (var process in processes)
				{
					try
					{
						using (var searcher = new System.Management.ManagementObjectSearcher(
					$"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}"))
						{
							string commandLine = searcher.Get().Cast<System.Management.ManagementObject>()
								.FirstOrDefault()?["CommandLine"]?.ToString() ?? "";
							Console.WriteLine($"CommandLine voor proces {process.Id}: {commandLine}");

							var args = Regex.Matches(commandLine, @"(""[^""]+""|[^\s""]+)+")
								.Cast<Match>().Select(m => m.Value.Trim('"')).ToList();
							foreach (var arg in args)
							{
								if (arg.Contains("Catter")) continue;
								if (arg.EndsWith(".sln", StringComparison.OrdinalIgnoreCase) && File.Exists(arg))
								{
									Console.WriteLine($"Oplossingspad gevonden: {arg}");
									return Path.GetDirectoryName( arg);
								}
							}
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Fout bij proces {process.Id}: {ex.Message}");
					}
				}

				Console.WriteLine("Geen oplossingspad gevonden in de commandoregel.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Algemene fout: " + ex.Message);
			}
			return string.Empty;
		}

		private void ShowFiles(object sender, EventArgs e)
		{
			try
			{
				this.listView1.Items.Clear();

				var dir = this.textBox1.Text.Trim();
				if (!Directory.Exists(dir))
					return;

				var len = dir.Length;

				var files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);

				foreach (var file in files)
				{
					var name = file[len..];
					if (name.Contains("\\obj\\", StringComparison.CurrentCultureIgnoreCase) ||
						name.Contains("\\bin\\", StringComparison.CurrentCultureIgnoreCase) ||
						name.Contains("\\.vs\\", StringComparison.CurrentCultureIgnoreCase) ||
						name.Contains("\\.git", StringComparison.CurrentCultureIgnoreCase) ||
						name.Contains("\\.config\\", StringComparison.CurrentCultureIgnoreCase) ||
						name.Contains(".user", StringComparison.CurrentCultureIgnoreCase) ||
						name.Contains("Development.json", StringComparison.CurrentCultureIgnoreCase)
						) 
							continue;
					var ext = Path.GetExtension(name);

					var blnChecked = ext == ".cs" || ext == ".cshtml" || ext == ".html" || ext == ".htm";
					var item = new ListViewItem(name) { Checked = blnChecked, Tag = file };

					listView1.Items.Add(item);
				}

				//CheckBox1_CheckedChanged(sender, e);
			}
			catch (Exception ex)
			{
			}
		}

		private async void Button2_Click(object sender, EventArgs e)
		{
			var sb = new StringBuilder();
			var selectedItems = listView2.Items.Cast<ListViewItem>().ToList();
			foreach (var selectedItem in selectedItems)
			{
				var file = selectedItem?.Tag?.ToString();
				if (file == null)
					continue;
				if (!File.Exists(file))
					continue;
				var text = await File.ReadAllTextAsync(file);
				sb.AppendLine();
				sb.AppendLine($"// -- BEGIN {file} --");
				sb.AppendLine(text);
				sb.AppendLine($"// -- END {file} --");
			}
			Clipboard.SetText(sb.ToString());
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in this.listView1.Items)
			{
				lvi.Checked = this.checkBox1.Checked;
			}
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
					await JsonSerializer.SerializeAsync(stream, items, new JsonSerializerOptions() { WriteIndented = true } );
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

			for (int i = 0; i < this.comboBox1.Items.Count; i++)
			{
				if (this.comboBox1.Items[i]?.ToString() == this.comboBox1.Text)
					return;
			}
			this.comboBox1.Items.Add(this.comboBox1.Text);

		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			ShowFiles(sender, e);
		}

		private void ListView_SizeChanged(object sender, EventArgs e)
		{
			var listView = sender as ListView;
			int aantalKolommen = listView1.Columns.Count;
			if (aantalKolommen > 0)
			{
				int breedtePerKolom = listView.ClientSize.Width / aantalKolommen;
				foreach (ColumnHeader kolom in listView.Columns)
				{
					kolom.Width = breedtePerKolom;
				}
			}
		}

		
	}
}
