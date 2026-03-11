namespace AppSenAgriculture.Views.Parametre
{
    partial class frmProduit
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
            // ✅ FIX: Déclarations groupées et ordonnées logiquement
            this.pnlFormulaire   = new System.Windows.Forms.Panel();
            this.label1          = new System.Windows.Forms.Label();
            this.txtLibelle      = new System.Windows.Forms.TextBox();
            this.label2          = new System.Windows.Forms.Label();
            this.txtDescription  = new System.Windows.Forms.TextBox();
            this.label3          = new System.Windows.Forms.Label();
            this.txtPrixUMin     = new System.Windows.Forms.TextBox();
            this.label4          = new System.Windows.Forms.Label();
            this.txtPrixUMax     = new System.Windows.Forms.TextBox();
            this.label5          = new System.Windows.Forms.Label();
            this.cbbUniteMesure  = new System.Windows.Forms.ComboBox();
            this.label6          = new System.Windows.Forms.Label();
            this.cbbCategorie    = new System.Windows.Forms.ComboBox();
            this.pnlBoutons      = new System.Windows.Forms.Panel();
            this.btnAjouter      = new System.Windows.Forms.Button();
            this.btnModifier     = new System.Windows.Forms.Button();
            this.btnSupprimer    = new System.Windows.Forms.Button();
            this.pnlDroite       = new System.Windows.Forms.Panel();
            this.grpRecherche    = new System.Windows.Forms.GroupBox();
            this.label7          = new System.Windows.Forms.Label();
            this.txtRLibelle     = new System.Windows.Forms.TextBox();
            this.label8          = new System.Windows.Forms.Label();
            this.txtRDescription = new System.Windows.Forms.TextBox();
            this.label9          = new System.Windows.Forms.Label();
            this.txtRPrixUMin    = new System.Windows.Forms.TextBox();
            this.btnRechercher   = new System.Windows.Forms.Button();
            this.btnSelectionner = new System.Windows.Forms.Button();
            this.dgProduit       = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgProduit)).BeginInit();
            this.pnlFormulaire.SuspendLayout();
            this.pnlBoutons.SuspendLayout();
            this.pnlDroite.SuspendLayout();
            this.grpRecherche.SuspendLayout();
            this.SuspendLayout();

            // ──────────────────────────────────────────────────────────────
            // pnlFormulaire — colonne gauche (formulaire de saisie)
            // ✅ FIX: Utilisation d'un Panel pour regrouper les champs de saisie
            //         au lieu de les laisser flottants sur le form
            // ──────────────────────────────────────────────────────────────
            this.pnlFormulaire.Location  = new System.Drawing.Point(10, 10);
            this.pnlFormulaire.Name      = "pnlFormulaire";
            this.pnlFormulaire.Size      = new System.Drawing.Size(420, 540);
            this.pnlFormulaire.TabIndex  = 0;
            this.pnlFormulaire.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label1, this.txtLibelle,
                this.label2, this.txtDescription,
                this.label3, this.txtPrixUMin,
                this.label4, this.txtPrixUMax,
                this.label5, this.cbbUniteMesure,
                this.label6, this.cbbCategorie,
                this.pnlBoutons
            });

            // label1 — Libellé
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name     = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text     = "Libellé *";

            // txtLibelle
            this.txtLibelle.Location  = new System.Drawing.Point(0, 22);
            this.txtLibelle.Name      = "txtLibelle";
            this.txtLibelle.Size      = new System.Drawing.Size(400, 26);
            this.txtLibelle.TabIndex  = 1;
            this.txtLibelle.MaxLength = 200;

            // label2 — Description
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 62);
            this.label2.Name     = "label2";
            this.label2.TabIndex = 2;
            this.label2.Text     = "Description";

            // txtDescription
            this.txtDescription.Location   = new System.Drawing.Point(0, 84);
            this.txtDescription.Multiline  = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Name       = "txtDescription";
            this.txtDescription.Size       = new System.Drawing.Size(400, 70);
            this.txtDescription.TabIndex   = 3;
            this.txtDescription.MaxLength  = 500;

            // label3 — Prix Min
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 168);
            this.label3.Name     = "label3";
            this.label3.TabIndex = 4;
            this.label3.Text     = "Prix Unitaire Minimum";

            // txtPrixUMin
            this.txtPrixUMin.Location  = new System.Drawing.Point(0, 190);
            this.txtPrixUMin.Name      = "txtPrixUMin";
            this.txtPrixUMin.Size      = new System.Drawing.Size(400, 26);
            this.txtPrixUMin.TabIndex  = 5;

            // label4 — Prix Max
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 230);
            this.label4.Name     = "label4";
            this.label4.TabIndex = 6;
            this.label4.Text     = "Prix Unitaire Maximum";

            // txtPrixUMax
            this.txtPrixUMax.Location = new System.Drawing.Point(0, 252);
            this.txtPrixUMax.Name     = "txtPrixUMax";
            this.txtPrixUMax.Size     = new System.Drawing.Size(400, 26);
            this.txtPrixUMax.TabIndex = 7;

            // label5 — Unité de Mesure
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 292);
            this.label5.Name     = "label5";
            this.label5.TabIndex = 8;
            this.label5.Text     = "Unité de Mesure *";

            // cbbUniteMesure
            this.cbbUniteMesure.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUniteMesure.FormattingEnabled = true;
            this.cbbUniteMesure.Location          = new System.Drawing.Point(0, 314);
            this.cbbUniteMesure.Name              = "cbbUniteMesure";
            this.cbbUniteMesure.Size              = new System.Drawing.Size(400, 28);
            this.cbbUniteMesure.TabIndex          = 9;

            // label6 — Catégorie
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 356);
            this.label6.Name     = "label6";
            this.label6.TabIndex = 10;
            this.label6.Text     = "Catégorie *";

            // cbbCategorie
            this.cbbCategorie.DropDownStyle     = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategorie.FormattingEnabled = true;
            this.cbbCategorie.Location          = new System.Drawing.Point(0, 378);
            this.cbbCategorie.Name              = "cbbCategorie";
            this.cbbCategorie.Size              = new System.Drawing.Size(400, 28);
            this.cbbCategorie.TabIndex          = 11;

            // ──────────────────────────────────────────────────────────────
            // pnlBoutons — rangée de boutons CRUD
            // ✅ FIX: Panel dédié pour les boutons, layout plus propre
            // ──────────────────────────────────────────────────────────────
            this.pnlBoutons.Location = new System.Drawing.Point(0, 425);
            this.pnlBoutons.Name     = "pnlBoutons";
            this.pnlBoutons.Size     = new System.Drawing.Size(400, 50);
            this.pnlBoutons.TabIndex = 12;
            this.pnlBoutons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAjouter, this.btnModifier, this.btnSupprimer
            });

            // btnAjouter
            this.btnAjouter.Location = new System.Drawing.Point(0, 0);
            this.btnAjouter.Name     = "btnAjouter";
            this.btnAjouter.Size     = new System.Drawing.Size(120, 40);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text     = "&Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);

            // btnModifier
            this.btnModifier.Location = new System.Drawing.Point(140, 0);
            this.btnModifier.Name     = "btnModifier";
            this.btnModifier.Size     = new System.Drawing.Size(120, 40);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text     = "&Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);

            // btnSupprimer
            this.btnSupprimer.Location = new System.Drawing.Point(280, 0);
            this.btnSupprimer.Name     = "btnSupprimer";
            this.btnSupprimer.Size     = new System.Drawing.Size(120, 40);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text     = "&Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);

            // ──────────────────────────────────────────────────────────────
            // pnlDroite — colonne droite (recherche + grille)
            // ✅ FIX: Panel droite pour mieux gérer le redimensionnement
            // ──────────────────────────────────────────────────────────────
            this.pnlDroite.Anchor = (
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right);
            this.pnlDroite.Location = new System.Drawing.Point(450, 10);
            this.pnlDroite.Name     = "pnlDroite";
            this.pnlDroite.Size     = new System.Drawing.Size(820, 730);
            this.pnlDroite.TabIndex = 1;
            this.pnlDroite.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.grpRecherche, this.btnSelectionner, this.dgProduit
            });

            // ──────────────────────────────────────────────────────────────
            // grpRecherche
            // ✅ FIX: Renommé groupBox1 → grpRecherche (nom descriptif)
            // ──────────────────────────────────────────────────────────────
            this.grpRecherche.Anchor = (
                System.Windows.Forms.AnchorStyles.Top  |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right);
            this.grpRecherche.BackColor = System.Drawing.Color.White;
            this.grpRecherche.Location  = new System.Drawing.Point(0, 0);
            this.grpRecherche.Name      = "grpRecherche";
            this.grpRecherche.Padding   = new System.Windows.Forms.Padding(10);
            this.grpRecherche.Size      = new System.Drawing.Size(820, 130);
            this.grpRecherche.TabIndex  = 0;
            this.grpRecherche.TabStop   = false;
            this.grpRecherche.Text      = "Recherche";
            this.grpRecherche.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.label7, this.txtRLibelle,
                this.label8, this.txtRDescription,
                this.label9, this.txtRPrixUMin,
                this.btnRechercher
            });

            // label7 — Libellé recherche
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Name     = "label7";
            this.label7.TabIndex = 0;
            this.label7.Text     = "Libellé";

            // txtRLibelle
            this.txtRLibelle.Location  = new System.Drawing.Point(15, 55);
            this.txtRLibelle.Name      = "txtRLibelle";
            this.txtRLibelle.Size      = new System.Drawing.Size(195, 26);
            this.txtRLibelle.TabIndex  = 1;

            // label8 — Description recherche
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 30);
            this.label8.Name     = "label8";
            this.label8.TabIndex = 2;
            this.label8.Text     = "Description";

            // txtRDescription
            this.txtRDescription.Location = new System.Drawing.Point(230, 55);
            this.txtRDescription.Name     = "txtRDescription";
            this.txtRDescription.Size     = new System.Drawing.Size(195, 26);
            this.txtRDescription.TabIndex = 3;

            // label9 — Prix Min recherche
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(445, 30);
            this.label9.Name     = "label9";
            this.label9.TabIndex = 4;
            this.label9.Text     = "Prix Min.";

            // txtRPrixUMin
            this.txtRPrixUMin.Location = new System.Drawing.Point(445, 55);
            this.txtRPrixUMin.Name     = "txtRPrixUMin";
            this.txtRPrixUMin.Size     = new System.Drawing.Size(180, 26);
            this.txtRPrixUMin.TabIndex = 5;

            // btnRechercher
            this.btnRechercher.Anchor   = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRechercher.Location = new System.Drawing.Point(665, 50);
            this.btnRechercher.Name     = "btnRechercher";
            this.btnRechercher.Size     = new System.Drawing.Size(130, 40);
            this.btnRechercher.TabIndex = 6;
            this.btnRechercher.Text     = "&Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);

            // btnSelectionner
            this.btnSelectionner.Location = new System.Drawing.Point(0, 145);
            this.btnSelectionner.Name     = "btnSelectionner";
            this.btnSelectionner.Size     = new System.Drawing.Size(150, 40);
            this.btnSelectionner.TabIndex = 1;
            this.btnSelectionner.Text     = "&Sélectionner";
            this.btnSelectionner.UseVisualStyleBackColor = true;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);

            // dgProduit
            // ✅ FIX: Anchor correct pour que la grille s'étire avec la fenêtre
            this.dgProduit.Anchor = (
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right);
            this.dgProduit.AllowUserToAddRows    = false;
            this.dgProduit.AllowUserToDeleteRows = false;
            this.dgProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProduit.Location         = new System.Drawing.Point(0, 195);
            this.dgProduit.Name             = "dgProduit";
            this.dgProduit.ReadOnly         = true;
            this.dgProduit.RowHeadersVisible = false;
            this.dgProduit.RowTemplate.Height = 35;
            this.dgProduit.SelectionMode    = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProduit.Size             = new System.Drawing.Size(820, 535);
            this.dgProduit.TabIndex         = 2;
            this.dgProduit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProduit_CellDoubleClick);

            // ──────────────────────────────────────────────────────────────
            // frmProduit
            // ──────────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1290, 760);
            this.ControlBox          = false;
            this.Font                = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin              = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize         = new System.Drawing.Size(1200, 700);
            this.Name                = "frmProduit";
            this.Padding             = new System.Windows.Forms.Padding(10);
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Gestion des Produits";
            this.Load               += new System.EventHandler(this.frmProduit_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlFormulaire,
                this.pnlDroite
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgProduit)).EndInit();
            this.pnlFormulaire.ResumeLayout(false);
            this.pnlFormulaire.PerformLayout();
            this.pnlBoutons.ResumeLayout(false);
            this.pnlDroite.ResumeLayout(false);
            this.grpRecherche.ResumeLayout(false);
            this.grpRecherche.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Formulaire gauche
        private System.Windows.Forms.Panel          pnlFormulaire;
        private System.Windows.Forms.Label          label1;
        private System.Windows.Forms.TextBox        txtLibelle;
        private System.Windows.Forms.Label          label2;
        private System.Windows.Forms.TextBox        txtDescription;
        private System.Windows.Forms.Label          label3;
        private System.Windows.Forms.TextBox        txtPrixUMin;
        private System.Windows.Forms.Label          label4;
        private System.Windows.Forms.TextBox        txtPrixUMax;
        private System.Windows.Forms.Label          label5;
        private System.Windows.Forms.ComboBox       cbbUniteMesure;
        private System.Windows.Forms.Label          label6;
        private System.Windows.Forms.ComboBox       cbbCategorie;
        private System.Windows.Forms.Panel          pnlBoutons;
        private System.Windows.Forms.Button         btnAjouter;
        private System.Windows.Forms.Button         btnModifier;
        private System.Windows.Forms.Button         btnSupprimer;

        // Panneau droit
        private System.Windows.Forms.Panel          pnlDroite;
        private System.Windows.Forms.GroupBox       grpRecherche;
        private System.Windows.Forms.Label          label7;
        private System.Windows.Forms.TextBox        txtRLibelle;
        private System.Windows.Forms.Label          label8;
        private System.Windows.Forms.TextBox        txtRDescription;
        private System.Windows.Forms.Label          label9;
        private System.Windows.Forms.TextBox        txtRPrixUMin;
        private System.Windows.Forms.Button         btnRechercher;
        private System.Windows.Forms.Button         btnSelectionner;
        private System.Windows.Forms.DataGridView   dgProduit;
    }
}
