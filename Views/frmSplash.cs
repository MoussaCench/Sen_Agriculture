using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AppSenAgriculture.Helper;

namespace AppSenAgriculture.Views
{
    /// <summary>
    /// Écran de démarrage moderne pour Sen Agriculture
    /// </summary>
    public partial class frmSplash : Form
    {
        private int progress = 0;
        private System.Windows.Forms.Timer timer;

        public frmSplash()
        {
            InitializeComponent();
            InitialiserDesign();
            InitialiserTimer();
        }

        private void InitialiserDesign()
        {
            // Configuration du formulaire
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(600, 400);
            this.BackColor = Color.White;

            // Panel avec dégradé de couleur
            Panel pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(pnlMain);

            // Effet de peinture personnalisé pour le dégradé
            pnlMain.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    pnlMain.ClientRectangle,
                    ThemeManager.PrimaryColor,
                    ThemeManager.AccentColor,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, pnlMain.ClientRectangle);
                }
            };

            // Titre
            Label lblTitle = new Label
            {
                Text = "SEN AGRICULTURE",
                Font = new Font("Segoe UI", 32F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            pnlMain.Controls.Add(lblTitle);
            lblTitle.Location = new Point((pnlMain.Width - lblTitle.Width) / 2, 80);

            // Sous-titre
            Label lblSubtitle = new Label
            {
                Text = "Système de Gestion Agricole",
                Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            pnlMain.Controls.Add(lblSubtitle);
            lblSubtitle.Location = new Point((pnlMain.Width - lblSubtitle.Width) / 2, 150);

            // Icône ou logo (cercle avec texte)
            Panel pnlLogo = new Panel
            {
                Size = new Size(80, 80),
                BackColor = Color.Transparent,
                Location = new Point((pnlMain.Width - 80) / 2, 200)
            };
            pnlMain.Controls.Add(pnlLogo);

            pnlLogo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, 80, 80);
                }
                using (SolidBrush brush = new SolidBrush(ThemeManager.PrimaryColor))
                {
                    e.Graphics.DrawString("🌾", new Font("Segoe UI", 32F), brush, 15, 10);
                }
            };

            // Barre de progression
            ProgressBar progressBar = new ProgressBar
            {
                Size = new Size(400, 20),
                Location = new Point((pnlMain.Width - 400) / 2, 300),
                Style = ProgressBarStyle.Continuous,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(200, 255, 255, 255)
            };
            pnlMain.Controls.Add(progressBar);

            // Label de statut
            Label lblStatus = new Label
            {
                Text = "Initialisation...",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point((pnlMain.Width - 100) / 2, 330)
            };
            pnlMain.Controls.Add(lblStatus);

            // Stockage des contrôles pour y accéder dans le timer
            this.Tag = new { ProgressBar = progressBar, StatusLabel = lblStatus };
        }

        private void InitialiserTimer()
        {
            timer = new Timer { Interval = 30 };
            timer.Tick += (s, e) =>
            {
                progress += 2;

                var controls = (dynamic)this.Tag;
                ProgressBar progressBar = controls.ProgressBar;
                Label lblStatus = controls.StatusLabel;

                progressBar.Value = Math.Min(progress, 100);

                // Messages de statut selon la progression
                if (progress < 30)
                    lblStatus.Text = "Chargement des modules...";
                else if (progress < 60)
                    lblStatus.Text = "Connexion à la base de données...";
                else if (progress < 90)
                    lblStatus.Text = "Initialisation de l'interface...";
                else
                    lblStatus.Text = "Démarrage...";

                if (progress >= 100)
                {
                    timer.Stop();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
            timer.Start();
        }
    }
}
