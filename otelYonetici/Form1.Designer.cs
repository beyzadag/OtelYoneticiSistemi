namespace otelYonetici
{
    partial class Form1
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
            this.grsBtn = new System.Windows.Forms.Button();
            this.sfrTxt = new System.Windows.Forms.TextBox();
            this.yntcTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grsBtn
            // 
            this.grsBtn.BackColor = System.Drawing.Color.LawnGreen;
            this.grsBtn.Location = new System.Drawing.Point(267, 284);
            this.grsBtn.Name = "grsBtn";
            this.grsBtn.Size = new System.Drawing.Size(244, 83);
            this.grsBtn.TabIndex = 0;
            this.grsBtn.Text = "Giriş Yap";
            this.grsBtn.UseVisualStyleBackColor = false;
            this.grsBtn.Click += new System.EventHandler(this.grsBtn_Click);
            // 
            // sfrTxt
            // 
            this.sfrTxt.Location = new System.Drawing.Point(230, 197);
            this.sfrTxt.Multiline = true;
            this.sfrTxt.Name = "sfrTxt";
            this.sfrTxt.Size = new System.Drawing.Size(344, 35);
            this.sfrTxt.TabIndex = 1;
            // 
            // yntcTxt
            // 
            this.yntcTxt.Location = new System.Drawing.Point(230, 136);
            this.yntcTxt.Multiline = true;
            this.yntcTxt.Name = "yntcTxt";
            this.yntcTxt.Size = new System.Drawing.Size(344, 35);
            this.yntcTxt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(66, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yönetici ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(84, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yntcTxt);
            this.Controls.Add(this.sfrTxt);
            this.Controls.Add(this.grsBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button grsBtn;
        private System.Windows.Forms.TextBox sfrTxt;
        private System.Windows.Forms.TextBox yntcTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

