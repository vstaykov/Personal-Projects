using System;
using System.IO;

namespace BankSystem
{
    public class AccountOperationsFileLogger : LogToFileMechanism
    {
        public AccountOperationsFileLogger()
        {
            this.Destination = "accountslog.txt";
        }

        public override void AddToLog(object sender, EventArgs e)
        {
            var arguments = e as AccountOpperationsEventArgs;

            StreamWriter logWriter = new StreamWriter(this.Destination, true);

            using (logWriter)
            {
                logWriter.WriteLine("{0}: type: {1}; accID: {2}; customerID: {3} on {4}", arguments.Operation, arguments.Type, arguments.AccountID, arguments.CustomerID, arguments.Time);
            }
        }
    }
}
