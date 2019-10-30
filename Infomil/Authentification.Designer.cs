namespace Infomil
{
    partial class frmAuthentification
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
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAbandonner = new System.Windows.Forms.Button();
            this.lblUtilisateur = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(317, 63);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 0;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAbandonner
            // 
            this.btnAbandonner.Location = new System.Drawing.Point(399, 62);
            this.btnAbandonner.Name = "btnAbandonner";
            this.btnAbandonner.Size = new System.Drawing.Size(75, 23);
            this.btnAbandonner.TabIndex = 1;
            this.btnAbandonner.Text = "Abandonner";
            this.btnAbandonner.UseVisualStyleBackColor = true;
            this.btnAbandonner.Click += new System.EventHandler(this.btnAbandonner_Click);
            // 
            // lblUtilisateur
            // 
            this.lblUtilisateur.AutoSize = true;
            this.lblUtilisateur.Location = new System.Drawing.Point(13, 13);
            this.lblUtilisateur.Name = "lblUtilisateur";
            this.lblUtilisateur.Size = new System.Drawing.Size(53, 13);
            this.lblUtilisateur.TabIndex = 2;
            this.lblUtilisateur.Text = "Utilisateur";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(13, 39);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(71, 13);
            this.lblMotDePasse.TabIndex = 4;
            this.lblMotDePasse.Text = "Mot de passe";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(107, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(367, 20);
            this.textBox2.TabIndex = 5;
            // 
            // frmAuthentification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 100);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblUtilisateur);
            this.Controls.Add(this.btnAbandonner);
            this.Controls.Add(this.btnValider);
            this.Name = "frmAuthentification";
            this.Text = "Athentification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAbandonner;
        private System.Windows.Forms.Label lblUtilisateur;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.TextBox textBox2;
    }
}

