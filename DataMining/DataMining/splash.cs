using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkripSweet
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timeLeft = 10;
            timer1.Start();
        }
        
        public int timeLeft { get; set; }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                DataMining.Utama utm = new DataMining.Utama();
                utm.Show();
            }
        }
    }
}
