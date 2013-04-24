using System;
using System.Text;

namespace BankSystem
{
    public class Address
    {
        //Fields
        private string country;
        private string city;
        private string residence;
        private string street;
        private int? residentialBlock;
        private char? entrance;
        private byte? floor;
        private byte? appartment;
        private int zip;

        //Properties
        public string Country
        {
            get { return this.country; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid country! It cannot be null or empty!");
                }

                this.country = value;
            }
        }

        public string City
        {
            get { return this.city; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid country! It cannot be null or empty!");
                }

                this.city = value;
            }
        }

        public string Residence
        {
            get { return this.residence; }
            set { this.residence = value; }
        }

        public string Street
        {
            get { return this.street; }
            set { this.street = value; }
        }

        public int? ResidentialBlock
        {
            get { return this.residentialBlock; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid residential block number! It cannot be a negative value!");
                }

                this.residentialBlock = value;
            }
        }

        public char? Entrance
        {
            get { return this.entrance; }
            set { this.entrance = value; }
        }

        public byte? Floor
        {
            get { return this.floor; }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Invalud floor number! It cannot be a negative value or greater than 150!");
                }

                this.floor = value;
            }
        }

        public byte? Appartment
        {
            get { return this.appartment; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid appartment number! It cannot be a negative value!");
                }

                this.appartment = value;
            }
        }

        public int ZIP
        {
            get { return this.zip; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid ZIP code!  It cannot be zero or negative!");
                }

                this.zip = value;
            }
        }

        public string Comments { get; set; }

        //Constructors
        public Address(string country, string city, int zip, string street, string comments = null)
            : this(country, city, zip, null, street, null, null, null, null, comments)
        {
        }

        public Address(string country, string city, int zip, string residence, string street, string comments = null)
            : this(country, city, zip, residence, street, null, null, null, null, comments)
        {
        }

        public Address(string country, string city, int zip, string residence, int? residentialBlock, char? entrance, byte? floor, byte? appartment, string comments = null)
            : this(country, city, zip, residence, null, residentialBlock, entrance, floor, appartment, comments)
        {
        }

        public Address(string country, string city, int zip, string residence, string street, int? residentialBlock, char? entrance, byte? floor, byte? appartment, string comments = null)
        {
            this.Country = country;
            this.City = city;
            this.ZIP = zip;
            this.Residence = residence;
            this.Street = street;
            this.ResidentialBlock = residentialBlock;
            this.Entrance = entrance;
            this.Floor = floor;
            this.Appartment = appartment;
            this.Comments = comments;
        }

        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder();
            tempString.AppendFormat("{0}, {1}, {2}", this.Country, this.City, this.ZIP);
            if (this.residence != null)
            {
                tempString.AppendFormat(", {0}", this.Residence);
            }

            if (this.street != null)
            {
                tempString.AppendFormat(", {0}", this.Street);
            }
            else
            {
                tempString.AppendFormat(", {0}, {1}, {2}, {3}", this.ResidentialBlock, this.Entrance, this.Floor, this.Appartment);
            }

            if (this.Comments != null)
            {
                tempString.AppendLine();
                tempString.AppendLine(Comments);
            }

            return tempString.ToString();
        }
    }
}
