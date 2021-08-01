namespace Pomocnik_3._0
{
    partial class Logowanie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logowanie));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxLogowanieHaslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonZaloguj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLogowanieLogin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pomocnik_3._0.Properties.Resources.keyLogoin;
            this.pictureBox1.Location = new System.Drawing.Point(269, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxLogowanieHaslo
            // 
            this.textBoxLogowanieHaslo.Location = new System.Drawing.Point(39, 80);
            this.textBoxLogowanieHaslo.Name = "textBoxLogowanieHaslo";
            this.textBoxLogowanieHaslo.PasswordChar = '*';
            this.textBoxLogowanieHaslo.Size = new System.Drawing.Size(177, 20);
            this.textBoxLogowanieHaslo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło";
            // 
            // buttonZaloguj
            // 
            this.buttonZaloguj.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.buttonZaloguj.Location = new System.Drawing.Point(141, 115);
            this.buttonZaloguj.Name = "buttonZaloguj";
            this.buttonZaloguj.Size = new System.Drawing.Size(75, 23);
            this.buttonZaloguj.TabIndex = 5;
            this.buttonZaloguj.Text = "Zaloguj";
            this.buttonZaloguj.UseVisualStyleBackColor = false;
            this.buttonZaloguj.Click += new System.EventHandler(this.buttonZaloguj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // textBoxLogowanieLogin
            // 
            this.textBoxLogowanieLogin.Location = new System.Drawing.Point(39, 40);
            this.textBoxLogowanieLogin.Name = "textBoxLogowanieLogin";
            this.textBoxLogowanieLogin.Size = new System.Drawing.Size(177, 20);
            this.textBoxLogowanieLogin.TabIndex = 2;
            // 
            // Logowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(449, 175);
            this.Controls.Add(this.buttonZaloguj);
            this.Controls.Add(this.textBoxLogowanieHaslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLogowanieLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Logowanie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logowanie";
            this.Load += new System.EventHandler(this.Logowanie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxLogowanieHaslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonZaloguj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLogowanieLogin;
    }
}

