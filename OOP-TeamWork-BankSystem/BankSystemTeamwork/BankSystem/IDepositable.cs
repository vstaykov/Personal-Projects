using System;
using System.Linq;

namespace BankSystem
{
    interface IDepositable
    {
        void Deposit(decimal amount);
    }
}
