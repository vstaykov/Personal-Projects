using System;
using System.Text;

namespace BankSystem
{
    public class CorporateCustomer : Customer
    {
        //Fields
        private string companyName;
        private string regNumber;

        //Properties
        public string RegNumber
        {
            get { return this.regNumber; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid company registration number! It cannot be null or empty!");
                }
                this.regNumber = value;
            }
        }

        public string CompanyName
        {
            get { return this.companyName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid company name! It cannot be null or empty!");
                }
                this.companyName = value;
            }
        }

        //Constructor
        public CorporateCustomer(string customerID, string companyName, Address companyAddress, string regNumber,
                                 string firstName, string middleName, string lastName, Sex sex, decimal pin)
            : base(customerID, firstName, middleName, lastName, sex, companyAddress, pin)
        {
            this.CompanyName = companyName;
            this.RegNumber = regNumber;
        }

        //Methods
        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            tempString.AppendLine(String.Format("Customer ID: {0}; {1}, {2}", this.CustomerID, this.CompanyName, this.RegNumber));
            tempString.AppendLine(String.Format("Representative: {0} {1} {2}, PIN: {3}, sex: {4}", this.FirstName, this.MiddleName, this.LastName,
                                                                                                    this.Pin, this.Sex));
            tempString.AppendLine(this.Address.ToString());
            return tempString.ToString();
        }
    }
}
