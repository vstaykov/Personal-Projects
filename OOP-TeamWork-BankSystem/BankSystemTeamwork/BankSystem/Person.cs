using System;

namespace BankSystem
{
    public abstract class Person
    {
        //FIelds
        private string firstName;
        private string middleName;
        private string lastName;
        private Sex sex;
        private Address address;
        private decimal pin;

        //Properties
        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid first name! It cannot be null or empty value!");
                }
                this.firstName = value;
            }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid middle name! It cannot be null or empty value!");
                }
                this.middleName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid last name! It cannot be null or empty value!");
                }
                this.lastName = value;
            }
        }
        public Sex Sex
        {
            get { return this.sex; }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid input value! Sex cannot be null!");
                }
                this.sex = value;
            }
        }
        public Address Address
        {
            get { return this.address; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid address! It cannot be null or empty!");
                }
                this.address = value;
            }
        }
        public decimal Pin
        {
            get { return this.pin; }
            protected set
            {
                if (value < 0 || value < 1000000000)
                {
                    throw new ArgumentException("Invalid PIN! It cannot be negative or contain less than 10 digits!");
                }
                this.pin = value;
            }
        }

        //Constructor
        public Person(string firstName, string middleName, string lastName, Sex sex, Address address, decimal pin)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Sex = sex;
            this.Address = address;
            this.Pin = pin;
        }
    }
}
