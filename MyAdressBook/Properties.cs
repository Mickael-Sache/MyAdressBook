using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyAdressBook
{
    /// <summary>
    /// Struct who define some parameters to Create Contacts
    /// </summary>
    struct Properties
    {
        /// <summary>
        /// Define different var type for Contacts
        /// </summary>
        public struct Contact
        {
            public string name;
            public string prename;
            public string city;
            public string mail;
        }

        /// <summary>
        /// Define some parameters for Contacts
        /// </summary>
        public struct ContactProperties
        {
            public int maxLengthName;
            public int maxMenghtPrename;
            public int maxLenghtCity;
            public int maxLenghtMail;
        }


    }
}
