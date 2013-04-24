using System;

namespace BankSystem
{
    public class ATM : Location
    {
        //Fields
        private Priority priority;
        private int balance;

        //Properties
        public Priority Priority
        {
            get { return this.priority; }
            private set { this.priority = value; }
        }

        public int Balance
        {
            get { return this.balance; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid ATM balance! It cannot be a negative value!");
                }

                this.balance = value;
            }
        }

        //Constructor
        public ATM(string locationName, Address locationAddress, int balance, Priority priority, string comments = null)
            : base(locationName, locationAddress, comments)
        {
            this.Balance = balance;
            this.Priority = priority;
        }

        //Methods
        public override string ToString()
        {
            return String.Format("ATM - {0}, {1}; balance: {2}, priority: {3}", this.LocationName, this.LocationAddress, this.Balance, this.Priority);
        }
    }
}
