namespace AppSenAgriculture
{
    partial class frmConnexion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.pnlAppBar = new System.Windows.Forms.Panel();
            this.btnFermer = new System.Windows.Forms.Button();
            this.lblTitreApp = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblConnexion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnSeConnecter = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();

            this.pnlAppBar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tableLayout.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();

            this.pnlAppBar.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.pnlAppBar.Controls.Add(this.btnFermer);
            this.pnlAppBar.Controls.Add(this.lblTitreApp);
            this.pnlAppBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAppBar.Location = new System.Drawing.Point(0, 0);
            this.pnlAppBar.Name = "pnlAppBar";
            this.pnlAppBar.Size = new System.Drawing.Size(900, 44);
            this.pnlAppBar.TabIndex = 2;

            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.BackColor = System.Drawing.Color.Transparent;
            this.btnFermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFermer.FlatAppearance.BorderSize = 0;
            this.btnFermer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(856, 0);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(44, 44);
            this.btnFermer.TabIndex = 7;
            this.btnFermer.Text = "✕";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnQuitter_Click);

            this.lblTitreApp.AutoSize = true;
            this.lblTitreApp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblTitreApp.ForeColor = System.Drawing.Color.White;
            this.lblTitreApp.Location = new System.Drawing.Point(14, 10);
            this.lblTitreApp.Name = "lblTitreApp";
            this.lblTitreApp.Size = new System.Drawing.Size(180, 28);
            this.lblTitreApp.TabIndex = 0;
            this.lblTitreApp.Text = "SenAgriculture";

            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.pnlMain.Controls.Add(this.tableLayout);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.TabIndex = 0;

            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Size = new System.Drawing.Size(900, 506);
            this.tableLayout.TabIndex = 0;
            this.tableLayout.Controls.Add(this.pnlLeft, 0, 0);
            this.tableLayout.Controls.Add(this.pnlRight, 1, 0);

            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Controls.Add(this.lblTagline);
            this.pnlLeft.Controls.Add(this.lblBrand);

            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(20, 160);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(220, 60);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "SenAgriculture";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(220, 235, 255);
            this.lblTagline.Location = new System.Drawing.Point(20, 220);
            this.lblTagline.MaximumSize = new System.Drawing.Size(220, 0);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(220, 30);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "Système de Gestion Agricole";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(40);
            this.pnlRight.TabIndex = 1;
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.txtIdentifiant);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.txtMotDePasse);
            this.pnlRight.Controls.Add(this.btnQuitter);
            this.pnlRight.Controls.Add(this.btnSeConnecter);
            this.pnlRight.Controls.Add(this.lblConnexion);

            this.lblConnexion.AutoSize = true;
            this.lblConnexion.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblConnexion.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblConnexion.Location = new System.Drawing.Point(40, 30);
            this.lblConnexion.Name = "lblConnexion";
            this.lblConnexion.Size = new System.Drawing.Size(180, 50);
            this.lblConnexion.TabIndex = 0;
            this.lblConnexion.Text = "Connexion";

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.label1.Location = new System.Drawing.Point(40, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Identifiant";

            this.txtIdentifiant.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtIdentifiant.Location = new System.Drawing.Point(40, 148);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(260, 37);
            this.txtIdentifiant.TabIndex = 2;
            this.txtIdentifiant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.label2.Location = new System.Drawing.Point(40, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mot de passe";

            this.txtMotDePasse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMotDePasse.Location = new System.Drawing.Point(40, 238);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(260, 37);
            this.txtMotDePasse.TabIndex = 4;
            this.txtMotDePasse.UseSystemPasswordChar = true;
            this.txtMotDePasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnSeConnecter.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSeConnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeConnecter.FlatAppearance.BorderSize = 0;
            this.btnSeConnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeConnecter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSeConnecter.ForeColor = System.Drawing.Color.White;
            this.btnSeConnecter.Location = new System.Drawing.Point(180, 310);
            this.btnSeConnecter.Name = "btnSeConnecter";
            this.btnSeConnecter.Size = new System.Drawing.Size(120, 44);
            this.btnSeConnecter.TabIndex = 6;
            this.btnSeConnecter.Text = "Se connecter";
            this.btnSeConnecter.UseVisualStyleBackColor = false;
            this.btnSeConnecter.Click += new System.EventHandler(this.btnSeConnecter_Click);

            this.btnQuitter.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuitter.ForeColor = System.Drawing.Color.White;
            this.btnQuitter.Location = new System.Drawing.Point(40, 310);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(120, 44);
            this.btnQuitter.TabIndex = 5;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SenAgriculture - Connexion";
            this.Load += new System.EventHandler(this.frmConnexion_Load);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlAppBar);

            this.pnlAppBar.ResumeLayout(false);
            this.pnlAppBar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tableLayout.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlAppBar;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label lblTitreApp;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblConnexion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Button btnSeConnecter;
        private System.Windows.Forms.Button btnQuitter;
    }
}
