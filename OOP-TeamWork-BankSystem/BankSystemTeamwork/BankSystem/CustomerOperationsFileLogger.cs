using System;
using System.IO;

namespace BankSystem
{
    public class CustomerOperationsFileLogger : LogToFileMechanism
    {
        public CustomerOperationsFileLogger()
        {
            this.Destination = "customerslog.txt";
        }
        public override void AddToLog(object sender, EventArgs e)
        {
            var arguments = e as CustomerOperationsEventArgs;

            StreamWriter logWriter = new StreamWriter(this.Destination, true);

            using (logWriter)
            {
                logWriter.WriteLine("{0}: customerID: {1}; name: {2} {3}, PIN: {4}, comments: {5} on {6}",
                                    arguments.Operation, arguments.CustomerID, arguments.FirstName, arguments.LastName,
                                    arguments.PIN, arguments.Comments, arguments.Time);
            }
        }
    }
}
