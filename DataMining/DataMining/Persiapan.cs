using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb; //koneksi ke Ms. Excel
using MySql.Data.MySqlClient;

namespace DataMining
{
    public partial class Persiapan : Form
    {
        private const string ConnStr = @"server = 127.0.0.1; port = 3306; UID = root; PWD = ; database=pemaketan";

        readonly MySqlConnection _conn = new MySqlConnection(ConnStr);

        public Persiapan()
        {
            InitializeComponent();
        }

        void buka_file()
        {
            try
            {
                var constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                textBox1.Text +
                                ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                const string sheet = "Sheet1";
                var con = new OleDbConnection(constr);
                var sda = new OleDbDataAdapter("SELECT * from [" + sheet + "$]", con);
                var dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //untuk mencari file excel
        private void button3_Click(object sender, EventArgs e)
        {
            var op1 = new OpenFileDialog
            {
                Title = @"Select File",
                InitialDirectory = @"C:\Users\Putra Purba\Documents",
                FileName = textBox1.Text,
                Filter = @"Excel Sheet (*.xlsx)|*.xlsx|All Files(*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (op1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op1.FileName;
                Application.DoEvents();
            }
            buka_file();
        }

        //menghapus data lama saat memasukkan data baru
        private void hapus_penjualan()
        {
            const string query = "DELETE FROM transactions";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();
        }

        private void SimpanData()
        {
            try
            {
                hapus_penjualan();
                var recordLength = dataGridView1.Rows.Count;
                var query = "";

                _conn.Open();
                var cmd = _conn.CreateCommand();
                for (var i = 0; i < recordLength - 1; i++)
                {
                    query += "INSERT INTO transactions (id, no_transaksi, nama_barang, kode_barang,Jenis, qty, harga, jumlah)" +
                            " values(" +
                            "" + (i + 1) + ", " +
                             "'" + dataGridView1.Rows[i].Cells[0].Value + "', " +
                             "'" + dataGridView1.Rows[i].Cells[1].Value + "', " +
                             "'" + dataGridView1.Rows[i].Cells[2].Value + "', " +
                             "'" + dataGridView1.Rows[i].Cells[3].Value + "', " +
                             "'" + dataGridView1.Rows[i].Cells[4].Value + "', " +
                             "'" + dataGridView1.Rows[i].Cells[5].Value + "', " +
                             "'" + dataGridView1.Rows[i].Cells[6].Value + "');";
                }
                cmd.CommandText = query;
                cmd.ExecuteReader();
                _conn.Close();


                MessageBox.Show(@"Data Berhasil Disimpan");
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                MessageBox.Show(@"Data Gagal Disimpan");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimpanData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
