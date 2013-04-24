using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem
{
    public class Office : Location
    {
        //Fields
        private ICollection<Employee> employees;
        private bool isHeadquarter;

        //Properties
        public ICollection<Employee> Employees
        {
            get { return this.employees; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid employees! The office employees cannot be zero/null!");
                }

                this.employees = value;
            }
        }

        public bool IsHeadquater
        {
            get { return this.isHeadquarter; }
            private set { this.isHeadquarter = value; }
        }

        //Constructor
        public Office(string locationName, Address locationAddress, ICollection<Employee> employees = null, string comments = null, bool isHeadquarters = false)
            : base(locationName, locationAddress, comments)
        {
            if (employees != null)
            {
                this.Employees = employees;
            }
            else
            {
                this.Employees = new List<Employee>();
            }
            this.IsHeadquater = isHeadquarters;
        }

        //Methods
        public override string ToString()
        {
            return String.Format("{0}, address: {1}", this.LocationName, this.LocationAddress);
        }

        public void AddEmployee(Employee employeeToAdd)
        {
            if (this.employees.Contains(employeeToAdd))
            {
                throw new ArgumentException(String.Format("Employee with PIN: {0} already exists in {1}", employeeToAdd.Pin, this.LocationName));
            }
            this.employees.Add(employeeToAdd);
        }

        public void RemoveEmployee(decimal PIN)
        {
            var employeeToRemove =
                (from employee in this.employees
                 where employee.Pin == PIN
                 select employee).ToList<Employee>();

            if (employeeToRemove.Count == 0)
            {
                throw new ArgumentException(String.Format("Employee with PIN: {0} does not exist in {1}", PIN, this.LocationName));
            }

            foreach (Employee employee in employeeToRemove)
            {
                this.employees.Remove(employee);
            }
        }

        public Employee GetEmployee(decimal PIN)
        {
            var employeeToReturn =
                (from employee in this.employees
                 where employee.Pin == PIN
                 select employee).ToList<Employee>();

            if (employeeToReturn.Count == 0)
            {
                throw new ArgumentException(String.Format("Employee with PIN: {0} does not exist in {1}", PIN, this.LocationName));
            }

            return employeeToReturn[0];
        }

        public ICollection<Employee> GetAllEmployees()
        {
            if (this.employees == null || this.Employees.Count == 0)
            {
                throw new ArgumentException(String.Format("There are currently no employees in {0}", this.LocationName));
            }
            
            return this.employees;
        }
    }
}
