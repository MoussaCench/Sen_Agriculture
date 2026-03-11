using AppSenAgriculture.Helper;
using AppSenAgriculture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    public static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateAdmin();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConnexion());
        }


        /// <summary>
        /// Creation du super admin
        /// </summary>
        private static void CreateAdmin()
        {
            try
            {
                using (BdSenAgricultureContext db = new BdSenAgricultureContext())
                {
                    if (!db.admins.Any())
                    {
                        Admin a = new Admin();
                        a.IdentifiantUtilisateur = "Admin";
                        a.AdresseUtilisateur = "Admin";
                        a.EmailUtilisateur = "moussagame2020@gmail.com";
                        a.TelUtilisateur = "788616224";

                        // Mot de passe par défaut sécurisé: Admin@2024!
                        using (MD5 md5Hash = MD5.Create())
                        {
                            a.MotDePasseUtilisateur = Crypto.GetMd5Hash(md5Hash, "Admin@2024!");
                        }
                        a.NomCompletUtilisateur = "Admin";
                        db.admins.Add(a);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                // Ignorer les erreurs de base de données au démarrage
            }
        }
    }
}
