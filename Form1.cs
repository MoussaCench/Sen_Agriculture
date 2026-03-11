using AppSenAgriculture.Helper;
using AppSenAgriculture.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public partial class frmConnexion : Form
    {
        public frmConnexion()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {

            try 
            {

                BdSenAgricultureContext db = new BdSenAgricultureContext();
                var leUser = db.utilisateurs.Where(a => a.IdentifiantUtilisateur.ToLower() == txtIdentifiant.Text.ToLower()).FirstOrDefault();

                if (leUser != null)
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if (Crypto.VerifyMd5Hash(md5Hash, txtMotDePasse.Text, leUser.MotDePasseUtilisateur))
                        {
                            frmMDI f = new frmMDI();

                            var admin = db.admins.FirstOrDefault(a => a.ID == leUser.ID);
                            if (admin != null)
                            {

                                f.profil = "Admin";
                                f.identifiantUtilisateur = leUser.IdentifiantUtilisateur;
                                f.emailUtilisateur = leUser.EmailUtilisateur;
                                f.nomCompletUtilisateur = leUser.NomCompletUtilisateur;

                            }
                            else if (db.clients.Where(a => a.ID == leUser.ID).FirstOrDefault() != null)
                            {

                                f.profil = "Client";
                                f.identifiantUtilisateur = leUser.IdentifiantUtilisateur;
                                f.emailUtilisateur = leUser.EmailUtilisateur;
                                f.nomCompletUtilisateur = leUser.NomCompletUtilisateur;

                            }

                            try
                            {
                                if (!string.IsNullOrWhiteSpace(leUser.EmailUtilisateur))
                                {
                                    Task.Run(() => GMailer.SendAccountConnectionEmail(leUser.EmailUtilisateur, leUser.NomCompletUtilisateur));
                                }
                            }
                            catch (Exception emailEx)
                            {
                                Utils.WriteFileError($"Erreur d'envoi d'email de connexion: {emailEx.Message}");
                            }

                            f.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Identifiant ou mot de passe incorrect");
                        }

                    }

                }

                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect");
                }

            }
            catch (Exception ex)
            {
                Utils.WriteLogSystem(ex.ToString(), "Form1-btnSeConnecter_Click");
            }

        }

        private void frmConnexion_Load(object sender, EventArgs e)
        {
            Utils.WriteFileError("teste des erreurs");
            pnlRight.BringToFront();
            pnlLeft.Paint += (s, ev) =>
            {
                using (var brush = new LinearGradientBrush(pnlLeft.ClientRectangle,
                    Color.FromArgb(25, 118, 210), Color.FromArgb(21, 101, 192), LinearGradientMode.ForwardDiagonal))
                    ev.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
            };
        }
    }
}
