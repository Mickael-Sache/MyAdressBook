using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyAdressBook
{
    class Program
    {
        const double version = 0.3;

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
            Properties.ContactProperties props;
            props.maxLengthName = 20;
            props.maxMenghtPrename = 15;
            props.maxLenghtCity = 25;
            props.maxLenghtMail = 30;
            #endregion

            List<Properties.Contact> Carnet = new List<Properties.Contact>();

            #region StreamReader
            using (StreamReader sr = File.OpenText(filepath))
            {
                while ((tmp = sr.ReadLine()) != null)
                {
                    Properties.Contact entry;
                    if (string.IsNullOrWhiteSpace(tmp))
                    {
                        Console.WriteLine("Contact Vide");
                    }
                    else if (tmp.Length != props.maxLengthName +
                                           props.maxMenghtPrename +
                                           props.maxLenghtCity +
                                           props.maxLenghtMail)
                    {
                        Console.WriteLine("Format Contact Incorrect");
                    }
                    else
                    {
                        entry.name = tmp.Substring(0, props.maxLengthName);
                        entry.prename = tmp.Substring(props.maxLengthName, props.maxMenghtPrename);
                        entry.city = tmp.Substring(props.maxLengthName + props.maxMenghtPrename, props.maxLenghtCity);
                        entry.mail = tmp.Substring(props.maxLengthName + props.maxMenghtPrename + props.maxLenghtCity, props.maxLenghtMail);

                        Carnet.Add(entry);
                    }
                }
            }
            #endregion

            bool OnStart = true;

            while (OnStart == true)
            {
                Methods.Switch(Carnet, props, OnStart, filepath);
            }

        }//End of Main
    }
}
