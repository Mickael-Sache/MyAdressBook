using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace MyAdressBook
{
    class Program
    {
        const double version = 0.3;

        private static int maxLengthName;
        private static int maxMenghtPrename;
        private static int maxLenghtCity;
        private static int maxLenghtNumber;
        private static int maxLenghtMail;

        static void Main(string[] args)
        {
            #region FileProperties
            /*
            Settings for StreamWriter to a *.txt file
            */
            string fileName = @"Mybook.txt";
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            string filepath = dir.Parent.FullName + "\\" + fileName;

            //Test where is the filepath
            //Console.WriteLine(filepath);

            string tmp;
            #endregion

            #region VarParameters
            /*
            Set a MaxLenght properties to create contacts
            */
            maxLengthName = 20;
            maxMenghtPrename = 15;
            maxLenghtCity = 25;
            maxLenghtNumber = 10;
            maxLenghtMail = 30;

            #endregion

            //SortedList<Properties.Contact, Properties.ContactProperties>
            //Class Properties avec un Constructor -- Add
            //Class person + Carnet avec Method Add
            //Add item to contacts
            //Delegate avec Compare
            //Ou list.sort by typeContact (obj1, obj2)
            //Key = numtel -- Value = person


            using (StreamReader sr = File.OpenText(filepath))
            {
                while ((tmp = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(tmp))
                    {
                        Console.WriteLine("Contact Vide");
                    }
                }
            }


        }//End of Main
    }
}

