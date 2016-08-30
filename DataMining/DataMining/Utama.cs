using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
namespace DataMining
{
    public partial class Utama : Form
    {
        private const string ConnStr = @"server = 127.0.0.1; port = 3306; UID = root; PWD = ; database=pemaketan";

        readonly MySqlConnection _conn = new MySqlConnection(ConnStr);

        public Utama()
        {
            InitializeComponent();
        }

        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f2 = new Persiapan();
            f2.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            const string query = "delete from ordering;";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();

            var f3 = new Asosiasi();
            f3.ShowDialog();
        }

        private void utama_FormClosing(object sender, FormClosingEventArgs e)
        {

            const string query = "delete from transactions; " +
                                 "delete from preprocessing; " +
                                 "delete from ordering;";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();
            // Use this since we are a WinForms app
            System.Windows.Forms.Application.Exit();
        }

        private void preprocessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var prep = new Preprocessing();
            prep.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Persiapan();
            f2.ShowDialog();
        }

        private void btnPreprocessing_Click(object sender, EventArgs e)
        {
            var prep = new Preprocessing();
            prep.ShowDialog();
        }

        private void btnAsosiasi_Click(object sender, EventArgs e)
        {
            var f3 = new SkripSweet.ProsesAsosiasi();
            f3.ShowDialog();
        }

        private void btnPemaketan_Click(object sender, EventArgs e)
        {
            var f4 = new SkripSweet.Pemaketan();
            f4.ShowDialog();
        }
    }
}
