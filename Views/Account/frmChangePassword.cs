using AppSenAgriculture.Helper;
using AppSenAgriculture.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Account
{
    public partial class frmChangePassword : Form
    {
        private string _identifiantUtilisateur;
        private string _emailUtilisateur;
        private string _nomCompletUtilisateur;

        public frmChangePassword(string identifiantUtilisateur, string emailUtilisateur, string nomCompletUtilisateur)
        {
            InitializeComponent();
            _identifiantUtilisateur = identifiantUtilisateur;
            _emailUtilisateur = emailUtilisateur;
            _nomCompletUtilisateur = nomCompletUtilisateur;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs
                if (string.IsNullOrWhiteSpace(txtAncienMotDePasse.Text))
                {
                    MessageBox.Show("Veuillez saisir votre ancien mot de passe", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAncienMotDePasse.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNouveauMotDePasse.Text))
                {
                    MessageBox.Show("Veuillez saisir un nouveau mot de passe", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNouveauMotDePasse.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtConfirmation.Text))
                {
                    MessageBox.Show("Veuillez confirmer votre nouveau mot de passe", "Validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmation.Focus();
                    return;
                }

                // Vérifier que les nouveaux mots de passe correspondent
                if (txtNouveauMotDePasse.Text != txtConfirmation.Text)
                {
                    MessageBox.Show("Les mots de passe ne correspondent pas", "Erreur", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtConfirmation.Focus();
                    return;
                }

                // Valider la force du nouveau mot de passe
                if (!PasswordValidator.IsValidPassword(txtNouveauMotDePasse.Text))
                {
                    string message = PasswordValidator.GetPasswordValidationMessage(txtNouveauMotDePasse.Text);
                    MessageBox.Show(message, "Mot de passe non conforme", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNouveauMotDePasse.Focus();
                    return;
                }

                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    var utilisateur = db.utilisateurs.FirstOrDefault(u => u.IdentifiantUtilisateur == _identifiantUtilisateur);

                    if (utilisateur == null)
                    {
                        MessageBox.Show("Utilisateur non trouvé", "Erreur", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Vérifier l'ancien mot de passe
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if (!Crypto.VerifyMd5Hash(md5Hash, txtAncienMotDePasse.Text, utilisateur.MotDePasseUtilisateur))
                        {
                            MessageBox.Show("L'ancien mot de passe est incorrect", "Erreur", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAncienMotDePasse.Focus();
                            return;
                        }
                    }

                    // Vérifier que le nouveau mot de passe est différent de l'ancien
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if (Crypto.VerifyMd5Hash(md5Hash, txtNouveauMotDePasse.Text, utilisateur.MotDePasseUtilisateur))
                        {
                            MessageBox.Show("Le nouveau mot de passe doit être différent de l'ancien", "Erreur", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNouveauMotDePasse.Focus();
                            return;
                        }
                    }

                    // Changer le mot de passe
                    using (MD5 md5Hash = MD5.Create())
                    {
                        utilisateur.MotDePasseUtilisateur = Crypto.GetMd5Hash(md5Hash, txtNouveauMotDePasse.Text);
                        db.Entry(utilisateur).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    // Envoyer un email de confirmation
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(_emailUtilisateur))
                        {
                            Task.Run(() => GMailer.SendPasswordChangedEmail(_emailUtilisateur, _nomCompletUtilisateur));
                        }
                    }
                    catch (Exception emailEx)
                    {
                        Utils.WriteFileError($"Erreur d'envoi d'email de changement de mot de passe: {emailEx.Message}");
                    }

                    MessageBox.Show(
                        "Votre mot de passe a été changé avec succès !\n\n" +
                        "Un email de confirmation a été envoyé à votre adresse.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du changement de mot de passe : {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Utils.WriteLogSystem(ex.ToString(), "frmChangePassword-btnValider_Click");
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAfficherMotDePasse_Click(object sender, EventArgs e)
        {
            if (txtNouveauMotDePasse.UseSystemPasswordChar)
            {
                txtNouveauMotDePasse.UseSystemPasswordChar = false;
                txtConfirmation.UseSystemPasswordChar = false;
                btnAfficherMotDePasse.Text = "🔒 Masquer";
            }
            else
            {
                txtNouveauMotDePasse.UseSystemPasswordChar = true;
                txtConfirmation.UseSystemPasswordChar = true;
                btnAfficherMotDePasse.Text = "👁 Afficher";
            }
        }

        private void txtNouveauMotDePasse_TextChanged(object sender, EventArgs e)
        {
            // Afficher la force du mot de passe en temps réel
            string password = txtNouveauMotDePasse.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                lblForceMotDePasse.Text = "";
                lblForceMotDePasse.ForeColor = System.Drawing.Color.Gray;
                return;
            }

            if (PasswordValidator.IsValidPassword(password))
            {
                lblForceMotDePasse.Text = "✓ Mot de passe sécurisé";
                lblForceMotDePasse.ForeColor = ThemeManager.SuccessColor;
            }
            else
            {
                lblForceMotDePasse.Text = "⚠ Mot de passe faible";
                lblForceMotDePasse.ForeColor = System.Drawing.Color.OrangeRed;
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            // Appliquer le thème moderne
            this.BackColor = ThemeManager.BackgroundColor;
            
            // Informations utilisateur
            lblUtilisateurInfo.Text = $"Utilisateur : {_nomCompletUtilisateur}";
        }
    }
}
