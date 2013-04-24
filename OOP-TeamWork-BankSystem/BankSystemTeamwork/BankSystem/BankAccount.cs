using System;
using System.Text;

namespace BankSystem
{
    public abstract class BankAccount
    {
        // Fields
        private AccountType type;
        private AccountCurrency currency;
        private AccountPeriod period;// In months
        private Customer owner;
        private decimal currentBalance;
        private decimal interestRate;
        private long accountNumber;
        const decimal BaseInterest = 0m; 

        public long AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (value > 0)
                {
                    accountNumber = value;
                }
                else
                {
                    throw new ArgumentException("Unique number can't be equal or less than 0");
                }
            }
        }


        // Constructors
        public BankAccount(AccountType type, AccountCurrency currency, AccountPeriod period, Customer owner,
            long accountNumber)
        {
            this.Type = type;
            this.Currency = currency;
            this.Period = period;
            this.Owner = owner;
            this.CurrentBalance = 0;
            this.accountNumber = accountNumber;
            this.CalculateInterestRate();
        }

        // Properties
        public AccountType Type
        {
            get { return this.type; }
            protected set
            {
                this.type = value;
            }
        }

        public AccountCurrency Currency
        {
            get { return this.currency; }
            protected set
            {
                this.currency = value;
            }
        }

        public Customer Owner
        {
            get { return this.owner; }
            protected set { this.owner = value; }
        }

        public AccountPeriod Period
        {
            get
            {
                return this.period;
            }
            protected set
            {
                this.period = value;
            }
        }

        public decimal CurrentBalance
        {
            get
            {
                return this.currentBalance;
            }
            protected set
            {
                if (value >= 0)
                {
                    this.currentBalance = value;
                }
                else
                {
                    throw new ArgumentException("Current balance can't be negative");
                }
            }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            protected set
            {
                if (value >= 0)
                {
                    this.interestRate = value;
                }
                else
                {
                    throw new ArgumentException("Interest rate can't be negative");
                }
            }
        }

        // Methods
        protected void CalculateInterestRate()
        {
            decimal interestRate = 0;
            switch (period)
            {
                case AccountPeriod.One:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 3.5m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 2.5m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 2.5m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 3.5m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 0.3m;
                            break;
                    }
                    break;
                case AccountPeriod.Three:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 3.7m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 3.0m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 2.7m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 3.75m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 0.4m;
                            break;
                    }
                    break;
                case AccountPeriod.Six:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 4.3m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 3.5m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 3.0m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 4.0m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 0.5m;
                            break;
                    }
                    break;
                case AccountPeriod.Twelve:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 5.1m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 4.5m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 3.3m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 4.5m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 0.6m;
                            break;
                    }
                    break;
                case AccountPeriod.Eighteen:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 5.4m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 4.8m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 3.6m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 5.0m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 0.7m;
                            break;
                    }
                    break;
                case AccountPeriod.TwentyFour:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 5.8m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 5.3m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 3.8m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 5.5m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 0.8m;
                            break;
                    }
                    break;
                case AccountPeriod.ThirtySix:
                    switch (currency)
                    {
                        case AccountCurrency.BGN: interestRate = BaseInterest + 7.0m;
                            break;
                        case AccountCurrency.EUR: interestRate = BaseInterest + 5.4m;
                            break;
                        case AccountCurrency.USD: interestRate = BaseInterest + 4.5m;
                            break;
                        case AccountCurrency.GBP: interestRate = BaseInterest + 7.0m;
                            break;
                        case AccountCurrency.CHF: interestRate = BaseInterest + 1.0m;
                            break;
                    }
                    break;
            }
            this.interestRate = interestRate;
        }

        public decimal CalculateInterestAmount()
        {
            decimal interestAmount = 0;
            switch (period)
            {
                case AccountPeriod.One: interestAmount = (this.currentBalance * this.interestRate * (1m / 12m)) / 100;
                    break;
                case AccountPeriod.Three: interestAmount = (this.currentBalance * this.interestRate * (3m / 12m)) / 100;
                    break;
                case AccountPeriod.Six: interestAmount = (this.currentBalance * this.interestRate * (6m / 12m)) / 100;
                    break;
                case AccountPeriod.Twelve: interestAmount = (this.currentBalance * this.interestRate * (12m / 12m)) / 100;
                    break;
                case AccountPeriod.Eighteen: interestAmount = (this.currentBalance * this.interestRate * (18m / 12m)) / 100;
                    break;
                case AccountPeriod.TwentyFour: interestAmount = (this.currentBalance * this.interestRate * (24m / 12m)) / 100;
                    break;
                case AccountPeriod.ThirtySix: interestAmount = (this.currentBalance * this.interestRate * (36m / 12m)) / 100;
                    break;
            }
            return interestAmount;
        }

        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder tempBuilder = new StringBuilder();
            tempBuilder.AppendFormat("Type: {0}\nCurrency: {1}\nPeriod: {2} months\n", this.type,
                this.currency, this.period);
            tempBuilder.Append(this.owner);
            tempBuilder.AppendFormat("Current balance: {0}\nInterest rate: {1}%\nAccount number: {2}\n",
                this.currentBalance, this.interestRate, this.accountNumber);
            return tempBuilder.ToString();
        }

    }
}
