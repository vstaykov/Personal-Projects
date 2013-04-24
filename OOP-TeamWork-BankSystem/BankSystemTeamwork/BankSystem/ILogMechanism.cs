using System;

namespace BankSystem
{
    public interface ILogMechanism
    {
        void AddToLog(object sender, EventArgs e);
    }
}
