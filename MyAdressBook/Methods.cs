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
        /// Permet d'ajouter des contacts dans le Carnet
        /// </summary>
        /// <param name="Carnet"></param>
        /// <param name="props"></param>
        public static void AddContacts(List<Properties.Contact> Carnet, Properties.ContactProperties props)
        {
            Console.Write("Contact Name : ");
            string tmpName = Console.ReadLine();
            tmpName = Methods.Troncate(ref tmpName, props.maxLengthName);

            SettingContact(Carnet, tmpName, props);
        }

        /// <summary>
        /// Permet d'ajouter à un contact d'autres attributs (prenom, mail, etc)
        /// </summary>
        /// <param name="Carnet"></param>
        /// <param name="props"></param>
        public static void SettingContact(List<Properties.Contact> Carnet, string name, Properties.ContactProperties props)
        {
            Properties.Contact tmpContact;
            tmpContact.name = name;

            Console.Write("Contact Prename : ");
            string inpTmp = Console.ReadLine();
            inpTmp = Methods.Troncate(ref inpTmp, props.maxMenghtPrename);
            tmpContact.prename = inpTmp;

            Console.Write("Contact City : ");
            inpTmp = Console.ReadLine();
            inpTmp = Methods.Troncate(ref inpTmp, props.maxLenghtCity);
            tmpContact.city = inpTmp;

            Console.Write("Contact Mail : ");
            inpTmp = Console.ReadLine();
            inpTmp = Methods.Troncate(ref inpTmp, props.maxLenghtMail);
            tmpContact.mail = inpTmp;

            int position = 0;
            while (position < Carnet.Count() && string.Compare(Carnet[position].name, name) < 0)
            {
                ++position;
            }

            Carnet.Insert(position, tmpContact);
        }

        /// <summary>
        /// Sauvegarde les contacts dans le fichier *.txt correspondant
        /// </summary>
        /// <param name="Carnet"></param>
        /// <param name="filepath"></param>
        public static void Save(List<Properties.Contact> Carnet, string filepath)
        {
            int count = 0;
            using(StreamWriter sw = File.CreateText(filepath))
            {
                foreach (var item in Carnet)
                {
                    sw.WriteLine("{0}{1}{2}{3}", item.name, item.prename, item.city, item.mail);
                    ++count;
                }
            }
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
        /// Permet d'ajouter un autre contact au Carnet
        /// </summary>
        /// <param name="Carnet"></param>
        /// <param name="props"></param>
        public static void AnotherContact(List<Properties.Contact> Carnet, Properties.ContactProperties props, bool boo, string filepath)
        {
            while (UserInput != "n")
            {
                Console.Write("Voulez-vous ajouter un autre contact ? (o/n) : ");
                UserInput = Console.ReadLine();

                if (UserInput == "o")
                {
                    Methods.AddContacts(Carnet, props);
                    Methods.Switch(Carnet, props, boo, filepath);
                }
            }
            Console.Clear();
            Methods.Switch(Carnet, props, boo, filepath);
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
        public static void Switch(List<Properties.Contact> Carnet, Properties.ContactProperties props, bool boo, string filepath)
        {
            Methods.DisplayInfo();
            Console.Write("Veuillez saisir une commande : ");
            UserInput = Console.ReadLine();

            switch (UserInput)
            {
                case "a": /*AddContact*/
                case "A":

                    Methods.AddContacts(Carnet, props);
                    Methods.AnotherContact(Carnet, props, boo, filepath);
                    break;

                case "s": /*SaveContact*/
                case "S":

                    Methods.Save(Carnet, filepath);
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
                    Methods.Switch(Carnet, props, boo, filepath);
                    break;
            }
        }

    }//End of Class
}
