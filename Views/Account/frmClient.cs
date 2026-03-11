using AppSenAgriculture.Helper;
using AppSenAgriculture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Account
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
            AppliquerTheme();
        }

        BdSenAgricultureContext db = new BdSenAgricultureContext();

        /// <summary>
        /// Applique le thème moderne au formulaire
        /// </summary>
        private void AppliquerTheme()
        {
            ThemeManager.ApplyFormTheme(this);

            // Style des boutons
            ThemeManager.StyleButton(btnAjouter, ButtonType.Primary);
            ThemeManager.StyleButton(btnModifier, ButtonType.Secondary);
            ThemeManager.StyleButton(btnSupprimer, ButtonType.Danger);
            ThemeManager.StyleButton(btnBloquer, ButtonType.Warning);
            ThemeManager.StyleButton(btnDebloquer, ButtonType.Success);
            ThemeManager.StyleButton(btnReset, ButtonType.Secondary);
            ThemeManager.StyleButton(btnSelectionner, ButtonType.Primary);
            ThemeManager.StyleButton(btnImprimer, ButtonType.Secondary);

            // Style des TextBox
            ThemeManager.StyleTextBox(txtNomComplet);
            ThemeManager.StyleTextBox(txtAdresse);
            ThemeManager.StyleTextBox(txtEmail);
            ThemeManager.StyleTextBox(txtTelephone);
            ThemeManager.StyleTextBox(txtIdentifiant);
            ThemeManager.StyleTextBox(txtProfession);

            // Style des Labels
            ThemeManager.StyleLabel(label1, LabelType.Header);
            ThemeManager.StyleLabel(label2, LabelType.Header);
            ThemeManager.StyleLabel(label3, LabelType.Header);
            ThemeManager.StyleLabel(label4, LabelType.Header);
            ThemeManager.StyleLabel(label5, LabelType.Header);
            ThemeManager.StyleLabel(label6, LabelType.Header);

            // Style du DataGridView
            ThemeManager.StyleDataGridView(dgClient);
        }

        private void ResetForm()
        {
            txtAdresse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtIdentifiant.Text = string.Empty;
            txtNomComplet.Text = string.Empty;
            txtProfession.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            dgClient.DataSource = db.clients.Select(a=> new
            {
                a.ID,
                a.NomCompletUtilisateur,
                a.IdentifiantUtilisateur,
                a.ProfessionClient,
                a.TelUtilisateur,
                a.EmailUtilisateur
            }).ToList();
            txtNomComplet.Focus();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(txtNomComplet.Text))
            {
                MessageBox.Show("Le nom complet est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomComplet.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("L'email est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                MessageBox.Show("Le téléphone est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelephone.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            {
                MessageBox.Show("L'identifiant est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentifiant.Focus();
                return;
            }

            // Vérifier si l'identifiant existe déjà
            if (db.clients.Any(c => c.IdentifiantUtilisateur == txtIdentifiant.Text))
            {
                MessageBox.Show("Cet identifiant est déjà utilisé.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdentifiant.Focus();
                return;
            }

            // Générer un mot de passe sécurisé
            string motDePasse = PasswordValidator.GenerateSecurePassword(12);

            Client ut = new Client();

            using (MD5 md5Hash = MD5.Create())
            {
                ut.MotDePasseUtilisateur = Crypto.GetMd5Hash(md5Hash, motDePasse);
            }

            ut.AdresseUtilisateur = txtAdresse.Text;
            ut.EmailUtilisateur = txtEmail.Text;
            ut.TelUtilisateur = txtTelephone.Text;
            ut.IdentifiantUtilisateur = txtIdentifiant.Text;
            ut.NomCompletUtilisateur = txtNomComplet.Text;
            ut.ProfessionClient = txtProfession.Text;

            db.clients.Add(ut);
            db.SaveChanges();

            // Envoyer un email avec les informations de connexion
            try
            {
                string emailBody = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif;'>
                        <h2 style='color: #4CAF50;'>Bienvenue sur SenAgriculture !</h2>
                        <p>Bonjour <strong>{txtNomComplet.Text}</strong>,</p>
                        <p>Votre compte a été créé avec succès.</p>
                        <div style='background-color: #f5f5f5; padding: 15px; border-left: 4px solid #4CAF50; margin: 20px 0;'>
                            <p><strong>Vos informations de connexion :</strong></p>
                            <p>Identifiant : <strong>{txtIdentifiant.Text}</strong></p>
                            <p>Mot de passe : <strong>{motDePasse}</strong></p>
                        </div>
                        <p style='color: #d32f2f;'><strong>Important :</strong> Conservez ces informations en lieu sûr. Nous vous recommandons de changer votre mot de passe lors de votre première connexion.</p>
                        <br/>
                        <p style='color: #666;'>Cordialement,<br/>L'équipe SenAgriculture</p>
                    </body>
                    </html>";

                GMailer.senMail(txtEmail.Text, "Compte créé - SenAgriculture", emailBody);

                MessageBox.Show($"Client ajouté avec succès!\n\nUn email a été envoyé à {txtEmail.Text} avec les informations de connexion.\n\nMot de passe généré: {motDePasse}", 
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Client ajouté, mais l'envoi de l'email a échoué.\n\nMot de passe: {motDePasse}\n\nErreur: {ex.Message}", 
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ResetForm();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgClient.CurrentRow != null)
            {
                // Validation des champs obligatoires
                if (string.IsNullOrWhiteSpace(txtNomComplet.Text))
                {
                    MessageBox.Show("Le nom complet est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomComplet.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("L'email est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTelephone.Text))
                {
                    MessageBox.Show("Le téléphone est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelephone.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
                {
                    MessageBox.Show("L'identifiant est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdentifiant.Focus();
                    return;
                }
                int id = Convert.ToInt32(dgClient.CurrentRow.Cells["ID"].Value);
                Client ut = db.clients.Find(id);

                if (ut != null)
                {
                    ut.AdresseUtilisateur = txtAdresse.Text;
                    ut.EmailUtilisateur = txtEmail.Text;
                    ut.TelUtilisateur = txtTelephone.Text;
                    ut.IdentifiantUtilisateur = txtIdentifiant.Text;
                    ut.NomCompletUtilisateur = txtNomComplet.Text;
                    ut.ProfessionClient = txtProfession.Text;

                    db.SaveChanges();
                    ResetForm();
                    MessageBox.Show("Client modifié avec succès!", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgClient.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce client?", 
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgClient.CurrentRow.Cells["ID"].Value);
                    Client ut = db.clients.Find(id);

                    if (ut != null)
                    {
                        db.clients.Remove(ut);
                        db.SaveChanges();
                        ResetForm();
                        MessageBox.Show("Client supprimé avec succès!", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void dgClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgClient.Rows[e.RowIndex];
                txtNomComplet.Text = row.Cells["NomCompletUtilisateur"].Value?.ToString();
                txtIdentifiant.Text = row.Cells["IdentifiantUtilisateur"].Value?.ToString();
                txtProfession.Text = row.Cells["ProfessionClient"].Value?.ToString();
                txtTelephone.Text = row.Cells["TelUtilisateur"].Value?.ToString();
                txtEmail.Text = row.Cells["EmailUtilisateur"].Value?.ToString();

                int id = Convert.ToInt32(row.Cells["ID"].Value);
                Client client = db.clients.Find(id);
                if (client != null)
                {
                    txtAdresse.Text = client.AdresseUtilisateur;
                }
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (dgClient.CurrentRow != null && dgClient.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgClient.CurrentRow;
                txtNomComplet.Text = row.Cells["NomCompletUtilisateur"].Value?.ToString();
                txtIdentifiant.Text = row.Cells["IdentifiantUtilisateur"].Value?.ToString();
                txtProfession.Text = row.Cells["ProfessionClient"].Value?.ToString();
                txtTelephone.Text = row.Cells["TelUtilisateur"].Value?.ToString();
                txtEmail.Text = row.Cells["EmailUtilisateur"].Value?.ToString();

                int id = Convert.ToInt32(row.Cells["ID"].Value);
                Client client = db.clients.Find(id);
                if (client != null)
                {
                    txtAdresse.Text = client.AdresseUtilisateur;
                }

                txtNomComplet.Focus();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client dans la liste.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            frmPrintClient f = new frmPrintClient();
            f.ShowDialog();
        }
    }
}