using System;

namespace BankSystem
{
    public class AccountOpperationsEventArgs : EventArgs
    {
        //Properties
        public long AccountID { get; private set; }
        public string CustomerID { get; private set; }
        public string Operation { get; private set; }
        public object Time { get; private set; }
        public string Type { get; private set; }

        //Constructor
        public AccountOpperationsEventArgs(long accountID, string customerID, string operation, string type)
        {
            this.AccountID = accountID;
            this.CustomerID = customerID;
            this.Operation = operation;
            this.Time = DateTime.Now;
            this.Type = type;
        }
    }
}
