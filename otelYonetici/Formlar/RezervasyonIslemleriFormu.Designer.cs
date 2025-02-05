namespace otelYonetici
{
    partial class RezervasyonIslemleriFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.girisTarihiPicker = new System.Windows.Forms.DateTimePicker();
            this.cikisTarihiPicker = new System.Windows.Forms.DateTimePicker();
            this.odaComboBox = new System.Windows.Forms.ComboBox();
            this.musteriComboBox = new System.Windows.Forms.ComboBox();
            this.rezervasyonEkleBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rezervasyonDataGridView = new System.Windows.Forms.DataGridView();
            this.silBtn = new System.Windows.Forms.Button();
            this.guncelleBtn = new System.Windows.Forms.Button();
            this.listeleBtn = new System.Windows.Forms.Button();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rezervasyonDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // girisTarihiPicker
            // 
            this.girisTarihiPicker.Location = new System.Drawing.Point(146, 138);
            this.girisTarihiPicker.Name = "girisTarihiPicker";
            this.girisTarihiPicker.Size = new System.Drawing.Size(200, 22);
            this.girisTarihiPicker.TabIndex = 3;
            this.girisTarihiPicker.ValueChanged += new System.EventHandler(this.girisTarihiPicker_ValueChanged);
            // 
            // cikisTarihiPicker
            // 
            this.cikisTarihiPicker.Location = new System.Drawing.Point(146, 187);
            this.cikisTarihiPicker.Name = "cikisTarihiPicker";
            this.cikisTarihiPicker.Size = new System.Drawing.Size(200, 22);
            this.cikisTarihiPicker.TabIndex = 4;
            this.cikisTarihiPicker.ValueChanged += new System.EventHandler(this.cikisTarihiPicker_ValueChanged);
            // 
            // odaComboBox
            // 
            this.odaComboBox.FormattingEnabled = true;
            this.odaComboBox.Location = new System.Drawing.Point(146, 95);
            this.odaComboBox.Name = "odaComboBox";
            this.odaComboBox.Size = new System.Drawing.Size(200, 24);
            this.odaComboBox.TabIndex = 5;
            this.odaComboBox.SelectedIndexChanged += new System.EventHandler(this.odaComboBox_SelectedIndexChanged);
            // 
            // musteriComboBox
            // 
            this.musteriComboBox.FormattingEnabled = true;
            this.musteriComboBox.Location = new System.Drawing.Point(146, 54);
            this.musteriComboBox.Name = "musteriComboBox";
            this.musteriComboBox.Size = new System.Drawing.Size(200, 24);
            this.musteriComboBox.TabIndex = 6;
            // 
            // rezervasyonEkleBtn
            // 
            this.rezervasyonEkleBtn.Location = new System.Drawing.Point(12, 317);
            this.rezervasyonEkleBtn.Name = "rezervasyonEkleBtn";
            this.rezervasyonEkleBtn.Size = new System.Drawing.Size(94, 78);
            this.rezervasyonEkleBtn.TabIndex = 7;
            this.rezervasyonEkleBtn.Text = "Ekle";
            this.rezervasyonEkleBtn.UseVisualStyleBackColor = true;
            this.rezervasyonEkleBtn.Click += new System.EventHandler(this.rezervasyonEkleBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Müşteri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Oda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Giriş Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Çıkış Tarihi";
            // 
            // rezervasyonDataGridView
            // 
            this.rezervasyonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rezervasyonDataGridView.Location = new System.Drawing.Point(477, 36);
            this.rezervasyonDataGridView.Name = "rezervasyonDataGridView";
            this.rezervasyonDataGridView.RowHeadersWidth = 51;
            this.rezervasyonDataGridView.RowTemplate.Height = 24;
            this.rezervasyonDataGridView.Size = new System.Drawing.Size(292, 376);
            this.rezervasyonDataGridView.TabIndex = 13;
            this.rezervasyonDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rezervasyonDataGridView_CellContentClick);
            // 
            // silBtn
            // 
            this.silBtn.Location = new System.Drawing.Point(124, 317);
            this.silBtn.Name = "silBtn";
            this.silBtn.Size = new System.Drawing.Size(94, 78);
            this.silBtn.TabIndex = 14;
            this.silBtn.Text = "Sil";
            this.silBtn.UseVisualStyleBackColor = true;
            this.silBtn.Click += new System.EventHandler(this.silBtn_Click);
            // 
            // guncelleBtn
            // 
            this.guncelleBtn.Location = new System.Drawing.Point(237, 317);
            this.guncelleBtn.Name = "guncelleBtn";
            this.guncelleBtn.Size = new System.Drawing.Size(94, 78);
            this.guncelleBtn.TabIndex = 15;
            this.guncelleBtn.Text = "Güncelle";
            this.guncelleBtn.UseVisualStyleBackColor = true;
            this.guncelleBtn.Click += new System.EventHandler(this.guncelleBtn_Click);
            // 
            // listeleBtn
            // 
            this.listeleBtn.Location = new System.Drawing.Point(346, 317);
            this.listeleBtn.Name = "listeleBtn";
            this.listeleBtn.Size = new System.Drawing.Size(94, 78);
            this.listeleBtn.TabIndex = 16;
            this.listeleBtn.Text = "Listele";
            this.listeleBtn.UseVisualStyleBackColor = true;
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.Location = new System.Drawing.Point(210, 286);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(44, 16);
            this.lblToplamTutar.TabIndex = 17;
            this.lblToplamTutar.Text = "label6";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(12, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 22);
            this.button1.TabIndex = 18;
            this.button1.Text = "← (Unicode: \\u2190";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RezervasyonIslemleriFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.listeleBtn);
            this.Controls.Add(this.guncelleBtn);
            this.Controls.Add(this.silBtn);
            this.Controls.Add(this.rezervasyonDataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rezervasyonEkleBtn);
            this.Controls.Add(this.musteriComboBox);
            this.Controls.Add(this.odaComboBox);
            this.Controls.Add(this.cikisTarihiPicker);
            this.Controls.Add(this.girisTarihiPicker);
            this.Name = "RezervasyonIslemleriFormu";
            this.Text = "RezervasyonIslemleriFormu";
            this.Load += new System.EventHandler(this.RezervasyonIslemleriFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rezervasyonDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker girisTarihiPicker;
        private System.Windows.Forms.DateTimePicker cikisTarihiPicker;
        private System.Windows.Forms.ComboBox odaComboBox;
        private System.Windows.Forms.ComboBox musteriComboBox;
        private System.Windows.Forms.Button rezervasyonEkleBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView rezervasyonDataGridView;
        private System.Windows.Forms.Button silBtn;
        private System.Windows.Forms.Button guncelleBtn;
        private System.Windows.Forms.Button listeleBtn;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.Button button1;
    }
}