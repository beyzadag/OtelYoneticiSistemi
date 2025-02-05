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
using otelYonetici.Domain;

namespace otelYonetici
{
    public partial class MusteriIslemleriFormu : Form
    {
        private readonly MusteriManager _musteriManager;
        public MusteriIslemleriFormu()
        {
            InitializeComponent();
            _musteriManager = new MusteriManager();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var yeniMusteri = new Musteri
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Telefon = txtTelefon.Text, 
                    Eposta = txtEposta.Text
                };

                if (_musteriManager.MusteriEkle(yeniMusteri))
                {
                    MessageBox.Show("Müşteri başarıyla eklendi.");
                    MusteriListele();
                }
                else
                {
                    MessageBox.Show("Müşteri eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (musteriDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçin.");
                return;
            }

            try
            {
                int musteriId = Convert.ToInt32(musteriDataGridView.CurrentRow.Cells["MusteriID"].Value);

                if (_musteriManager.MusteriSil(musteriId))
                {
                    MessageBox.Show("Müşteri başarıyla silindi.");
                    MusteriListele();
                }
                else
                {
                    MessageBox.Show("Müşteri silinirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (musteriDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir müşteri seçin.");
                return;
            }

            try
            {
                var musteri = new Musteri
                {
                    MusteriID = Convert.ToInt32(musteriDataGridView.CurrentRow.Cells["MusteriID"].Value),
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Eposta = txtEposta.Text
                };

                if (_musteriManager.MusteriGuncelle(musteri))
                {
                    MessageBox.Show("Müşteri başarıyla güncellendi.");
                    MusteriListele();
                }
                else
                {
                    MessageBox.Show("Müşteri güncellenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            MusteriListele();
        }

        private void MusteriIslemleriFormu_Load(object sender, EventArgs e)
        {
            MusteriListele();
        }
        private void MusteriListele()
        {
            musteriDataGridView.DataSource = null;
            musteriDataGridView.DataSource = _musteriManager.TumMusterileriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiForm yoneticiForm = new YoneticiForm();
            yoneticiForm.Show();
            this.Hide();
        }
    }
}
