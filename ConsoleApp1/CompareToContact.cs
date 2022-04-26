using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CompareToContact :IComparer<AddressBook>
    {

        public enum sortBy
        {
            firstName,
            city,
            state,
            zip
        }
        public sortBy compareThroughFields;

        public int Compare(AddressBook x, AddressBook y)
        {
            switch (compareThroughFields)
            {
                case sortBy.firstName:
                    return x.firstName.CompareTo(y.firstName);
                case sortBy.city:
                    return x.city.CompareTo(y.city);
                case sortBy.state:
                    return x.state.CompareTo(y.state);
                case sortBy.zip:
                    return x.zip.CompareTo(y.zip);
                default: break;

            }
            // Invalid Option
            return x.firstName.CompareTo(y.firstName);

        }
    }
}
