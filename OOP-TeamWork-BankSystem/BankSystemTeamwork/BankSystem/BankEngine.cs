using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem
{
    public class BankEngine
    {
        //Fields
        private static BankEngine instance;
        private ICollection<Location> locations;
        private ICollection<BankAccount> accounts;
        private ICollection<Customer> customers;

        //Delegates for the events
        public delegate void AccountOperationsEventHandler(object sender, AccountOpperationsEventArgs e);
        public delegate void CustomerOperationsEventHandler(object sender, CustomerOperationsEventArgs e);

        //The events
        public event AccountOperationsEventHandler AccountOperation;
        public event CustomerOperationsEventHandler CustomerOperation;

        //Constructors
        private BankEngine()
        {
            this.locations = new List<Location>();
            this.accounts = new List<BankAccount>();
            this.customers = new List<Customer>();
        }

        //Properties
        public static BankEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BankEngine();
                }
                return instance;
            }
        }

        //Methods
        //The event raisers
        public void OnAccountOperation(AccountOpperationsEventArgs e)
        {
            if (AccountOperation != null)
            {
                AccountOperation(this, e);
            }
        }

        public void OnCustomerOperation(CustomerOperationsEventArgs e)
        {
            if (CustomerOperation != null)
            {

                CustomerOperation(this, e);
            }
        }

        //Add account
        public void AddAccount(BankAccount accountToAdd)
        {
            var addAccount = (
               from account in this.accounts
               where account.AccountNumber == accountToAdd.AccountNumber
               select account).ToList();

            if (addAccount.Count != 0)
            {
                throw new ArgumentException(String.Format("Account with ID: {0} already exists in the system!", accountToAdd.AccountNumber));
            }
            if (!this.customers.Contains(accountToAdd.Owner))
            {
                this.AddCustomer(accountToAdd.Owner);
            }
            this.accounts.Add(accountToAdd);
            OnAccountOperation(new AccountOpperationsEventArgs(accountToAdd.AccountNumber, accountToAdd.Owner.CustomerID, "ADD",
                                                               accountToAdd.GetType().Name));
        }

        //Remove account
        public void RemoveAccount(long accountID)
        {
            var accountToRemove = (
                from account in this.accounts
                where account.AccountNumber == accountID
                select account).ToList();

            if (accountToRemove.Count == 0)
            {
                throw new ArgumentException(String.Format("You cannot remove account with ID: {0}, because it does not exist in the system!", accountID));
            }

            this.accounts.Remove(accountToRemove[0]);
            OnAccountOperation(new AccountOpperationsEventArgs(accountToRemove[0].AccountNumber, accountToRemove[0].Owner.CustomerID, "REMOVE",
                                                               accountToRemove[0].GetType().Name));
        }

        //Get account by ID
        public BankAccount GetAccount(long accountID)
        {
            var neededAccount = (
                from account in this.accounts
                where account.AccountNumber == accountID
                select account).ToList();

            if (neededAccount.Count == 0)
            {
                throw new ArgumentException(String.Format("Account with ID:{0} does not exist in the system!", accountID));
            }

            return neededAccount[0];
        }

        //Add customer
        public void AddCustomer(Customer customerToAdd)
        {
            var addCustomer = (
                from customer in this.customers
                where (customer.CustomerID == customerToAdd.CustomerID) ||
                      (customer.Pin == customerToAdd.Pin &&
                      customer.GetType() == customerToAdd.GetType())
                select customer).ToList();

            if (addCustomer.Count != 0)
            {
                throw new ArgumentException(String.Format("Customer with ID: {0} or PIN: {1} already exists in the system!",
                                                           customerToAdd.CustomerID, customerToAdd.Pin));
            }

            this.customers.Add(customerToAdd);
            OnCustomerOperation(new CustomerOperationsEventArgs(customerToAdd.CustomerID, customerToAdd.FirstName, customerToAdd.LastName,
                                                                customerToAdd.Pin, "ADD", customerToAdd.GetType().Name));
        }

        //Remove customer
        public void RemoveCustomer(string customerID)
        {
            var removeCustomer = (
               from customer in this.customers
               where customer.CustomerID == customerID
               select customer).ToList();

            if (removeCustomer.Count == 0)
            {
                throw new ArgumentException(String.Format("Customer with ID: {0} does not exist in the system!", customerID));
            }

            this.customers.Remove(removeCustomer[0]);
            OnCustomerOperation(new CustomerOperationsEventArgs(removeCustomer[0].CustomerID, removeCustomer[0].FirstName, removeCustomer[0].LastName,
                                                                removeCustomer[0].Pin, "ADD", removeCustomer[0].GetType().Name));
        }

        //Get customer by ID
        public Customer GetCustomer(string customerID)
        {
            var neededCustomer = (
               from customer in this.customers
               where customer.CustomerID == customerID
               select customer).ToList();

            if (neededCustomer.Count == 0)
            {
                throw new ArgumentException(String.Format("Customer with ID: {0} does not exist in the system!", customerID));
            }

            return neededCustomer[0];
        }

        //Add location
        public void AddLocation(Location locationToAdd)
        {
            var addLocation = (
                from location in this.locations
                where (location.LocationName == locationToAdd.LocationName ||
                      location.LocationAddress == locationToAdd.LocationAddress) &&
                      location.GetType() == locationToAdd.GetType()
                select location).ToList();

            if (addLocation.Count != 0)
            {
                throw new ArgumentException("A location of the same type and the same name/address already exists in the system!");
            }

            this.locations.Add(locationToAdd);
        }

        //Remove location
        public void RemoveLocation(string locationName, string locationType)
        {
            var removeLocation = (
                from location in this.locations
                where location.LocationName == locationName &&
                      location.GetType().Name == locationType
                select location).ToList();

            if (removeLocation.Count == 0)
            {
                throw new ArgumentException("The location you try to remove does not exist in the system!");
            }

            this.locations.Remove(removeLocation[0]);
        }

        //Get location
        public Location GetLocation(string locationName, string locationType)
        {

            var neededLocation = (
                from location in this.locations
                where location.LocationName == locationName &&
                      location.GetType().Name == locationType
                select location).ToList();

            if (neededLocation.Count == 0)
            {
                throw new ArgumentException("The location you try to get does not exist in the system!");
            }

            return neededLocation[0];
        }

        public ICollection<Location> GetLocationsByType(string type)
        {
            var allLocationsOfType = (
                from location in this.locations
                where location.GetType().Name == type
                select location).ToList();

            if (allLocationsOfType.Count == 0)
            {
                throw new ArgumentException("Invalid input type of location!");
            }

            return allLocationsOfType;
        }
    }
}
