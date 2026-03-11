using AppSenAgriculture.Models;
using AppSenAgriculture.Helper;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmCategorie : Form
    {
        public frmCategorie()  // Constructeur de la classe frmCategorie
        {
            InitializeComponent();
            AppliquerTheme();
        }

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
            ThemeManager.StyleButton(btnSelectionner, ButtonType.Primary);

            // Style des TextBox
            ThemeManager.StyleTextBox(txtCode);
            ThemeManager.StyleTextBox(txtLibelle);

            // Style des Labels
            ThemeManager.StyleLabel(label1, LabelType.Header);
            ThemeManager.StyleLabel(label2, LabelType.Header);

            // Style du DataGridView
            ThemeManager.StyleDataGridView(dgCategorie);
        }

        private void Effacer()  // Méthode pour effacer les champs de saisie et rafraîchir le DataGridView
        {
            txtCode.Clear();
            txtLibelle.Clear();

            using (BdSenAgricultureContext db = new BdSenAgricultureContext()) // Utilisation d'un contexte de base de données pour accéder aux catégories
            {
                dgCategorie.AutoGenerateColumns = true;
                dgCategorie.DataSource = db.categories.ToList(); // Récupération de la liste des catégories et affectation au DataGridView
            }

            txtLibelle.Focus();
        }

        private void frmCategorie_Load(object sender, EventArgs e)  // Événement de chargement du formulaire, appelant la méthode Effacer pour initialiser les données
        {
            Effacer();
        }

        private void btnAjouter_Click(object sender, EventArgs e) // Événement de clic sur le bouton Ajouter, permettant d'ajouter une nouvelle catégorie à la base de données
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Libellé obligatoire");
                    return;
                }

                using (BdSenAgricultureContext db = new BdSenAgricultureContext()) // Utilisation d'un contexte de base de données pour ajouter une nouvelle catégorie
                {
                    Categorie c = new Categorie() // Création d'une nouvelle instance de la classe Categorie avec les données saisies dans les champs txtCode et txtLibelle
                    {
                        LibelleCategorie = txtCode.Text,
                        DescriptionCategorie = txtLibelle.Text
                    };

                    db.categories.Add(c);  // Ajout de la nouvelle catégorie à la collection de catégories du contexte de base de données
                    db.SaveChanges(); // Enregistrement des modifications dans la base de données
                }

                Effacer();
                MessageBox.Show("Ajout réussi");  // Affichage d'un message de succès après l'ajout de la catégorie
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)  // Événement de clic sur le bouton Sélectionner, permettant de remplir les champs de saisie avec les données de la ligne sélectionnée dans le DataGridView
        {
            if (dgCategorie.CurrentRow == null) return;  // Vérification si une ligne est sélectionnée dans le DataGridView

            txtCode.Text = dgCategorie.CurrentRow.Cells["LibelleCategorie"].Value?.ToString();  // Remplissage du champ txtCode avec la valeur de la cellule "LibelleCategorie" de la ligne sélectionnée
            txtLibelle.Text = dgCategorie.CurrentRow.Cells["DescriptionCategorie"].Value?.ToString();  // Remplissage du champ txtLibelle avec la valeur de la cellule "DescriptionCategorie" de la ligne sélectionnée
        }

        private void btnModifier_Click(object sender, EventArgs e)  // Événement de clic sur le bouton Modifier, permettant de modifier les données d'une catégorie existante dans la base de données
        {
            try   
            {
                if (dgCategorie.CurrentRow == null)  // Vérification si une ligne est sélectionnée dans le DataGridView
                {
                    MessageBox.Show("Sélectionnez une ligne");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLibelle.Text))  // Vérification si le champ txtLibelle est vide ou contient uniquement des espaces blancs
                {
                    MessageBox.Show("Libellé obligatoire");
                    return;
                }

                int id = Convert.ToInt32(dgCategorie.CurrentRow.Cells["IdCategorie"].Value);  // Récupération de l'ID de la catégorie à modifier à partir de la ligne sélectionnée dans le DataGridView

                using (BdSenAgricultureContext db = new BdSenAgricultureContext())  // Utilisation d'un contexte de base de données pour trouver la catégorie à modifier et mettre à jour ses données
                {
                    Categorie c = db.categories.Find(id);  // Recherche de la catégorie dans la base de données en utilisant l'ID récupéré

                    if (c != null)
                    {
                        c.LibelleCategorie = txtCode.Text; // Mise à jour du champ LibelleCategorie de la catégorie avec la valeur du champ txtCode
                        c.DescriptionCategorie = txtLibelle.Text; // Mise à jour du champ DescriptionCategorie de la catégorie avec la valeur du champ txtLibelle

                        db.SaveChanges();  // Enregistrement des modifications dans la base de données
                    }
                }

                Effacer();
                MessageBox.Show("Modification réussie");  //
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)  // Événement de clic sur le bouton Supprimer, permettant de supprimer une catégorie existante de la base de données
        {
            try
            {
                if (dgCategorie.CurrentRow == null)  // Vérification si une ligne est sélectionnée dans le DataGridView
                {
                    MessageBox.Show("Sélectionnez une ligne");  // Affichage d'un message d'erreur si aucune ligne n'est sélectionnée
                    return;
                }

                DialogResult rep = MessageBox.Show(  // Affichage d'une boîte de dialogue de confirmation avant de supprimer la catégorie
                    "Voulez-vous supprimer cette catégorie ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (rep == DialogResult.No) return; // Si l'utilisateur choisit "Non" dans la boîte de dialogue, la suppression est annulée et la méthode se termine

                int id = Convert.ToInt32(dgCategorie.CurrentRow.Cells["IdCategorie"].Value); // Récupération de l'ID de la catégorie à supprimer à partir de la ligne sélectionnée dans le DataGridView

                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    Categorie c = db.categories.Find(id);

                    if (c != null)
                    {
                        db.categories.Remove(c); // Suppression de la catégorie de la collection de catégories du contexte de base de données
                        db.SaveChanges();
                    }
                }

                Effacer();
                MessageBox.Show("Suppression réussie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgCategorie_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // Événement de double-clic sur une cellule du DataGridView, permettant de remplir les champs de saisie avec les données de la ligne double-cliquée
        {
            if (dgCategorie.CurrentRow == null) return;  // Vérification si une ligne est sélectionnée dans le DataGridView

            txtCode.Text = dgCategorie.CurrentRow.Cells["LibelleCategorie"].Value?.ToString(); // Remplissage du champ txtCode avec la valeur de la cellule "LibelleCategorie" de la ligne double-cliquée
            txtLibelle.Text = dgCategorie.CurrentRow.Cells["DescriptionCategorie"].Value?.ToString(); // Remplissage du champ txtLibelle avec la valeur de la cellule "DescriptionCategorie" de la ligne double-cliquée
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
