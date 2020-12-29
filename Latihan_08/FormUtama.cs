using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_08
{
	public partial class FormUtama : Form
	{
        
        public FormUtama()
		{
			InitializeComponent();
		}

		/// <summary>
		/// setting data grid melalui program
		/// </summary>
		void SetupDataGrid()
        {
			dataGridView1.RowHeadersVisible = false;
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;

			//menambahkan checkbox sebagai kolom pertama
			DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
			chk.Name = "Pilihan";
			chk.HeaderText = "Pil";
			chk.Width = 30;
			dataGridView1.Columns.Add(chk);

			//menambahkan textbox pada kolom kedua
			DataGridViewTextBoxColumn tbx = new DataGridViewTextBoxColumn();
			tbx.Name = "tbxFileName";
			tbx.HeaderText = "Nama File";
			tbx.Width = 200;
			tbx.ReadOnly = true;
			dataGridView1.Columns.Add(tbx);
        }

		void tampilkanDaftarFileGambar(string filePath)
		{
			//mengambil nama folder dari lokasi filepath
			string folder = Path.GetDirectoryName(filePath);

			//mengambil semua file yang ada di dalam folder
			string[] daftarFile = Directory.GetFiles(folder);

			//daftar ekstensi yang diperbolehkan
			string[] ekstensi = { ".jpg", ",jpeg", "jpe", "jfif", ".png"};
			foreach(string fn in daftarFile)
			{
				foreach (string eks in ekstensi)
				{
					if (fn.ToLower().EndsWith(eks))
						dataGridView1.Rows.Add(false, Path.GetFileName(fn));
				}
			}
        }

		private void FormUtama_Load(object sender, EventArgs e)
		{
			SetupDataGrid();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			
		}

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

			DialogResult dr = openFileDialog1.ShowDialog();

			if (dr != DialogResult.OK) return;

			string filePath = openFileDialog1.FileName;

			pictureBox1.Image = Image.FromFile(filePath);

			tbxFolder.Text = Path.GetDirectoryName(filePath) + "\\";

			tampilkanDaftarFileGambar(tbxFolder.Text);
				
				
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
			FormSettings formSettings = new FormSettings(this);
			formSettings.ShowDialog();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
			if (dataGridView1.CurrentRow is null) return;
			string fn = (string)dataGridView1.CurrentRow.Cells[1].Value;
			fn = tbxFolder.Text + fn;
			pictureBox1.Image = Image.FromFile(fn);
        }

        private void cbxCol_CheckedChanged(object sender, EventArgs e)
        {
			//splitContainer1.Panel1Collapsed = true;
			this.WindowState = FormWindowState.Normal;
			this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
			this.Height = Screen.PrimaryScreen.WorkingArea.Height;
			this.Location = new Point(0, 0);
		}

		public void event_ChangedLayout()
        {
			Console.WriteLine("Event di call nih");
			Console.WriteLine("Sebelumnya {0}", this.splitContainer1.Panel1Collapsed);
			this.splitContainer1.Panel1Collapsed = true;
			Console.WriteLine("Sesudahny {0}", this.splitContainer1.Panel1Collapsed);
			this.WindowState = FormWindowState.Normal;
			this.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
			this.Height = Screen.PrimaryScreen.WorkingArea.Height;
			this.Location = new Point(0, 0);
		}
	}
}

