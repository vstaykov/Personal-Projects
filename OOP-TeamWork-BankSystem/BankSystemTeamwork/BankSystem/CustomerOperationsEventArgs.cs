using System;

namespace BankSystem
{
    public class CustomerOperationsEventArgs : EventArgs
    {
        //Properties
        public string CustomerID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public decimal PIN { get; private set; }
        public string Operation { get; private set; }
        public object Time { get; private set; }
        public string Comments { get; private set; } //use this with other than individual customers, e.g when the customer is corporate - add the company name

        //Constructor
        public CustomerOperationsEventArgs(string customerID, string firstName, string lastName, decimal PIN, string operation, string comments = null)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PIN = PIN;
            this.Operation = operation;
            this.Time = DateTime.Now;
            this.Comments = comments;
        }
    }
}
