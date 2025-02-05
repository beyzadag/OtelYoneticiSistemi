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
using otelYonetici.DAL;
using otelYonetici.Domain;

namespace otelYonetici
{
    public partial class OdaIslemleriFormu : Form
    {
        private readonly OdaManager _odaManager;
        public OdaIslemleriFormu()
        {
            InitializeComponent();
            _odaManager = new OdaManager();
        }

        private void OdaIslemleriFormu_Load(object sender, EventArgs e)
        {
            OdaListele();
        }
        private void OdaListele()
        {
            odaDataGridView.DataSource = null;
            odaDataGridView.DataSource = _odaManager.TumunuGetir();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            var yeniOda = new Oda
            {
                OdaTipi = txtOdaTipi.Text,
                OdaNumarasi = Convert.ToInt32(txtOdaNumarasi.Text),
                Fiyat = Convert.ToDecimal(txtFiyat.Text),
                Durum = txtDurum.Text
            };

            if (_odaManager.OdaEkle(yeniOda))
            {
                MessageBox.Show("Oda başarıyla eklendi.");
                OdaListele();
            }
            else
            {
                MessageBox.Show("Oda eklenirken bir hata oluştu.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (odaDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz odayı seçin.");
                return;
            }

            int odaId = Convert.ToInt32(odaDataGridView.CurrentRow.Cells["OdaID"].Value);

            if (_odaManager.OdaSil(odaId))
            {
                MessageBox.Show("Oda başarıyla silindi.");
                OdaListele();
            }
            else
            {
                MessageBox.Show("Oda silinirken bir hata oluştu.");
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            OdaListele();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (odaDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Lütfen bir oda seçin.");
                return;
            }

            var oda = new Oda
            {
                OdaID = Convert.ToInt32(odaDataGridView.CurrentRow.Cells["OdaID"].Value),
                OdaTipi = txtOdaTipi.Text,
                OdaNumarasi = Convert.ToInt32(txtOdaNumarasi.Text),
                Fiyat = Convert.ToDecimal(txtFiyat.Text),
                Durum = txtDurum.Text
            };

            if (_odaManager.OdaGuncelle(oda))
            {
                MessageBox.Show("Oda başarıyla güncellendi.");
                OdaListele();
            }
            else
            {
                MessageBox.Show("Oda güncellenirken bir hata oluştu.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiForm yoneticiForm = new YoneticiForm();
            yoneticiForm.Show();
            this.Hide();
        }
    }
}

