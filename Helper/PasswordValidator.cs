using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppSenAgriculture.Helper
{
    public class PasswordValidator
    {
        /// <summary>
        /// Valide qu'un mot de passe contient au moins:
        /// - 8 caractères
        /// - 1 lettre majuscule
        /// - 1 caractère spécial
        /// </summary>
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            string specialCharacters = @"!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?";
            if (!password.Any(c => specialCharacters.Contains(c)))
                return false;

            return true;
        }

        /// <summary>
        /// Retourne un message d'erreur détaillé pour un mot de passe invalide
        /// </summary>
        public static string GetPasswordValidationMessage(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Le mot de passe ne peut pas être vide.";

            List<string> errors = new List<string>();

            if (password.Length < 8)
                errors.Add("au moins 8 caractères");

            if (!password.Any(char.IsUpper))
                errors.Add("au moins une lettre majuscule");

            string specialCharacters = @"!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?";
            if (!password.Any(c => specialCharacters.Contains(c)))
                errors.Add("au moins un caractère spécial (!@#$%^&*()...)");

            if (errors.Count == 0)
                return string.Empty;

            return "Le mot de passe doit contenir " + string.Join(", ", errors) + ".";
        }

        /// <summary>
        /// Génère un mot de passe aléatoire sécurisé
        /// </summary>
        public static string GenerateSecurePassword(int length = 12)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()_+-=[]{}";

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            password.Append(uppercase[random.Next(uppercase.Length)]);
            password.Append(special[random.Next(special.Length)]);
            password.Append(digits[random.Next(digits.Length)]);

            string allChars = lowercase + uppercase + digits + special;
            for (int i = 3; i < length; i++)
            {
                password.Append(allChars[random.Next(allChars.Length)]);
            }

            return new string(password.ToString().OrderBy(c => random.Next()).ToArray());
        }
    }
}
