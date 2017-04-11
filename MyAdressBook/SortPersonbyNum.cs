using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAdressBook
{
    class SortPersonbyNum : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person first, Person second)
        {
            if (first.Number > second.Number)
                return 1;
            if (first.Number < second.Number)
                return -1;
            else
                return 0;
        }



    }
}
