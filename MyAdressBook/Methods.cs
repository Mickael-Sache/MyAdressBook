using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyAdressBook
{   
    /// <summary>
    ///Classe regroupant les méthodes utilisés par le programme 
    /// </summary>
    static class Methods
    {
        static string UserInput;

        /// <summary>
        /// Permet de délimiter un string en fonction de la props MaxLength associés
        /// Ou ajouter des espaces pour avoir un carnet fixe
        /// </summary>
        /// <returns>string</returns>
        public static string Troncate(ref string str, int MaxLen)
        {
            if (str.Length >= MaxLen)
            {
                str = str.Substring(0, MaxLen);
            }
            else
            {
                str = str.PadRight(MaxLen);
            }
            return str;
        }

        /// <summary>
        /// Méthode qui colore l'affichage du texte dans la console selon la couleur définit
        /// </summary>
        /// <param name="ForegroundColor"></param>
        /// <param name="value"></param>
        public static void MessageColored(string value)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        /// Permet d'afficher le "header" ainsi que le Menu lors de chaque entré dans le Switch
        /// </summary>
        public static void DisplayInfo()
        {
            Methods.MessageColored("\t┌───────────────────────────┐\n" +
                                   "\t│                           │\n" +
                                   "\t│    My first Adress Book   │\n" +
                                   "\t│                           │\n" +
                                   "\t└───────────────────────────┘\n");

            Console.WriteLine("\t\t Menu");
            Console.WriteLine("\t\t┌───────────────────┐\n" +
                              "\t\t├─ A ─ AddContact ──┤\n" +
                              "\t\t├─ S ─ SaveContact ─┤\n" +
                              "\t\t├─ Q ─ Quit ────────┤\n" +
                              "\t\t└───────────────────┘\n");
        }


        /// <summary>
        /// Affiche un message selon le Case utilisé et passage de la booléenne à "False"
        /// </summary>
        /// <param name="message"></param>
        /// <param name="boo"></param>
        public static void MsgCase(string message, bool boo)
        {
            boo = false;
            Console.Clear();
            Console.WriteLine(message);
        }

        /// <summary>
        /// Permet d'intérargir avec le menu via un Switch
        /// </summary>
        /// <param name="Carnet"></param>
        /// <param name="props"></param>
        /// <param name="boo"></param>
        /// <param name="filepath"></param>
        public static void Switch(bool boo, string filepath)
        {
            Methods.DisplayInfo();
            Console.Write("Veuillez saisir une commande : ");
            UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "a": /*AddContact*/
                case "A":

                    break;

                case "s": /*SaveContact*/
                case "S":

                    Methods.MsgCase("Contact enregistré(s) ..", boo);
                    break;

                case "q": /*Quit*/
                case "Q":

                    Methods.MsgCase("\n" +
                                    "\n" +
                                    "Merci, et à bientôt", boo);
                    Environment.Exit(0);
                    break;

                default: /*Erreur*/

                    Console.WriteLine("Une erreur est survenue ..");
                    break;
            }
        }

    }//End of Class
}
