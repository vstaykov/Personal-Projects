using System;
using System.Text;

namespace BankSystem
{
    public class Employee : Person
    {
        //Fields
        private decimal salary;
        private Position position;

        //Properties
        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid salary! It cannot be a negative value!");
                }
                this.salary = value;
            }
        }

        public Position Position
        {
            get { return this.position; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid position! It cannot be empty or null!");
                }
                this.position = value;
            }
        }

        //Constructor   
        public Employee(string firstName, string middleName, string lastName, Sex sex, Address address, decimal pin, decimal salary, Position position)
            : base(firstName, middleName, lastName, sex, address, pin)
        {
            this.Salary = salary;
            this.Position = position;
        }

        //Methods
        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            tempString.AppendLine(String.Format("Position: {0}; {1} {2} {3}, PIN: {4}, sex: {5}, salary: {6}", this.Position, this.FirstName, this.MiddleName,
                                                    this.LastName, this.Pin, this.Sex, this.Salary));
            tempString.AppendLine(this.Address.ToString());
            return tempString.ToString();
        }
    }
}
