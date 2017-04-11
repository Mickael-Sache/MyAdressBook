using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdressBook
{
    class Person
    {
        private string _name;
        private string _prename;
        private string _city;
        private int _number;
        private string _email;

        /*
        Accesseurs 
        */

        public string Name
        {
            get { return _name; }
            set { Name = value; }
        }

        public string PreName
        {
            get { return _prename; }
            set { PreName = value; }
        }

        public string City
        {
            get { return _city; }
            set { City = value; }
        }

        public string Email
        {
            get { return _email; }
            set { Email = value; }
        }

        public int Number
        {
            get { return _number; }
            set { Number = value; }
        }


        /*
        Constructeurs 
        */

        public Person()
        {

        }

        public Person(string Name, string Prename, string City, int Number, string Email)
        {
            Name = _name;
            PreName = _prename;
            City = _city;
            Number = _number;
            Email = _email;
        }


    }
}
