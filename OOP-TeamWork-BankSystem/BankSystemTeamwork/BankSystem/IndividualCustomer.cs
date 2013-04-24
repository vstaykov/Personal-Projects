using System;
using System.Text;

namespace BankSystem
{
    public class IndividualCustomer : Customer
    {
        //Constructor
        public IndividualCustomer(string customerID, string firstName, string middleName, string lastName, Sex sex, Address address, decimal pin)
            : base(customerID, firstName, middleName, lastName, sex, address, pin)
        {
        }

        //Methods
        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            tempString.AppendLine(String.Format("Customer ID: {0}; {1} {2} {3}, PIN: {4}, sex: {5}", this.CustomerID, this.FirstName, this.MiddleName,
                                                    this.LastName, this.Pin, this.Sex));
            tempString.AppendLine(this.Address.ToString());
            return tempString.ToString();
        }
    }
}
