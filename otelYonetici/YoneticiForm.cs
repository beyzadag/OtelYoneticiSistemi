using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otelYonetici
{
    public partial class YoneticiForm : Form
    {
        public YoneticiForm()
        {
            InitializeComponent();
        }

        private void odaIslemleriBtn_Click(object sender, EventArgs e)
        {
            OdaIslemleriFormu odaForm = new OdaIslemleriFormu();
            odaForm.Show();  
            this.Hide();
        }

        private void musteriIslemleriBtn_Click(object sender, EventArgs e)
        {
            MusteriIslemleriFormu musteriForm = new MusteriIslemleriFormu();
            musteriForm.Show();  
            this.Hide();
        }

        private void rezervasyonIslemleriBtn_Click(object sender, EventArgs e)
        {
            RezervasyonIslemleriFormu rezervasyonForm = new RezervasyonIslemleriFormu();
            rezervasyonForm.Show();  
            this.Hide();
        }

        private void YoneticiForm_Load(object sender, EventArgs e)
        {

        }
    }
}
