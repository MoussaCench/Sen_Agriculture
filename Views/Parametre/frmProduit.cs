using AppSenAgriculture.Helper;
using AppSenAgriculture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture.Views.Parametre
{
    public partial class frmProduit : Form  // Formulaire de gestion des produits
    {
        public frmProduit() // Constructeur de la classe frmProduit
        {
            InitializeComponent();  // Initialisation des composants du formulaire
            AppliquerTheme();
        }

        FillList fillList = new FillList(); // Instance de la classe FillList pour remplir les listes déroulantes

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
            ThemeManager.StyleButton(btnRechercher, ButtonType.Success);

            // Style des TextBox
            ThemeManager.StyleTextBox(txtLibelle);
            ThemeManager.StyleTextBox(txtDescription);
            ThemeManager.StyleTextBox(txtPrixUMin);
            ThemeManager.StyleTextBox(txtPrixUMax);
            ThemeManager.StyleTextBox(txtRLibelle);
            ThemeManager.StyleTextBox(txtRDescription);
            ThemeManager.StyleTextBox(txtRPrixUMin);

            // Style des ComboBox
            ThemeManager.StyleComboBox(cbbUniteMesure);
            ThemeManager.StyleComboBox(cbbCategorie);

            // Style des Labels
            ThemeManager.StyleLabel(label1, LabelType.Header);
            ThemeManager.StyleLabel(label2, LabelType.Header);
            ThemeManager.StyleLabel(label3, LabelType.Header);
            ThemeManager.StyleLabel(label4, LabelType.Header);
            ThemeManager.StyleLabel(label5, LabelType.Header);
            ThemeManager.StyleLabel(label6, LabelType.Header);
            ThemeManager.StyleLabel(label7, LabelType.Header);
            ThemeManager.StyleLabel(label8, LabelType.Header);
            ThemeManager.StyleLabel(label9, LabelType.Header);

            // Style du DataGridView
            ThemeManager.StyleDataGridView(dgProduit);

            // Style du GroupBox
            grpRecherche.BackColor = ThemeManager.PanelColor;
            grpRecherche.ForeColor = ThemeManager.TextColor;
            grpRecherche.Font = new Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        }

        private void ResetForm() // Méthode pour réinitialiser le formulaire et rafraîchir les données
        {
            cbbUniteMesure.DataSource = fillList.fillUniteMesure(); // Remplissage de la liste déroulante des unités de mesure
            cbbUniteMesure.DisplayMember = "Text";  // Affichage du texte dans la liste déroulante
            cbbUniteMesure.ValueMember = "Value"; // Valeur associée à chaque élément de la liste déroulante

            cbbCategorie.DataSource = fillList.fillCategorie(); // Remplissage de la liste déroulante des catégories
            cbbCategorie.DisplayMember = "Text"; // Affichage du texte dans la liste déroulante
            cbbCategorie.ValueMember = "Value"; // Valeur associée à chaque élément de la liste déroulante

            using (BdSenAgricultureContext db = new BdSenAgricultureContext()) // Utilisation du contexte de base de données pour accéder aux produits
            {
                dgProduit.DataSource = db.produits.Select(u => new // Sélection des produits avec leurs propriétés et les descriptions associées
                {
                    u.IdProduit, // Identifiant du produit
                    u.LibelleProduit, // Libellé du produit
                    u.DescriptionProduit, // Description du produit
                    u.PrixUnitaireMin, // Prix unitaire minimum du produit
                    u.PrixUnitaireMax, // Prix unitaire maximum du produit
                    Categorie = u.Categorie.DescriptionCategorie, // Description de la catégorie associée au produit
                    UniteMesure = u.UniteMesure.LibelleUnite // Libellé de l'unité de mesure associée au produit
                }).ToList();
            }

            txtDescription.Text = string.Empty; // Réinitialisation du champ de description
            txtPrixUMax.Text = string.Empty; // Réinitialisation du champ de prix unitaire maximum
            txtPrixUMin.Text = string.Empty; // Réinitialisation du champ de prix unitaire minimum
            txtLibelle.Text = string.Empty;// Réinitialisation du champ de libellé

            txtLibelle.Focus(); // Mise au point sur le champ de libellé pour faciliter la saisie d'un nouveau produit
        }

        private void frmProduit_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLibelle.Text))
                {
                    MessageBox.Show("Libellé obligatoire");// Affichage d'un message d'erreur indiquant que le libellé du produit est obligatoire si le champ de libellé est vide ou contient uniquement des espaces blancs, et terminaison de la méthode pour empêcher l'ajout d'un produit sans libellé
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrixUMin.Text) || string.IsNullOrWhiteSpace(txtPrixUMax.Text))
                {
                    MessageBox.Show("Les prix minimum et maximum sont obligatoires"); // Affichage d'un message d'erreur indiquant que les prix minimum et maximum sont obligatoires si l'un des champs de prix est vide ou contient uniquement des espaces blancs, et terminaison de la méthode pour empêcher l'ajout d'un produit sans prix
                    return;
                }

                if (cbbUniteMesure.SelectedValue == null || cbbCategorie.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner une catégorie et une unité de mesure");
                    return;
                }

                using (BdSenAgricultureContext db = new BdSenAgricultureContext()) // Utilisation du contexte de base de données pour ajouter un nouveau produit
                {
                    Produit p = new Produit(); // Création d'une nouvelle instance de la classe Produit pour stocker les informations du produit à ajouter
                    p.IdUniteMesure = int.Parse(cbbUniteMesure.SelectedValue.ToString()); // Affectation de l'identifiant de l'unité de mesure sélectionnée à la propriété IdUniteMesure du produit
                    p.CategorieId = int.Parse(cbbCategorie.SelectedValue.ToString()); // Affectation de l'identifiant de la catégorie sélectionnée à la propriété CategorieId du produit
                    p.LibelleProduit = txtLibelle.Text; // Affectation du texte saisi dans le champ de libellé à la propriété LibelleProduit du produit
                    p.DescriptionProduit = txtDescription.Text; // Affectation du texte saisi dans le champ de description à la propriété DescriptionProduit du produit
                    p.PrixUnitaireMin = double.Parse(txtPrixUMin.Text); // Affectation du texte saisi dans le champ de prix unitaire minimum, converti en double, à la propriété PrixUnitaireMin du produit
                    p.PrixUnitaireMax = double.Parse(txtPrixUMax.Text); // Affectation du texte saisi dans le champ de prix unitaire maximum, converti en double, à la propriété PrixUnitaireMax du produit

                    db.produits.Add(p); // Ajout du produit à la collection de produits du contexte de base de données
                    db.SaveChanges(); // Enregistrement des modifications dans la base de données pour persister le nouveau produit ajouté
                }

                ResetForm(); // pour réinitialiser le formulaire et rafraîchir les données après l'ajout d'un nouveau produit, ce qui met à jour le DataGridView pour afficher le nouveau produit ajouté et réinitialise les champs de saisie pour permettre l'ajout d'un autre produit si nécessaire

            }
            catch (FormatException)
            {
                MessageBox.Show("Erreur de format. Vérifiez que les prix sont des nombres valides."); // Affichage d'un message d'erreur indiquant que les prix saisis dans les champs de prix unitaire minimum et maximum ne sont pas des nombres valides si la conversion en double échoue, et terminaison de la méthode pour éviter d'ajouter un produit avec des prix invalides
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProduit.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez une ligne");
                    return;
                }

                int id = int.Parse(dgProduit.CurrentRow.Cells["IdProduit"].Value.ToString());

                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    var p = db.produits.Find(id);

                    if (p != null)
                    {
                        txtLibelle.Text = p.LibelleProduit;
                        txtDescription.Text = p.DescriptionProduit ?? string.Empty;
                        txtPrixUMin.Text = p.PrixUnitaireMin.ToString();
                        txtPrixUMax.Text = p.PrixUnitaireMax.ToString();

                        cbbUniteMesure.DataSource = null;
                        cbbUniteMesure.DataSource = fillList.fillUniteMesure();
                        cbbUniteMesure.DisplayMember = "Text";
                        cbbUniteMesure.ValueMember = "Value";
                        cbbUniteMesure.SelectedValue = p.IdUniteMesure.ToString();

                        cbbCategorie.DataSource = null;
                        cbbCategorie.DataSource = fillList.fillCategorie();
                        cbbCategorie.DisplayMember = "Text";
                        cbbCategorie.ValueMember = "Value";
                        cbbCategorie.SelectedValue = p.CategorieId.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Produit introuvable");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e) // Méthode pour supprimer un produit sélectionné dans le DataGridView confirmation de la suppression avant de procéder à la suppression du produit de la base de données et rafraîchissement du formulaire après la suppression
        {
            try // Bloc de gestion des exceptions pour capturer et afficher les erreurs potentielles lors de la suppression d'un produit, comme les erreurs de conversion ou les problèmes de connexion à la base de données
            {
                if (dgProduit.CurrentRow == null) // Vérification que l'utilisateur a sélectionné une ligne dans le DataGridView avant de tenter de supprimer un produit pour éviter les erreurs de référence null
                {
                    MessageBox.Show("Sélectionnez une ligne"); // Affichage d'un message d'erreur demandant à l'utilisateur de sélectionner une ligne si aucune ligne n'est actuellement sélectionnée dans le DataGridView
                    return;
                }

                DialogResult rep = MessageBox.Show( // Affichage d'une boîte de dialogue de confirmation demandant à l'utilisateur s'il souhaite supprimer le produit sélectionné, avec les options Oui et Non, et une icône de question pour indiquer qu'il s'agit d'une action de confirmation avant de procéder à la suppression du produit de la base de données
                    "Voulez-vous supprimer ce produit ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (rep == DialogResult.No) return; // Si l'utilisateur choisit de ne pas supprimer le produit, la méthode se termine et aucune action de suppression n'est effectuée

                int id = int.Parse(dgProduit.CurrentRow.Cells["IdProduit"].Value.ToString()); // Récupération de l'identifiant du produit à partir de la cellule "IdProduit" de la ligne actuellement sélectionnée dans le DataGridView, converti en entier pour être utilisé dans la requête de suppression du produit dans la base de données

                using (BdSenAgricultureContext db = new BdSenAgricultureContext()) // Utilisation du contexte de base de données pour supprimer le produit sélectionné de la base de données
                {
                    var p = db.produits.Find(id); // Recherche du produit dans la base de données en utilisant l'identifiant récupéré à partir de la ligne sélectionnée dans le DataGridView, la méthode Find est utilisée pour trouver le produit correspondant à cet identifiant afin de pouvoir le supprimer de la base de données
                    if (p != null) // Vérification que le produit a été trouvé dans la base de données avant de tenter de le supprimer pour éviter les erreurs de référence null
                    {
                        db.produits.Remove(p); // Suppression du produit trouvé de la collection de produits du contexte de base de données, ce qui marque le produit pour suppression lors de l'appel à SaveChanges
                        db.SaveChanges(); // Enregistrement des modifications dans la base de données pour persister la suppression du produit sélectionné
                    }
                }

                ResetForm();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message); // Affichage d'un message d'erreur contenant les détails de l'exception capturée pour informer l'utilisateur de la nature du problème rencontré lors de la suppression d'un produit, comme les erreurs de conversion ou les problèmes de connexion à la base de données
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgProduit.CurrentRow == null)  // Vérification que l'utilisateur a sélectionné une ligne dans le DataGridView avant de tenter de modifier un produit pour éviter les erreurs de référence null
                {
                    MessageBox.Show("Sélectionnez une ligne");  // Affichage d'un message d'erreur demandant à l'utilisateur de sélectionner une ligne si aucune ligne n'est actuellement sélectionnée dans le DataGridView
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLibelle.Text)) // Vérification que le champ de libellé n'est pas vide ou ne contient pas uniquement des espaces blancs avant de tenter de modifier un produit pour garantir que le libellé du produit est valide et éviter les erreurs de validation lors de la mise à jour du produit dans la base de données
                {
                    MessageBox.Show("Libellé obligatoire"); // Affichage d'un message d'erreur indiquant que le libellé du produit est obligatoire si le champ de libellé est vide ou contient uniquement des espaces blancs, et terminaison de la méthode pour empêcher la modification d'un produit sans libellé
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrixUMin.Text) || string.IsNullOrWhiteSpace(txtPrixUMax.Text)) // Vérification que les champs de prix unitaire minimum et maximum ne sont pas vides ou ne contiennent pas uniquement des espaces blancs avant de tenter de modifier un produit pour garantir que les prix du produit sont valides et éviter les erreurs de validation lors de la mise à jour du produit dans la base de données
                {
                    MessageBox.Show("Les prix minimum et maximum sont obligatoires"); // Affichage d'un message d'erreur indiquant que les prix minimum et maximum sont obligatoires si l'un des champs de prix est vide ou contient uniquement des espaces blancs, et terminaison de la méthode pour empêcher la modification d'un produit sans prix
                    return;
                }

                if (cbbUniteMesure.SelectedValue == null) // Vérification que l'utilisateur a sélectionné une unité de mesure dans la liste déroulante avant de tenter de modifier un produit pour garantir que l'unité de mesure du produit est valide et éviter les erreurs de validation lors de la mise à jour du produit dans la base de données
                {
                    MessageBox.Show("Veuillez sélectionner une unité de mesure"); // Affichage d'un message d'erreur demandant à l'utilisateur de sélectionner une unité de mesure si aucune unité de mesure n'est actuellement sélectionnée dans la liste déroulante, et terminaison de la méthode pour empêcher la modification d'un produit sans unité de mesure
                    return;
                }

                if (cbbCategorie.SelectedValue == null) // Vérification que l'utilisateur a sélectionné une catégorie dans la liste déroulante avant de tenter de modifier un produit pour garantir que la catégorie du produit est valide et éviter les erreurs de validation lors de la mise à jour du produit dans la base de données
                {
                    MessageBox.Show("Veuillez sélectionner une catégorie"); // Affichage d'un message d'erreur demandant à l'utilisateur de sélectionner une catégorie si aucune catégorie n'est actuellement sélectionnée dans la liste déroulante, et terminaison de la méthode pour empêcher la modification d'un produit sans catégorie
                    return;
                }

                int id = int.Parse(dgProduit.CurrentRow.Cells["IdProduit"].Value.ToString()); // Récupération de l'identifiant du produit à partir de la cellule "IdProduit" de la ligne actuellement sélectionnée dans le DataGridView, converti en entier pour être utilisé dans la requête de recherche du produit dans la base de données afin de pouvoir modifier les propriétés du produit correspondant à cet identifiant

                using (BdSenAgricultureContext db = new BdSenAgricultureContext()) // Utilisation du contexte de base de données pour rechercher le produit sélectionné dans le DataGridView et modifier ses propriétés avec les nouvelles valeurs saisies par l'utilisateur avant d'enregistrer les modifications dans la base de données pour persister la mise à jour du produit
                {
                    var p = db.produits.Find(id); // Recherche du produit dans la base de données en utilisant l'identifiant récupéré à partir de la ligne sélectionnée dans le DataGridView, la méthode Find est utilisée pour trouver le produit correspondant à cet identifiant afin de pouvoir modifier ses propriétés avec les nouvelles valeurs saisies par l'utilisateur avant d'enregistrer les modifications dans la base de données pour persister la mise à jour du produit

                    if (p != null)  // Vérification que le produit a été trouvé dans la base de données avant de tenter de modifier ses propriétés pour éviter les erreurs de référence null
                    {
                        p.IdUniteMesure = int.Parse(cbbUniteMesure.SelectedValue.ToString()); // Affectation de l'identifiant de l'unité de mesure sélectionnée à la propriété IdUniteMesure du produit pour mettre à jour l'unité de mesure du produit avec la nouvelle valeur sélectionnée par l'utilisateur dans la liste déroulante
                        p.CategorieId = int.Parse(cbbCategorie.SelectedValue.ToString());
                        p.LibelleProduit = txtLibelle.Text; // Affectation du texte saisi dans le champ de libellé à la propriété LibelleProduit du produit pour mettre à jour le libellé du produit avec la nouvelle valeur saisie par l'utilisateur dans le champ de texte
                        p.DescriptionProduit = txtDescription.Text;
                        p.PrixUnitaireMin = double.Parse(txtPrixUMin.Text); // Affectation du texte saisi dans le champ de prix unitaire minimum, converti en double, à la propriété PrixUnitaireMin du produit pour mettre à jour le prix unitaire minimum du produit avec la nouvelle valeur saisie par l'utilisateur dans le champ de texte
                        p.PrixUnitaireMax = double.Parse(txtPrixUMax.Text); // Affectation du texte saisi dans le champ de prix unitaire maximum, converti en double, à la propriété PrixUnitaireMax du produit pour mettre à jour le prix unitaire maximum du produit avec la nouvelle valeur saisie par l'utilisateur dans le champ de texte

                        db.SaveChanges();  // Enregistrement des modifications dans la base de données pour persister la mise à jour du produit avec les nouvelles valeurs saisies par l'utilisateur, ce qui met à jour les propriétés du produit dans la base de données avec les nouvelles valeurs avant de rafraîchir le formulaire pour afficher les données mises à jour

                        ResetForm();
                        MessageBox.Show("Modification réussie");
                    }
                    else
                    {
                        MessageBox.Show("Produit introuvable");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Erreur de format. Vérifiez que les prix sont des nombres valides.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e) // Méthode pour rechercher des produits dans le DataGridView en fonction des critères de recherche saisis par l'utilisateur dans les champs de texte et les listes déroulantes, avec gestion des exceptions pour capturer et afficher les erreurs potentielles lors de la recherche, comme les erreurs de format ou les problèmes de connexion à la base de données
        {
            try
            {
                using (BdSenAgricultureContext db = new BdSenAgricultureContext())  // Utilisation du contexte de base de données pour accéder aux produits et appliquer les filtres de recherche en fonction des critères saisis par l'utilisateur dans les champs de texte et les listes déroulantes, puis affichage des résultats de la recherche dans le DataGridView
                {
                    var liste = db.produits.Select(u => new
                    {
                        u.IdProduit,
                        u.LibelleProduit,
                        u.DescriptionProduit,
                        u.PrixUnitaireMin,
                        u.PrixUnitaireMax,
                        Categorie = u.Categorie.DescriptionCategorie,
                        UniteMesure = u.UniteMesure.LibelleUnite
                    }).ToList();

                    if (!string.IsNullOrEmpty(txtRLibelle.Text))  // Vérification que le champ de recherche de libellé n'est pas vide avant d'appliquer le filtre de recherche sur le libellé des produits pour éviter les erreurs de format et garantir que le critère de recherche est valide avant d'appliquer le filtre sur la liste des produits
                    {
                        liste = liste.Where(a => a.LibelleProduit.ToUpper().Contains(txtRLibelle.Text.ToUpper())).ToList(); // Application du filtre de recherche sur le libellé des produits en utilisant la méthode Where pour sélectionner uniquement les produits dont le libellé contient le texte saisi dans le champ de recherche de libellé, en ignorant la casse en convertissant les deux chaînes en majuscules avant de comparer, et conversion du résultat en liste pour être affiché dans le DataGridView
                    }

                    if (!string.IsNullOrEmpty(txtRDescription.Text)) // Vérification que le champ de recherche de description n'est pas vide avant d'appliquer le filtre de recherche sur la description des produits pour éviter les erreurs de format et garantir que le critère de recherche est valide avant d'appliquer le filtre sur la liste des produits
                    {
                        liste = liste.Where(a => a.DescriptionProduit != null && a.DescriptionProduit.ToUpper().Contains(txtRDescription.Text.ToUpper())).ToList();
                    }

                    if (!string.IsNullOrEmpty(txtRPrixUMin.Text)) // Vérification que le champ de recherche de prix unitaire minimum n'est pas vide avant d'appliquer le filtre de recherche sur le prix unitaire minimum des produits pour éviter les erreurs de format et garantir que le critère de recherche est valide avant d'appliquer le filtre sur la liste des produits
                    {
                        double price;
                        if (double.TryParse(txtRPrixUMin.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price)) // Tentative de conversion du texte saisi dans le champ de recherche de prix unitaire minimum en double en utilisant la méthode TryParse pour éviter les exceptions de format et garantir que le critère de recherche est un nombre valide avant d'appliquer le filtre sur la liste des produits
                        {
                            liste = liste.Where(a => a.PrixUnitaireMin <= price && price <= a.PrixUnitaireMax).ToList(); // Application du filtre de recherche sur le prix unitaire minimum des produits en utilisant la méthode Where pour sélectionner uniquement les produits dont le prix unitaire minimum est inférieur ou égal au prix saisi dans le champ de recherche de prix unitaire minimum, et dont le prix unitaire maximum est supérieur ou égal au même prix saisi, ce qui permet de trouver les produits dont le prix unitaire se situe dans la plage définie par le prix saisi, et conversion du résultat en liste pour être affiché dans le DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Le prix doit être un nombre valide (exemple: 200 ou 200,5)"); // Affichage d'un message d'erreur indiquant que le prix saisi dans le champ de recherche de prix unitaire minimum n'est pas un nombre valide si la conversion en double échoue, et terminaison de la méthode pour éviter d'appliquer un filtre de recherche avec un critère de prix invalide
                            return;
                        }
                    }

                    dgProduit.DataSource = liste;  // Affectation de la liste filtrée des produits au DataGridView pour afficher les résultats de la recherche en fonction des critères saisis par l'utilisateur dans les champs de texte et les listes déroulantes, ce qui met à jour le contenu du DataGridView avec les produits correspondant aux critères de recherche

                    if (liste.Count == 0)
                    {
                        MessageBox.Show("Aucun produit trouvé avec ces critères de recherche");  // Affichage d'un message d'information indiquant qu'aucun produit n'a été trouvé avec les critères de recherche saisis par l'utilisateur si la liste filtrée des produits est vide après l'application des filtres de recherche, ce qui informe l'utilisateur que les critères de recherche ne correspondent à aucun produit dans la base de données
                    }
                }
            }
            catch (FormatException) // Bloc de gestion des exceptions pour capturer les erreurs de format lors de la conversion du texte saisi dans le champ de recherche de prix unitaire minimum en double, et affichage d'un message d'erreur indiquant que le prix doit être un nombre valide si la conversion échoue, ce qui informe l'utilisateur que le critère de recherche de prix unitaire minimum doit être corrigé pour être un nombre valide avant de pouvoir appliquer le filtre de recherche sur les produits
            {
                MessageBox.Show("Erreur de format. Vérifiez que le prix est un nombre valide.");
            }
            catch (Exception ex) // Bloc de gestion des exceptions pour capturer et afficher les erreurs potentielles lors de la recherche de produits, comme les problèmes de connexion à la base de données ou d'autres erreurs inattendues, et affichage d'un message d'erreur contenant les détails de l'exception capturée pour informer l'utilisateur de la nature du problème rencontré lors de la recherche de produits
            {
                MessageBox.Show("Erreur : " + ex.Message); // Affichage d'un message d'erreur contenant les détails de l'exception capturée pour informer l'utilisateur de la nature du problème rencontré lors de la recherche de produits, comme les problèmes de connexion à la base de données ou d'autres erreurs inattendues
            }
        }

        private void dgProduit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelectionner_Click(sender, e);
        }
    }
}
