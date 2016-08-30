using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
namespace DataMining
{
    public partial class Preprocessing : Form
    {
        private const string ConnStr = @"server = 127.0.0.1; port = 3306; UID = root; PWD = ; database=pemaketan";

        readonly MySqlConnection _conn = new MySqlConnection(ConnStr);

        private List<string> _noBillList;
        public static List<Item> FrequentItems;
        public static List<ItemSet> ItemSetGlobal;

        public Preprocessing()
        {
            InitializeComponent();
        }

        private void kembaliButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void PilihAtribut_Click(object sender, EventArgs e)
        {
            PilihAtribut();
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            const string query = "SELECT no_transaksi, kode_barang FROM preprocessing";
            var table = new DataTable();
            var cmd = _conn.CreateCommand();

            _conn.Open();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            table.Load(reader);
            _conn.Close();
            dgAtribut.DataSource = table;
            progressBar1.Value = 100;
            if (progressBar1.Value == 100)
            {
                MessageBox.Show(@"Pemilihan Atribut Berhasil!");
            }

        }

        private void Pembersihan_Click(object sender, EventArgs e)
        {
            Pembersihan();
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;
            const string query = "SELECT id, no_transaksi, nama_barang,kode_barang,Jenis,harga,qty,jumlah FROM preprocessing";
            var table = new DataTable();
            var cmd = _conn.CreateCommand();

            _conn.Open();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            table.Load(reader);
            _conn.Close();

            dgPembersihan.DataSource = table;


            progressBar2.Value = 100;
            if (progressBar2.Value == 100)
            {
                MessageBox.Show(@"Pembersihan Jenis Berhasil!");
            }

            Pembersihan2_Proses();
        }
        private void btnPembersihan2_Click(object sender, EventArgs e)
        {
            Pembersihan2();
            pgbPembersihan2.Maximum = 100;
            pgbPembersihan2.Value = 0;
            const string query = "SELECT id, no_transaksi, nama_barang,kode_barang,Jenis,harga,qty,jumlah FROM preprocessing";
            var table = new DataTable();
            var cmd = _conn.CreateCommand();

            _conn.Open();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            table.Load(reader);
            _conn.Close();

            dgPembersihan2.DataSource = table;


            pgbPembersihan2.Value = 100;
            if (pgbPembersihan2.Value == 100)
            {
                MessageBox.Show(@"Pembersihan Data Tunggal Berhasil!");
            }
        }

        private void Pembersihan2_Proses()
        {
            Pembersihan2();
            pgbPembersihan2.Maximum = 100;
            pgbPembersihan2.Value = 0;
            const string query = "SELECT id, no_transaksi, nama_barang,kode_barang,Jenis,harga,qty,jumlah FROM preprocessing";
            var table = new DataTable();
            var cmd = _conn.CreateCommand();

            _conn.Open();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            table.Load(reader);
            _conn.Close();

            dgPembersihan2.DataSource = table;


            pgbPembersihan2.Value = 100;
            if (pgbPembersihan2.Value == 100)
            {
                MessageBox.Show(@"Pembersihan Data Tunggal Berhasil!");
            }
        }
        private void Frekuensi_Click(object sender, EventArgs e)
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

        private void urutData_Click(object sender, EventArgs e)
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

        //insert data
        private void datapreprocessing()
        {
            const string query = "DELETE FROM preprocessing; " +
                                 "INSERT INTO preprocessing (id, no_transaksi, nama_barang,kode_barang,Jenis,harga,qty,jumlah) (SELECT id, no_transaksi, nama_barang,kode_barang,Jenis,harga,qty,jumlah FROM transactions)";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();
        }
        //pemilihan atribut
        private void PilihAtribut()
        {
            const string query = "(SELECT kode_barang, no_transaksi FROM preprocessing)";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();
        }

        //proses pembersihan
        private void Pembersihan()
        {
            const string query = "DELETE FROM preprocessing " +
                                 "WHERE Jenis NOT IN ('SEMBAKO','MKN','MNM','ROKOK') OR nama_barang LIKE '%PAKET%'";
            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();
        }

        private void Pembersihan2()
        {
            const string query = "DELETE FROM preprocessing WHERE no_transaksi IN (SELECT implicitTemp.no_transaksi FROM (SELECT no_transaksi FROM preprocessing GROUP BY no_transaksi HAVING count(no_transaksi) = 1) implicitTemp)";

            _conn.Open();
            var cmd = _conn.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteReader();
            _conn.Close();
        }

        private void PengurutanData()
        {
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

            query = "SELECT kode_barang, nama_barang, frequency FROM ordering";
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

        private void Preprocessing_Load(object sender, EventArgs e)
        {

            datapreprocessing();
        }
    }
}
