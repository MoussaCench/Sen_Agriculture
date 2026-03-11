namespace AppSenAgriculture.Views.Account
{
    partial class frmChangePassword
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblUtilisateurInfo = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblAncienMotDePasse = new System.Windows.Forms.Label();
            this.txtAncienMotDePasse = new System.Windows.Forms.TextBox();
            this.lblNouveauMotDePasse = new System.Windows.Forms.Label();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.txtConfirmation = new System.Windows.Forms.TextBox();
            this.lblForceMotDePasse = new System.Windows.Forms.Label();
            this.btnAfficherMotDePasse = new System.Windows.Forms.Button();
            this.pnlRegles = new System.Windows.Forms.Panel();
            this.lblRegles = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlRegles.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.pnlHeader.Controls.Add(this.lblTitre);
            this.pnlHeader.Controls.Add(this.lblUtilisateurInfo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlHeader.Size = new System.Drawing.Size(600, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(30, 20);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(368, 46);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "🔐 Changer mon mot de passe";
            // 
            // lblUtilisateurInfo
            // 
            this.lblUtilisateurInfo.AutoSize = true;
            this.lblUtilisateurInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUtilisateurInfo.ForeColor = System.Drawing.Color.White;
            this.lblUtilisateurInfo.Location = new System.Drawing.Point(33, 66);
            this.lblUtilisateurInfo.Name = "lblUtilisateurInfo";
            this.lblUtilisateurInfo.Size = new System.Drawing.Size(94, 23);
            this.lblUtilisateurInfo.TabIndex = 1;
            this.lblUtilisateurInfo.Text = "Utilisateur :";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblAncienMotDePasse);
            this.pnlForm.Controls.Add(this.txtAncienMotDePasse);
            this.pnlForm.Controls.Add(this.lblNouveauMotDePasse);
            this.pnlForm.Controls.Add(this.txtNouveauMotDePasse);
            this.pnlForm.Controls.Add(this.lblConfirmation);
            this.pnlForm.Controls.Add(this.txtConfirmation);
            this.pnlForm.Controls.Add(this.lblForceMotDePasse);
            this.pnlForm.Controls.Add(this.btnAfficherMotDePasse);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlForm.Location = new System.Drawing.Point(0, 100);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(40, 30, 40, 20);
            this.pnlForm.Size = new System.Drawing.Size(600, 300);
            this.pnlForm.TabIndex = 1;
            // 
            // lblAncienMotDePasse
            // 
            this.lblAncienMotDePasse.AutoSize = true;
            this.lblAncienMotDePasse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAncienMotDePasse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAncienMotDePasse.Location = new System.Drawing.Point(40, 30);
            this.lblAncienMotDePasse.Name = "lblAncienMotDePasse";
            this.lblAncienMotDePasse.Size = new System.Drawing.Size(173, 23);
            this.lblAncienMotDePasse.TabIndex = 0;
            this.lblAncienMotDePasse.Text = "Ancien mot de passe";
            // 
            // txtAncienMotDePasse
            // 
            this.txtAncienMotDePasse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAncienMotDePasse.Location = new System.Drawing.Point(40, 56);
            this.txtAncienMotDePasse.Name = "txtAncienMotDePasse";
            this.txtAncienMotDePasse.Size = new System.Drawing.Size(520, 32);
            this.txtAncienMotDePasse.TabIndex = 1;
            this.txtAncienMotDePasse.UseSystemPasswordChar = true;
            // 
            // lblNouveauMotDePasse
            // 
            this.lblNouveauMotDePasse.AutoSize = true;
            this.lblNouveauMotDePasse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNouveauMotDePasse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNouveauMotDePasse.Location = new System.Drawing.Point(40, 100);
            this.lblNouveauMotDePasse.Name = "lblNouveauMotDePasse";
            this.lblNouveauMotDePasse.Size = new System.Drawing.Size(182, 23);
            this.lblNouveauMotDePasse.TabIndex = 2;
            this.lblNouveauMotDePasse.Text = "Nouveau mot de passe";
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(40, 126);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(520, 32);
            this.txtNouveauMotDePasse.TabIndex = 3;
            this.txtNouveauMotDePasse.UseSystemPasswordChar = true;
            this.txtNouveauMotDePasse.TextChanged += new System.EventHandler(this.txtNouveauMotDePasse_TextChanged);
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.AutoSize = true;
            this.lblConfirmation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmation.Location = new System.Drawing.Point(40, 170);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(194, 23);
            this.lblConfirmation.TabIndex = 4;
            this.lblConfirmation.Text = "Confirmer mot de passe";
            // 
            // txtConfirmation
            // 
            this.txtConfirmation.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmation.Location = new System.Drawing.Point(40, 196);
            this.txtConfirmation.Name = "txtConfirmation";
            this.txtConfirmation.Size = new System.Drawing.Size(520, 32);
            this.txtConfirmation.TabIndex = 5;
            this.txtConfirmation.UseSystemPasswordChar = true;
            // 
            // lblForceMotDePasse
            // 
            this.lblForceMotDePasse.AutoSize = true;
            this.lblForceMotDePasse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblForceMotDePasse.ForeColor = System.Drawing.Color.Gray;
            this.lblForceMotDePasse.Location = new System.Drawing.Point(40, 235);
            this.lblForceMotDePasse.Name = "lblForceMotDePasse";
            this.lblForceMotDePasse.Size = new System.Drawing.Size(0, 20);
            this.lblForceMotDePasse.TabIndex = 6;
            // 
            // btnAfficherMotDePasse
            // 
            this.btnAfficherMotDePasse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.btnAfficherMotDePasse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAfficherMotDePasse.FlatAppearance.BorderSize = 0;
            this.btnAfficherMotDePasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherMotDePasse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAfficherMotDePasse.Location = new System.Drawing.Point(40, 260);
            this.btnAfficherMotDePasse.Name = "btnAfficherMotDePasse";
            this.btnAfficherMotDePasse.Size = new System.Drawing.Size(150, 30);
            this.btnAfficherMotDePasse.TabIndex = 7;
            this.btnAfficherMotDePasse.Text = "👁 Afficher";
            this.btnAfficherMotDePasse.UseVisualStyleBackColor = false;
            this.btnAfficherMotDePasse.Click += new System.EventHandler(this.btnAfficherMotDePasse_Click);
            // 
            // pnlRegles
            // 
            this.pnlRegles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(235)))));
            this.pnlRegles.Controls.Add(this.lblRegles);
            this.pnlRegles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegles.Location = new System.Drawing.Point(0, 400);
            this.pnlRegles.Name = "pnlRegles";
            this.pnlRegles.Padding = new System.Windows.Forms.Padding(40, 20, 40, 20);
            this.pnlRegles.Size = new System.Drawing.Size(600, 120);
            this.pnlRegles.TabIndex = 2;
            // 
            // lblRegles
            // 
            this.lblRegles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblRegles.Location = new System.Drawing.Point(40, 20);
            this.lblRegles.Name = "lblRegles";
            this.lblRegles.Size = new System.Drawing.Size(520, 80);
            this.lblRegles.TabIndex = 0;
            this.lblRegles.Text = "ℹ️ Règles pour un mot de passe sécurisé :\r\n• Minimum 8 caractères\r\n• Au moins 1" +
    " lettre majuscule\r\n• Au moins 1 caractère spécial (!@#$%^&*...)";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnValider);
            this.pnlButtons.Controls.Add(this.btnAnnuler);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 520);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(40, 20, 40, 30);
            this.pnlButtons.Size = new System.Drawing.Size(600, 80);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(295, 20);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(130, 45);
            this.btnValider.TabIndex = 0;
            this.btnValider.Text = "✓ Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAnnuler.Location = new System.Drawing.Point(430, 20);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(130, 45);
            this.btnAnnuler.TabIndex = 1;
            this.btnAnnuler.Text = "✕ Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlRegles);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Changer mon mot de passe";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlRegles.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblUtilisateurInfo;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblAncienMotDePasse;
        private System.Windows.Forms.TextBox txtAncienMotDePasse;
        private System.Windows.Forms.Label lblNouveauMotDePasse;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.Label lblConfirmation;
        private System.Windows.Forms.TextBox txtConfirmation;
        private System.Windows.Forms.Label lblForceMotDePasse;
        private System.Windows.Forms.Button btnAfficherMotDePasse;
        private System.Windows.Forms.Panel pnlRegles;
        private System.Windows.Forms.Label lblRegles;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
    }
}
