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
    public partial class RezervasyonIslemleriFormu : Form
    {
        private RezervasyonDal rezervasyonIslemleriDal;
        private RezervasyonManager _rezervasyonManager;
        private RezervasyonDal _rezervasyonDal;
        private bool isInitializing = false;
        public RezervasyonIslemleriFormu()
        {
            InitializeComponent();
            rezervasyonIslemleriDal = new RezervasyonDal();
            _rezervasyonManager = new RezervasyonManager();
            _rezervasyonDal = new RezervasyonDal();
        }

        private void rezervasyonEkleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (musteriComboBox.SelectedValue == null || odaComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen müşteri ve oda seçiniz.");
                    return;
                }

                int odaID = Convert.ToInt32(odaComboBox.SelectedValue);
                DateTime girisTarihi = girisTarihiPicker.Value;
                DateTime cikisTarihi = cikisTarihiPicker.Value;

                // Çakışma kontrolü
                if (_rezervasyonDal.OdaRezerveMi(odaID, girisTarihi, cikisTarihi))
                {
                    MessageBox.Show("Seçilen tarihler arasında bu oda zaten rezerve edilmiş.");
                    return;
                }

                var rezervasyon = new Rezervasyon
                {
                    MusteriID = Convert.ToInt32(musteriComboBox.SelectedValue),
                    OdaID = odaID,
                    GirisTarihi = girisTarihi,
                    CikisTarihi = cikisTarihi
                };

                if (_rezervasyonManager.Ekle(rezervasyon))
                {
                    MessageBox.Show("Rezervasyon başarıyla eklendi.");
                    ListeyiYenile();
                    TemizleForm();
                }
                else
                {
                    MessageBox.Show("Rezervasyon eklenirken bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void RezervasyonIslemleriFormu_Load(object sender, EventArgs e)
        {
            isInitializing = true; // Form yükleme sırasında bayrağı aktif et

            List<Musteri> musteriler;
            List<Oda> odalar;
            (musteriler, odalar) = _rezervasyonDal.GetMusteriVeOdaBilgileri();

            musteriComboBox.DataSource = musteriler;
            musteriComboBox.DisplayMember = "TamAd";
            musteriComboBox.ValueMember = "MusteriID";

            odaComboBox.DataSource = odalar;
            odaComboBox.DisplayMember = "OdaNumarasi";
            odaComboBox.ValueMember = "OdaID";

            ListeyiYenile();

            isInitializing = false;

        }

        private void girisTarihiPicker_ValueChanged(object sender, EventArgs e)
        {
            int odaID = Convert.ToInt32(odaComboBox.SelectedValue);
            DateTime girisTarihi = girisTarihiPicker.Value;
            DateTime cikisTarihi = cikisTarihiPicker.Value;

            decimal toplamTutar = HesaplaToplamTutar(odaID, girisTarihi, cikisTarihi);
            lblToplamTutar.Text = toplamTutar.ToString("C");
        }

        private void cikisTarihiPicker_ValueChanged(object sender, EventArgs e)
        {
            int odaID = Convert.ToInt32(odaComboBox.SelectedValue);
            DateTime girisTarihi = girisTarihiPicker.Value;
            DateTime cikisTarihi = cikisTarihiPicker.Value;

            decimal toplamTutar = HesaplaToplamTutar(odaID, girisTarihi, cikisTarihi);
            lblToplamTutar.Text = toplamTutar.ToString("C");
        }
        private decimal HesaplaToplamTutar(int odaID, DateTime girisTarihi, DateTime cikisTarihi)
        {
            decimal odaFiyati = 100; 
            int gunSayisi = (cikisTarihi - girisTarihi).Days;

            return odaFiyati * gunSayisi;
        }
        

        private void silBtn_Click(object sender, EventArgs e)
        {
            if (rezervasyonDataGridView.SelectedRows.Count > 0)
            {
                int rezervasyonId = Convert.ToInt32(rezervasyonDataGridView.SelectedRows[0].Cells["RezervasyonID"].Value);
                if (_rezervasyonManager.RezervasyonSil(rezervasyonId))
                {
                    // DataGridView'ı güncelle
                    rezervasyonDataGridView.DataSource = _rezervasyonManager.TumRezervasyonlariGetir();
                    MessageBox.Show("Rezervasyon başarıyla silindi.");
                }
            }
        }

        private void ListeyiYenile()
        {
            rezervasyonDataGridView.DataSource = _rezervasyonManager.TumRezervasyonlariGetir();
            rezervasyonDataGridView.Refresh();
        }

        private void rezervasyonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rezervasyonDataGridView.SelectedRows.Count > 0)
            {
                int rezervasyonId = Convert.ToInt32(rezervasyonDataGridView.SelectedRows[0].Cells["RezervasyonID"].Value);
                var rezervasyon = _rezervasyonManager.RezervasyonGetir(rezervasyonId);

                if (rezervasyon != null)
                {
                    musteriComboBox.SelectedValue = rezervasyon.MusteriID;
                    odaComboBox.SelectedValue = rezervasyon.OdaID;
                    girisTarihiPicker.Value = rezervasyon.GirisTarihi;
                    cikisTarihiPicker.Value = rezervasyon.CikisTarihi;
                }
            }
        }

        private void guncelleBtn_Click(object sender, EventArgs e)
        {
            if (rezervasyonDataGridView.SelectedRows.Count > 0)
            {
                var rezervasyon = new Rezervasyon
                {
                    RezervasyonID = Convert.ToInt32(rezervasyonDataGridView.SelectedRows[0].Cells["RezervasyonID"].Value),
                    MusteriID = Convert.ToInt32(musteriComboBox.SelectedValue),
                    OdaID = Convert.ToInt32(odaComboBox.SelectedValue),
                    GirisTarihi = girisTarihiPicker.Value,
                    CikisTarihi = cikisTarihiPicker.Value
                };

                if (_rezervasyonManager.RezervasyonGuncelle(rezervasyon))
                {
                    rezervasyonDataGridView.DataSource = _rezervasyonManager.TumRezervasyonlariGetir();
                    MessageBox.Show("Rezervasyon başarıyla güncellendi.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiForm yoneticiForm = new YoneticiForm();
            yoneticiForm.Show();
            this.Hide();
        }

        private void odaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) return; // Form yükleme sırasında olayı işleme alma

            if (odaComboBox.SelectedValue != null)
            {
                int odaID;
                if (int.TryParse(odaComboBox.SelectedValue.ToString(), out odaID))
                {
                    DateTime girisTarihi = girisTarihiPicker.Value;
                    DateTime cikisTarihi = cikisTarihiPicker.Value;

                    if (_rezervasyonDal.OdaRezerveMi(odaID, girisTarihi, cikisTarihi))
                    {
                        MessageBox.Show("Seçilen tarihler arasında bu oda zaten rezerve edilmiş.");
                        odaComboBox.SelectedIndex = -1; // Seçimi temizle
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz oda seçimi.");
                }
            }
        }

        private void TemizleForm()
        {
            musteriComboBox.SelectedIndex = -1;
            odaComboBox.SelectedIndex = -1;
            girisTarihiPicker.Value = DateTime.Now;
            cikisTarihiPicker.Value = DateTime.Now.AddDays(1);
        }
    }
}
