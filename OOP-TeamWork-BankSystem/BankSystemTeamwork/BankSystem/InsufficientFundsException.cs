using System;

namespace BankSystem
{
    public class InsufficientFundsException : ApplicationException
    {
        //Fields
        private decimal amount;
        private decimal balance;

        //Properties
        public decimal Amount
        {
            get { return this.amount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be a negative value!");
                }
                this.amount = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be a negative value!");
                }
                this.balance = value;
            }
        }

        //Constructors
        public InsufficientFundsException(string msg, decimal amount, decimal balance)
            : base(msg)
        {
            this.Amount = amount;
            this.Balance = balance;
        }

        public InsufficientFundsException(string msg, decimal amount, decimal balance, Exception innerEx)
            : base(msg, innerEx)
        {
            this.Amount = amount;
            this.Balance = balance;
        }
    }
}
