using AppSenAgriculture.Views.Account;
using AppSenAgriculture.Views.Parametre;
using AppSenAgriculture.Helper;
using AppSenAgriculture.Models;
using Microsoft.VisualBasic.Devices;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public partial class frmMDI : Form
    {
        public string profil;
        public string identifiantUtilisateur;
        public string emailUtilisateur;
        public string nomCompletUtilisateur;

        public frmMDI()
        {
            InitializeComponent();
            CreerDashboard();
        }

        private void CreerDashboard()
        {
            Panel pnlDashboard = new Panel
            {
                Name = "pnlDashboard",
                Dock = DockStyle.Fill,
                BackColor = ThemeManager.BackgroundColor,
                Padding = new Padding(40, 60, 40, 40)
            };
            Label lblBienvenue = new Label
            {
                Text = "Bienvenue sur SEN AGRICULTURE",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = ThemeManager.PrimaryColor,
                AutoSize = true,
                Location = new Point(40, 60)
            };
            Label lblSousTitre = new Label
            {
                Text = "Système de Gestion Agricole Moderne",
                Font = new Font("Segoe UI", 14F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(40, 110)
            };

            pnlDashboard.Controls.Add(lblBienvenue);
            pnlDashboard.Controls.Add(lblSousTitre);
            CreerStatsCards(pnlDashboard);
            this.Controls.Add(pnlDashboard);
            pnlDashboard.SendToBack();
        }

        private void CreerStatsCards(Panel parent)
        {
            int startY = 180;
            int startX = 60;
            int cardWidth = 280;
            int cardHeight = 160;
            int spacing = 40;
            CreerCard(parent, "Produits", GetNombreProduits().ToString(), 
                     ThemeManager.PrimaryColor, startX, startY, cardWidth, cardHeight);
            CreerCard(parent, "Catégories", GetNombreCategories().ToString(), 
                     ThemeManager.AccentColor, startX + cardWidth + spacing, startY, cardWidth, cardHeight);
            CreerCard(parent, "Clients", GetNombreClients().ToString(), 
                     ThemeManager.SuccessColor, startX + (cardWidth + spacing) * 2, startY, cardWidth, cardHeight);
            Label lblInfo = new Label
            {
                Text = "Utilisez le menu ci-dessus pour accéder aux différentes fonctionnalités",
                Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                ForeColor = Color.FromArgb(120, 120, 120),
                AutoSize = true,
                Location = new Point(startX, startY + cardHeight + 60)
            };
            parent.Controls.Add(lblInfo);
        }

        private void CreerCard(Panel parent, string titre, string valeur, Color couleur, int x, int y, int width, int height)
        {
            Panel card = new Panel
            {
                BackColor = Color.White,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Padding = new Padding(25)
            };
            Panel topBar = new Panel
            {
                BackColor = couleur,
                Dock = DockStyle.Top,
                Height = 6
            };
            Label lblTitre = new Label
            {
                Text = titre,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 80, 80),
                AutoSize = true,
                Location = new Point(25, 25)
            };
            Label lblValeur = new Label
            {
                Text = valeur,
                Font = new Font("Segoe UI", 42F, FontStyle.Bold),
                ForeColor = couleur,
                AutoSize = true,
                Location = new Point(25, 65)
            };

            card.Controls.Add(topBar);
            card.Controls.Add(lblTitre);
            card.Controls.Add(lblValeur);

            parent.Controls.Add(card);
        }

        /// <summary>
        /// Récupère le nombre de produits
        /// </summary>
        private int GetNombreProduits()
        {
            try
            {
                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    return db.produits.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        private int GetNombreCategories()
        {
            try
            {
                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    return db.categories.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        private int GetNombreClients()
        {
            try
            {
                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    return db.clients.Count();
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Ferme tout les formulaires enfants ouverts
        /// </summary>
        private void fermer()
        {
            Form[] charr = this.MdiChildren;

            // Fermer tous les formulaires enfants
            foreach (Form chform in charr)
            {
                chform.Close();
            }

            // Afficher le dashboard quand tous les formulaires sont fermés
            AfficherDashboard();
        }

        /// <summary>
        /// Affiche le dashboard d'accueil
        /// </summary>
        private void AfficherDashboard()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "pnlDashboard")
                {
                    ctrl.Visible = true;
                    ctrl.BringToFront();
                    return;
                }
            }
        }

        private void CacherDashboard()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "pnlDashboard")
                {
                    ctrl.Visible = false;
                    return;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnexion f= new frmConnexion();
            f.Show();
            this.Close();
        }
        private void quitterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            CacherDashboard();
            frmProduit f = new frmProduit();
            f.MdiParent=this;
           f.Show();
            f.WindowState = FormWindowState.Maximized;
        }
        private void cateorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            CacherDashboard();
            frmCategorie f=new frmCategorie();
            f.MdiParent=this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
            ThemeManager.ApplyMDITheme(this, menuStrip2);
            AssignMenuIcons();
            AfficherDashboard();
            if(profil=="Admin")
            {
                parametreToolStripMenuItem.Visible = false;
                securiteToolStripMenuItem.Visible = true;

            }else if (profil=="Client")
            {
                parametreToolStripMenuItem.Visible = true;
                securiteToolStripMenuItem.Visible = false;
            }
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void securiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ouvrir le formulaire client
        /// </summary>
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            CacherDashboard();
            frmClient f = new frmClient();
            f.MdiParent=this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void changerMotDePasseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword f = new frmChangePassword(identifiantUtilisateur, emailUtilisateur, nomCompletUtilisateur);
            f.ShowDialog();
        }

        private static Bitmap ResizeIcon(Icon ico, Size size)
        {
            if (ico == null) return null;
            var bmp = new Bitmap(size.Width, size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawIcon(ico, new Rectangle(0, 0, size.Width, size.Height));
            }
            return bmp;
        }

        private void AssignMenuIcons()
        {
            var sz = new Size(20, 20);
            actionToolStripMenuItem.Image = ResizeIcon(SystemIcons.Application, sz);
            changerMotDePasseToolStripMenuItem.Image = ResizeIcon(SystemIcons.Shield, sz);
            seDeconnecterToolStripMenuItem.Image = ResizeIcon(SystemIcons.Exclamation, sz);
            quitterToolStripMenuItem.Image = ResizeIcon(SystemIcons.Error, sz);
            parametreToolStripMenuItem.Image = ResizeIcon(SystemIcons.WinLogo, sz);
            produitToolStripMenuItem.Image = ResizeIcon(SystemIcons.Information, sz);
            cateorieToolStripMenuItem.Image = ResizeIcon(SystemIcons.Information, sz);
            lToolStripMenuItem.Image = ResizeIcon(SystemIcons.Information, sz);
            securiteToolStripMenuItem.Image = ResizeIcon(SystemIcons.Shield, sz);
            clientToolStripMenuItem.Image = ResizeIcon(SystemIcons.Information, sz);
        }
    }
}
