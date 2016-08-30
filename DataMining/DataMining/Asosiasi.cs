using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DataMining
{
    public partial class Asosiasi : Form
    {
        private FpTree _fpTreeGlobal;
        private double _minConf;
        private double _conf;
        private readonly List<Item> _frequentItems;
        private readonly List<ItemSet> _itemSetGlobal;

        private const string ConnStr = @"server = 127.0.0.1; port = 3306; UID = root; PWD = ; database=pemaketan";

        readonly MySqlConnection _conn = new MySqlConnection(ConnStr);

        public Asosiasi()
        {
            _frequentItems = SkripSweet.ProsesAsosiasi.FrequentItems;
            _itemSetGlobal = SkripSweet.ProsesAsosiasi.ItemSetGlobal;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void Analisis_Click(object sender, EventArgs e)
        {
            if (!minConfTb.Text.Equals(""))
            {
                _minConf = Convert.ToDouble(minConfTb.Text);

                _fpTreeGlobal = new FpTree(_frequentItems, _itemSetGlobal);
                GenerateFrequentItemSets();
            }
            else
            {
                MessageBox.Show(@"Minimum Support Count dan Minimum Confidence tidak boleh kosong",
                                @"Alert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private int _totalAb;
        private int _totalA;

        private void GenerateFrequentItemSets()
        {
            var frequentItems = _fpTreeGlobal.FrequentItems;
            System.Diagnostics.Debug.WriteLine("This is the frequent items:");
            var patternItems = new List<List<ItemSet>>();

            foreach (var anItem in frequentItems)
            {
                var anItemSet = new ItemSet();
                anItemSet.AddItem(anItem);
                Console.WriteLine(@"Mine this -> " + anItem.Symbol);
                Mine(_fpTreeGlobal, anItemSet);
                if (_mamas.Count <= 0) continue;
                patternItems.Add(_mamas);

                foreach (var thisitem
                    in from itemSet
                    in _mamas
                       let thisitem = itemSet.Items.Aggregate("set: ", (current, item) => current + (item.Symbol + ", "))
                       select thisitem + (" - " + itemSet.Coda))
                {
                    Console.WriteLine(thisitem);
                }

                _mamas = new List<ItemSet>();
            }

            var dt = new DataTable();

            dt.Columns.Add("Rule");
            dt.Columns.Add("Confidence");
            var forcon = "";

            _conn.Open();
            var cmd1 = new MySqlCommand("Truncate rules; Truncate paket", _conn);
            var reader1 = cmd1.ExecuteReader();
            reader1.Close();

            var c = 0;
            foreach (var t in patternItems)
            {
                foreach (var t1 in t)
                {
                    var row = t1.Items;
                    var itemList = row.Select(item => item.Symbol).ToList();
                    _totalAb = _itemSetGlobal
                        .Select(t2 => t2.Items.Select(item => item.Symbol).ToList())
                        .Select(itemset => itemset.Intersect(itemList)).Count(isectList => isectList.Count() >= row.Count);
                    //                    foreach (
                    //                        var isectList
                    //                        in _itemSetGlobal
                    //                        .Select(t2 => t2.Items.Select(item => item.Symbol).ToList())
                    //                        .Select(itemset => itemset.Intersect(itemList))
                    //                        .Where(isectList => isectList.Count() >= row.Count))
                    //                    {
                    //                        _totalAb++;
                    //                    }
                    _totalA = frequentItems.Find(x => x.Symbol.Equals(row[0].Symbol)).SupportCount;

                    Console.WriteLine(_totalAb + @" - " + _totalA);

                    _conf = (_totalAb * 1.0 / _totalA * 1.0) * (100 * 1.0);

                    if ((_conf) >= _minConf)
                    {
                        var conclusion = "Jika " + row[0].Symbol + " dibeli, maka ";
                        var sup = (_totalAb * 1.0 / _itemSetGlobal.Count * 1.0) * (100 * 1.0);

                        var items = row[0].Symbol + " -> { ";
                        int paket = 0;
                        for (var k = 1; k < row.Count; k++)
                        {
                            items += t1.Items[k].Symbol + ", ";
                            forcon += t1.Items[k].Symbol + ", ";
                            paket++;

                        }

                        items = items.Substring(0, items.Length - 2);
                        items += " }";

                        c++;
                        conclusion += forcon + " juga akan dibeli dengan confidence: " + _conf;
                        textBox3.AppendText((c) + ". " + conclusion + "\n\n");
                        forcon = "";

                        object[] arr = { items, Math.Round(_conf, 0) + "%" };
                        dt.Rows.Add(arr);
                        if (paket > 1 )
                        {
                            var cmd =
                            new MySqlCommand(
                                "INSERT INTO paket (id_paket, barang, harga) VALUES ('','"+ items + "','0'); INSERT INTO rules VALUES(NULL, '" + items + "', '" + Math.Round(sup, 0) + "','" + Math.Round(_conf, 0) + "')",
                                _conn);
                            var reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                        else
                        {
                            var cmd =
                            new MySqlCommand(
                                "INSERT INTO rules () VALUES (NULL, '" + items + "', '" + Math.Round(sup, 0) + "','" + Math.Round(_conf, 0) + "')",
                                _conn);
                            var reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                        
                        
                    }
                    _totalAb = 0;
                }
            }
            _conn.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumn(0);
            dataGridView1.AutoResizeColumn(1);
        }

        List<ItemSet> _mamas = new List<ItemSet>();
        private void Mine(FpTree fpTree, ItemSet anItemSet)
        {
            var projectedTree = fpTree.Project(anItemSet.GetLastItem());
            foreach (var anItem in projectedTree.FrequentItems)
            {
                Console.WriteLine(@"Next mine: " + anItem.Symbol);
                var nextItemSet = anItemSet.Clone();
                nextItemSet.AddItem(anItem);

                var setOfItem = nextItemSet.Clone();
                _mamas.Add(setOfItem);

                Mine(projectedTree, nextItemSet);
            }
        }
    }
}