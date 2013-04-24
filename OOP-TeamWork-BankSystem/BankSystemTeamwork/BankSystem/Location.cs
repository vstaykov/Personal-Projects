using System;

namespace BankSystem
{
    public abstract class Location
    {
        //Fields
        Address locationAddress;
        string locationName;

        //Properties
        public Address LocationAddress
        {
            get { return this.locationAddress; }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid location address! It cannot be empty!");
                }

                this.locationAddress = value;
            }
        }

        public string LocationName
        {
            get { return this.locationName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid location name! It cannot be empty!");
                }

                this.locationName = value;
            }
        }

        public string Comments { get; set; }

        //Constructor
        public Location(string locationName, Address locationAddress, string comments = null)
        {
            this.LocationName = locationName;
            this.LocationAddress = locationAddress;
            this.Comments = comments;
        }
    }
}
