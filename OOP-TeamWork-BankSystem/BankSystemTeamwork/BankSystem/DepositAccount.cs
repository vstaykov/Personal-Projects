using System;
using System.Linq;
using System.Text;

namespace BankSystem
{
    public class DepositAccount : BankAccount, IDepositable, IWithdrawable
    {
        // Constructors
        public DepositAccount(AccountType type, AccountCurrency currency, AccountPeriod period, Customer owner,
            long accountNumber)
            : base(type, currency, period, owner, accountNumber)
        {
        }

        // Methods
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Ammount to deposit cannot be equal or less than zero!");
            }
            this.CurrentBalance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.CurrentBalance >= amount)
            {
                this.CurrentBalance -= amount;
            }
            else
            {
                throw new InsufficientFundsException("Insufficient funds!", amount, this.CurrentBalance);
            }
        }

        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder tempBuilder = new StringBuilder();
            tempBuilder.AppendLine("Deposit Account Info");
            tempBuilder.Append(base.ToString());
            return tempBuilder.ToString();
        }
    }
}
