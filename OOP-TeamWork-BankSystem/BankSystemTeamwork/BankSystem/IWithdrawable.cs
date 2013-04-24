using System;
using System.Linq;

namespace BankSystem
{
    interface IWithdrawable
    {
        void Withdraw(decimal amount);
    }
}
