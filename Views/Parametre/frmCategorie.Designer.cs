namespace AppSenAgriculture.Views.Parametre
{
    partial class frmCategorie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlFormulaire   = new System.Windows.Forms.Panel();
            this.label1          = new System.Windows.Forms.Label();
            this.txtCode         = new System.Windows.Forms.TextBox();
            this.label2          = new System.Windows.Forms.Label();
            this.txtLibelle      = new System.Windows.Forms.TextBox();
            this.pnlBoutons      = new System.Windows.Forms.Panel();
            this.btnAjouter      = new System.Windows.Forms.Button();
            this.btnModifier     = new System.Windows.Forms.Button();
            this.btnSupprimer    = new System.Windows.Forms.Button();
            this.pnlDroite       = new System.Windows.Forms.Panel();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.dgCategorie     = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgCategorie)).BeginInit();
            this.pnlFormulaire.SuspendLayout();
            this.pnlBoutons.SuspendLayout();
            this.pnlDroite.SuspendLayout();
            this.SuspendLayout();

            // ──────────────────────────────────────────────────────────────
            // pnlFormulaire — colonne gauche (formulaire de saisie)
            // ──────────────────────────────────────────────────────────────
            this.pnlFormulaire.Location  = new System.Drawing.Point(10, 10);
            this.pnlFormulaire.Name      = "pnlFormulaire";
            this.pnlFormulaire.Size      = new System.Drawing.Size(400, 350);
            this.pnlFormulaire.TabIndex  = 0;
            this.pnlFormulaire.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label1, this.txtCode,
                this.label2, this.txtLibelle,
                this.pnlBoutons
            });

            // label1 — Code
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name     = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text     = "Code";

            // txtCode
            this.txtCode.Location  = new System.Drawing.Point(0, 22);
            this.txtCode.Name      = "txtCode";
            this.txtCode.Size      = new System.Drawing.Size(380, 26);
            this.txtCode.TabIndex  = 1;
            this.txtCode.MaxLength = 50;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);

            // label2 — Libellé
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 62);
            this.label2.Name     = "label2";
            this.label2.TabIndex = 2;
            this.label2.Text     = "Libellé";

            // txtLibelle
            this.txtLibelle.Location   = new System.Drawing.Point(0, 84);
            this.txtLibelle.Multiline  = true;
            this.txtLibelle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLibelle.Name       = "txtLibelle";
            this.txtLibelle.Size       = new System.Drawing.Size(380, 100);
            this.txtLibelle.TabIndex   = 3;
            this.txtLibelle.MaxLength  = 200;

            // ──────────────────────────────────────────────────────────────
            // pnlBoutons — rangée de boutons CRUD
            // ──────────────────────────────────────────────────────────────
            this.pnlBoutons.Location = new System.Drawing.Point(0, 205);
            this.pnlBoutons.Name     = "pnlBoutons";
            this.pnlBoutons.Size     = new System.Drawing.Size(380, 50);
            this.pnlBoutons.TabIndex = 4;
            this.pnlBoutons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAjouter, this.btnModifier, this.btnSupprimer
            });

            // btnAjouter
            this.btnAjouter.Location = new System.Drawing.Point(0, 0);
            this.btnAjouter.Name     = "btnAjouter";
            this.btnAjouter.Size     = new System.Drawing.Size(115, 40);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text     = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);

            // btnModifier
            this.btnModifier.Location = new System.Drawing.Point(130, 0);
            this.btnModifier.Name     = "btnModifier";
            this.btnModifier.Size     = new System.Drawing.Size(115, 40);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text     = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);

            // btnSupprimer
            this.btnSupprimer.Location = new System.Drawing.Point(260, 0);
            this.btnSupprimer.Name     = "btnSupprimer";
            this.btnSupprimer.Size     = new System.Drawing.Size(115, 40);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text     = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);

            // ──────────────────────────────────────────────────────────────
            // pnlDroite — colonne droite (grille)
            // ──────────────────────────────────────────────────────────────
            this.pnlDroite.Anchor = (
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right);
            this.pnlDroite.Location = new System.Drawing.Point(430, 10);
            this.pnlDroite.Name     = "pnlDroite";
            this.pnlDroite.Size     = new System.Drawing.Size(640, 630);
            this.pnlDroite.TabIndex = 1;
            this.pnlDroite.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnSelectionner, this.dgCategorie
            });

            // btnSelectionner
            this.btnSelectionner.Location = new System.Drawing.Point(0, 0);
            this.btnSelectionner.Name     = "btnSelectionner";
            this.btnSelectionner.Size     = new System.Drawing.Size(150, 40);
            this.btnSelectionner.TabIndex = 0;
            this.btnSelectionner.Text     = "&Sélectionner";
            this.btnSelectionner.UseVisualStyleBackColor = true;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);

            // dgCategorie
            this.dgCategorie.Anchor = (
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right);
            this.dgCategorie.AllowUserToAddRows    = false;
            this.dgCategorie.AllowUserToDeleteRows = false;
            this.dgCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategorie.Location         = new System.Drawing.Point(0, 50);
            this.dgCategorie.Name             = "dgCategorie";
            this.dgCategorie.ReadOnly         = true;
            this.dgCategorie.RowHeadersVisible = false;
            this.dgCategorie.RowTemplate.Height = 35;
            this.dgCategorie.SelectionMode    = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCategorie.Size             = new System.Drawing.Size(640, 580);
            this.dgCategorie.TabIndex         = 1;

            // ──────────────────────────────────────────────────────────────
            // frmCategorie
            // ──────────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1100, 660);
            this.ControlBox          = false;
            this.Font                = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin              = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize         = new System.Drawing.Size(1000, 600);
            this.Name                = "frmCategorie";
            this.Padding             = new System.Windows.Forms.Padding(10);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Gestion des Catégories";
            this.Load               += new System.EventHandler(this.frmCategorie_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlFormulaire,
                this.pnlDroite
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgCategorie)).EndInit();
            this.pnlFormulaire.ResumeLayout(false);
            this.pnlFormulaire.PerformLayout();
            this.pnlBoutons.ResumeLayout(false);
            this.pnlDroite.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Formulaire gauche
        private System.Windows.Forms.Panel      pnlFormulaire;
        private System.Windows.Forms.Label      label1;
        private System.Windows.Forms.TextBox    txtCode;
        private System.Windows.Forms.Label      label2;
        private System.Windows.Forms.TextBox    txtLibelle;
        private System.Windows.Forms.Panel      pnlBoutons;
        private System.Windows.Forms.Button     btnAjouter;
        private System.Windows.Forms.Button     btnModifier;
        private System.Windows.Forms.Button     btnSupprimer;

        // Panneau droit
        private System.Windows.Forms.Panel          pnlDroite;
        private System.Windows.Forms.Button         btnSelectionner;
        private System.Windows.Forms.DataGridView   dgCategorie;
    }
}
