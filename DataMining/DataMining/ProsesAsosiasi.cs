using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataMining;

namespace SkripSweet
{
    public partial class ProsesAsosiasi : Form
    {
        private const string ConnStr = @"server = 127.0.0.1; port = 3306; UID = root; PWD = ; database=pemaketan";

        readonly MySqlConnection _conn = new MySqlConnection(ConnStr);

        private List<string> _noBillList;
        public static List<Item> FrequentItems;
        public static List<ItemSet> ItemSetGlobal;
        public ProsesAsosiasi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PengurutanData();
            progressBar4.Maximum = 100;
            progressBar4.Value = 0;

            var list = new List<Item>();
            var itemSet = new List<ItemSet>();
            _conn.Open();
            var cmd = _conn.CreateCommand();
            foreach (var nobill in _noBillList)
            {
                var query = "SELECT kode_barang FROM preprocessing WHERE no_transaksi = '" + nobill + "'";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var kodeBarang = (string)reader[0];
                    var itemz = FrequentItems.Find(o => o.Kode.Equals(kodeBarang));
                    if (itemz == null) continue;
                    var freqs = FrequentItems.Find(o => o.Kode.Equals(kodeBarang)).SupportCount;
                    var namaBarang = FrequentItems.Find(o => o.Kode.Equals(kodeBarang)).Symbol;

                    var item = new Item(kodeBarang, namaBarang, freqs);
                    list.Add(item);
                }
                reader.Close();
                var set = new ItemSet(nobill, list);
                if (list.Count > 1)
                {
                    itemSet.Add(set);
                }
                list = new List<Item>();
            }

            var dt = new DataTable();
            dt.Columns.Add("No Transaksi");
            dt.Columns.Add("Barang");
            var items = "";

            foreach (var t in itemSet)
            {
                t.Items = t.Items.OrderByDescending(o => o.SupportCount).ThenBy(x => x.Kode).ToList();
                var row = t.Items;
                items = row.Aggregate(items, (current, item) => current + (item.Kode + ", "));
                items = items.Substring(0, items.Length - 2);
                var arr = new object[] { t.Nobill, items };
                dt.Rows.Add(arr);
                items = "";
            }

            dgUrut.DataSource = dt;
            ItemSetGlobal = itemSet;

            _conn.Close();
            progressBar4.Value = 100;
            if (progressBar4.Value == 100)
            {
                MessageBox.Show(@"Pengurutan Data Berhasil!");
            }
        }

        private void PengurutanData()
        {
            var minSupCount = Convert.ToInt32(minSupTb.Text);
            var query = "SELECT DISTINCT no_transaksi " +
                        "FROM preprocessing";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();

            _noBillList = new List<string>();

            while (reader.Read())
            {
                _noBillList.Add(reader[0].ToString());
            }
            reader.Close();

            query = "SELECT kode_barang, nama_barang, frequency FROM ordering WHERE frequency >= " + minSupCount + "";
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();

            var lizt = new List<Item>();
            while (reader.Read())
            {
                var freq = Convert.ToInt32(reader[2]);
                lizt.Add(new Item((string)reader[0], (string)reader[1], freq));
            }
            reader.Close();
            _conn.Close();

            FrequentItems = lizt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar3.Maximum = 100;
            progressBar3.Value = 0;
            var query = "DELETE FROM ordering;" +
                        "SELECT DISTINCT kode_barang, nama_barang FROM preprocessing ORDER BY kode_barang;";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();

            var listKodeBarang = new List<string>();
            var listNamaBarang = new List<string>();
            while (reader.Read())
            {
                listKodeBarang.Add((string)reader[0]);
                listNamaBarang.Add((string)reader[1]);
            }
            reader.Close();

            for (var i = 0; i < listKodeBarang.Count; i++)
            {
                query += "INSERT INTO ordering (kode_barang, nama_barang, frequency) "
                    + "VALUES('" + listKodeBarang[i] + "', '" + listNamaBarang[i] + "', 0);";
            }
            cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            reader.Close();

            query = "SELECT kode_barang, COUNT(*) AS frekuensi " +
                    "FROM preprocessing " +
                    "GROUP BY kode_barang " +
                    "ORDER BY kode_barang ASC;";

            cmd.CommandText = query;
            reader = cmd.ExecuteReader();

            listNamaBarang = new List<string>();
            var listFreq = new List<int>();
            while (reader.Read())
            {
                listNamaBarang.Add((string)reader[0]);
                listFreq.Add(Convert.ToInt32((long)reader[1]));
            }
            reader.Close();

            query = "";
            for (var i = 0; i < listFreq.Count; i++)
            {
                query += "UPDATE ordering set frequency = " + listFreq[i] + " WHERE kode_barang = '" + listNamaBarang[i] + "';";
            }
            cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            reader.Close();

            query = "SELECT kode_barang, frequency FROM ordering ORDER BY frequency DESC";
            cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();

            var tableFreq = new DataTable();
            tableFreq.Columns.Add("Kode Barang");
            tableFreq.Columns.Add("Frequency");
            while (reader.Read())
            {
                var id = (string)reader[0];
                var freq = (int)reader[1] + "";
                var arr = new object[] { id, freq };
                tableFreq.Rows.Add(arr);
            }

            dgFrekuensi.DataSource = tableFreq;

            reader.Close();
            _conn.Close();
            progressBar3.Value = 100;
            if (progressBar3.Value == 100)
            {
                MessageBox.Show(@"Pengitungan Frekuensi Berhasil!");
            }
        }

        private void kembaliButton_Click(object sender, EventArgs e)
        {
            const string query = "delete from ordering;";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();

            var f3 = new Asosiasi();
            f3.ShowDialog();

            this.Close();
        }
    }
}
