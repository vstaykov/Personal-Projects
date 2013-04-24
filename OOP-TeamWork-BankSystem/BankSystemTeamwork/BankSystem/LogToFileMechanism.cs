using System;

namespace BankSystem
{
    public abstract class LogToFileMechanism : ILogMechanism
    {
        //Fields
        private string destination;

        //Properties
        public string Destination
        {
            get { return destination; }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Destination file path cannot be empty or null!");
                }
                destination = value;
            }
        }

        public abstract void AddToLog(object sender, EventArgs e);
    }
}
