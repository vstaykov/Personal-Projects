using System;
using System.Linq;
using System.Text;

namespace BankSystem
{
    public class RealEstate
    {
        // Fields
        private Address address;
        private decimal price;

        // Constructors
        public RealEstate(Address address, decimal price)
        {
            this.address = address;
            if (price > 0)
            {
                this.price = price;
            }
            else
            {
                throw new ArgumentException("Price of the real estate must be bigger than 0");
            }
        }

        // Properties
        public Address Address
        {
            get { return this.Address; }
            set { this.Address = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value > 0)
                {
                    this.price = value;
                }
            }
        }

        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder tempBuilder = new StringBuilder();
            tempBuilder.AppendLine("Real Estate Info");
            tempBuilder.AppendFormat("Address: {0}\n",this.address);
            tempBuilder.AppendFormat("Value: {0}\n", this.price);
            return tempBuilder.ToString();
        }
    }
}
