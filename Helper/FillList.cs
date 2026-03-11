using AppSenAgriculture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace AppSenAgriculture.Helper
{
    public class FillList // Classe utilitaire pour remplir des listes déroulantes avec des données provenant de la base de données

    {
        BdSenAgricultureContext db=new BdSenAgricultureContext();// Création d'une instance du contexte de base de données pour accéder aux données

        /// <summary>
        /// chargement sur une liste desunites de mesure
        /// </summary>
        /// <returns></returns>

        public List<ListItem> fillUniteMesure() // Méthode pour remplir une liste déroulante avec les unités de mesure disponibles dans la base de données
        {
            List<ListItem> laListe = new List<ListItem>(); // Création d'une liste de ListItem pour stocker les éléments de la liste déroulante

            var liste = db.unitemesures.ToList();// Récupération de toutes les unités de mesure depuis la base de données et conversion en liste

            laListe.Add(new ListItem  // Ajout d'un élément par défaut à la liste déroulante pour inviter l'utilisateur à faire une sélection
            {
                Value = null,  // Valeur nulle pour l'option par défaut
                Text = "Sélectionner......." // Texte affiché pour l'option par défaut
            }); 

            foreach (var t in liste)  // Parcours de chaque unité de mesure récupérée depuis la base de données
            {
                var item = new ListItem  // Création d'un nouvel élément de la liste déroulante pour chaque unité de mesure
                {
                    Value = t.IdUnite.ToString(),   // La valeur de l'élément est définie sur l'identifiant de l'unité de mesure converti en chaîne de caractères
                    Text = t.LibelleUnite.ToString()   // Le texte affiché pour l'élément est défini sur le libellé de l'unité de mesure converti en chaîne de caractères
                };

                laListe.Add(item);  // Ajout de l'élément à la liste déroulante
            }

            return laListe;  // Retourne la liste remplie d'éléments pour la liste déroulante
        }


        /// <summary>
        /// chargement sur une liste des categories de produit
        /// </summary>
        /// <returns></returns>

        public List<ListItem> fillCategorie()
        {
            List<ListItem> laListe = new List<ListItem>(); // Création d'une liste de ListItem pour stocker les éléments de la liste déroulante des catégories de produits

            var liste = db.categories.ToList(); // Récupération de toutes les catégories de produits depuis la base de données et conversion en liste

            laListe.Add(new ListItem // Ajout d'un élément par défaut à la liste déroulante pour inviter l'utilisateur à faire une sélection
            {
                Value = null, // Valeur nulle pour l'option par défaut
                Text = "Sélectionner......." // Texte affiché pour l'option par défaut
            });

            foreach (var t in liste) // Parcours de chaque catégorie de produit récupérée depuis la base de données
            {
                var item = new ListItem // Création d'un nouvel élément de la liste déroulante pour chaque catégorie de produit
                {
                    Value = t.IdCategorie.ToString(), // La valeur de l'élément est définie sur l'identifiant de la catégorie de produit converti en chaîne de caractères
                    Text = t.DescriptionCategorie.ToString() // Le texte affiché pour l'élément est défini sur la description de la catégorie de produit converti en chaîne de caractères
                };

                laListe.Add(item); // Ajout de l'élément à la liste déroulante
            }

            return laListe;
        }





    }



}
