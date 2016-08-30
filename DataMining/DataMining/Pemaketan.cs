using DataMining;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkripSweet
{
    public partial class Pemaketan : Form
    {
        private const string ConnStr = @"server = 127.0.0.1; port = 3306; UID = root; PWD = ; database=pemaketan";

        readonly MySqlConnection _conn = new MySqlConnection(ConnStr);
        readonly MySqlConnection _conn2 = new MySqlConnection(ConnStr);
        readonly MySqlConnection _conn3 = new MySqlConnection(ConnStr);
        readonly MySqlConnection _conn4 = new MySqlConnection(ConnStr);

        private int minimum;
        private int maximum;
        public Pemaketan()
        {
            InitializeComponent();
            daftarPaket();
        }

        private void daftarPaket()
        {
            int no = 1;
            //var query = "SET @rownr=0; SELECT (@rownr := @rownr + 1) as No Paket, rules as Paket FROM rules WHERE paket > 1";
            var query = "SELECT barang as Paket, id_paket FROM paket";

            var cmd = _conn.CreateCommand();
            var cmd2 = _conn2.CreateCommand();
            var cmd3 = _conn3.CreateCommand();
            var cmd4 = _conn3.CreateCommand();
            _conn.Open();
            _conn2.Open();
            _conn3.Open();
            _conn4.Open();
            cmd.CommandText = query;

            var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Columns.Add("No Paket");
            table.Columns.Add("Produk Paket");
            table.Columns.Add("Harga Paket");
            while (reader.Read())
            {
                var no_paket = "Paket " + (int)reader[1];
                var harga = 0;

                var query3 = "SELECT harga FROM transactions WHERE nama_barang = '" + sep((string)reader[0].ToString().Trim()) + "' LIMIT 1";
                cmd3.CommandText = query3;
                var reader3 = cmd3.ExecuteReader();
                reader3.Read();
                harga += (int)reader3[0];
                reader3.Close();


                var barang = Regex.Match((string)reader[0], @"\{([^)]*)\}").Groups[1].Value;

                string[] splitBarang = barang.Split(",".ToCharArray());
                for (var i = 0; i < splitBarang.Count(); i++)
                {
                    var query2 = "SELECT harga FROM transactions WHERE nama_barang = '"+splitBarang[i].Trim()+"' LIMIT 1";
                    cmd2.CommandText = query2;
                    var reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        harga += (int)reader2[0];
                        System.Diagnostics.Debug.Write((int)reader2[0]);
                    }
                    reader2.Close();
                }
                var paket = (string)reader[0];
                System.Diagnostics.Debug.Write(paket);
                var arr = new object[] { no_paket, paket, harga };
                table.Rows.Add(arr);

                var query4 = "UPDATE paket SET harga = '"+harga+"' WHERE id_paket = '"+ (int)reader[1] + "'";
                cmd4.CommandText = query4;
                var reader4 = cmd4.ExecuteReader();
                reader4.Close();
            }
            dataGridView1.DataSource = table;
            reader.Close();
            _conn.Close();
            _conn2.Close();
        }
        private void lihatPaket_Click(object sender, EventArgs e)
        {
            minimum = Convert.ToInt32(txtMinimum.Text);
            maximum = Convert.ToInt32(txtMaximum.Text);
            var query = "SELECT barang as Paket, id_paket, harga FROM paket WHERE harga >= '"+ minimum + "' AND harga <= '"+ maximum + "' ORDER BY harga ASC LIMIT 2";
            var cmd = _conn.CreateCommand();
            _conn.Open();
            cmd.CommandText = query;

            var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Columns.Add("No Paket");
            table.Columns.Add("Produk Paket");
            table.Columns.Add("Harga Paket");

            while (reader.Read())
            {
                var no_paket = "Paket " + (int)reader[1];
                var arr = new object[] { no_paket, (string)reader[0], (int)reader[2] };
                table.Rows.Add(arr);
            }

            dataGridView2.DataSource = table;
            reader.Close();
        }

        private static string sep(string s)
        {
            int l = s.IndexOf("-");
            if (l > 0)
            {
                return s.Substring(0, l);
            }
            return "";

        }
    }
}
