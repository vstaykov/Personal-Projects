using System;
using System.Linq;
using System.Text;

namespace BankSystem
{
    public class LoanAccount : BankAccount, IDepositable
    {
        //Fields
        private decimal loanAmount;

        // Constructors
        public LoanAccount(AccountType type, AccountCurrency currency, AccountPeriod period, decimal loanAmount, Customer owner,
            long accountNumber)
            : base(type, currency, period, owner, accountNumber)
        {
            if (loanAmount > 0)
            {
                this.loanAmount = loanAmount;
            }
            else
            {
                throw new ArgumentException("Amount of the loan must be bigger than 0");
            }
        }

        // Properties
        public decimal LoanAmount
        {
            get
            {
                return this.loanAmount;
            }
            protected set
            {
                if (value > 0)
                {
                    this.loanAmount = value;
                }
                else
                {
                    throw new ArgumentException("Amount of the loan must be bigger than 0");
                }
            }
        }

        // Methods
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Ammount to deposit cannot be equal or less than zero!");
            }
            else
            {
                if (this.CurrentBalance < this.loanAmount)// Check if loan is already paid
                {
                    decimal loanAndCurrentDifference = this.loanAmount - this.CurrentBalance;
                    if (amount <= loanAndCurrentDifference)// Check if customer is trying to deposit more than he owes
                    {
                        this.CurrentBalance += amount;
                    }
                    else
                    {
                        throw new ArgumentException(String.Format("You can deposit maximum of: {0}", loanAndCurrentDifference));
                    }
                }
                else
                {
                    throw new ArgumentException("Your loan is already paid");
                }
            }
        }

        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder tempBuilder = new StringBuilder();
            tempBuilder.AppendLine("Loan Account Info");
            tempBuilder.Append(base.ToString());
            tempBuilder.AppendFormat("Loan ammount: {0}\n", this.loanAmount);
            return tempBuilder.ToString();
        }
    }
}
