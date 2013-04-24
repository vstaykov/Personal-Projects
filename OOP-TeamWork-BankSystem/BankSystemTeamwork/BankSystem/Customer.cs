using System;

namespace BankSystem
{
    public abstract class Customer : Person
    {
        //Fields
        private string customerID;

        //Properties
        public string CustomerID
        {
            get { return this.customerID; }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid customer ID! It cannot be null or empty!");
                }
                this.customerID = value;
            }
        }

        //Constructor
        public Customer(string customerID, string firstName, string middleName, string lastName, Sex sex, Address address, decimal pin)
            : base(firstName, middleName, lastName, sex, address, pin)
        {
            this.CustomerID = customerID;
        }
    }
}
