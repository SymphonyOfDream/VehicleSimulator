using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace VehicleSimulator
{
    public class Address : IEquatable<Address>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }


        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(Country) == false;
            }
        }

        public override string ToString()
        {
            string str = string.IsNullOrEmpty(Street) ? "" : Street;

            if (!string.IsNullOrEmpty(City))
            {
                if (str.Length > 0)
                    str += ", ";

                str += City;
            }
            if (!string.IsNullOrEmpty(State))
            {
                if (str.Length > 0)
                    str += ", ";

                str += State;
            }
            if (!string.IsNullOrEmpty(Country))
            {
                if (str.Length > 0)
                    str += ", ";

                str += Country;
            }


            return str;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Address);
        }


        #region IEquatable<Address> Members

        public bool Equals(Address other)
        {
            if (other == null)
                return false;

            return this.GetHashCode() == other.GetHashCode();
        }

        #endregion



    }
}
