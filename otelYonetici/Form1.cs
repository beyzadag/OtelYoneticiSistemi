using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using otelYonetici.Business;

namespace otelYonetici
{
    public partial class Form1 : Form
    {
        private readonly YoneticiGirisManager _yoneticiGirisManager;
        public Form1()
        {
            InitializeComponent();
            _yoneticiGirisManager = new YoneticiGirisManager();
        }

        private void grsBtn_Click(object sender, EventArgs e)
        {
            string yoneticiIsim = yntcTxt.Text.Trim();
            string sifre = sfrTxt.Text.Trim();

            bool girisBasarili = _yoneticiGirisManager.GirisYap(yoneticiIsim, sifre);

            if (girisBasarili)
            {
                MessageBox.Show("Başarıyla giriş yapıldı.", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                YoneticiForm yoneticiForm = new YoneticiForm();
                yoneticiForm.Show();  
                this.Hide();  
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
