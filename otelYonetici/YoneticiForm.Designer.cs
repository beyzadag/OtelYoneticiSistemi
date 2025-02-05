namespace otelYonetici
{
    partial class YoneticiForm
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
            this.odaIslemleriBtn = new System.Windows.Forms.Button();
            this.musteriIslemleriBtn = new System.Windows.Forms.Button();
            this.rezervasyonIslemleriBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // odaIslemleriBtn
            // 
            this.odaIslemleriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.odaIslemleriBtn.Location = new System.Drawing.Point(71, 190);
            this.odaIslemleriBtn.Name = "odaIslemleriBtn";
            this.odaIslemleriBtn.Size = new System.Drawing.Size(154, 123);
            this.odaIslemleriBtn.TabIndex = 0;
            this.odaIslemleriBtn.Text = "Git";
            this.odaIslemleriBtn.UseVisualStyleBackColor = true;
            this.odaIslemleriBtn.Click += new System.EventHandler(this.odaIslemleriBtn_Click);
            // 
            // musteriIslemleriBtn
            // 
            this.musteriIslemleriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.musteriIslemleriBtn.Location = new System.Drawing.Point(536, 190);
            this.musteriIslemleriBtn.Name = "musteriIslemleriBtn";
            this.musteriIslemleriBtn.Size = new System.Drawing.Size(154, 123);
            this.musteriIslemleriBtn.TabIndex = 1;
            this.musteriIslemleriBtn.Text = "Git";
            this.musteriIslemleriBtn.UseVisualStyleBackColor = true;
            this.musteriIslemleriBtn.Click += new System.EventHandler(this.musteriIslemleriBtn_Click);
            // 
            // rezervasyonIslemleriBtn
            // 
            this.rezervasyonIslemleriBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rezervasyonIslemleriBtn.Location = new System.Drawing.Point(298, 190);
            this.rezervasyonIslemleriBtn.Name = "rezervasyonIslemleriBtn";
            this.rezervasyonIslemleriBtn.Size = new System.Drawing.Size(154, 123);
            this.rezervasyonIslemleriBtn.TabIndex = 3;
            this.rezervasyonIslemleriBtn.Text = "Git";
            this.rezervasyonIslemleriBtn.UseVisualStyleBackColor = true;
            this.rezervasyonIslemleriBtn.Click += new System.EventHandler(this.rezervasyonIslemleriBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(77, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Oda İşlemleri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(275, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rezervasyon İşlemleri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(531, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Müşteri İşlemleri";
            // 
            // YoneticiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rezervasyonIslemleriBtn);
            this.Controls.Add(this.musteriIslemleriBtn);
            this.Controls.Add(this.odaIslemleriBtn);
            this.Name = "YoneticiForm";
            this.Text = "Yonetici";
            this.Load += new System.EventHandler(this.YoneticiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button odaIslemleriBtn;
        private System.Windows.Forms.Button musteriIslemleriBtn;
        private System.Windows.Forms.Button rezervasyonIslemleriBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}