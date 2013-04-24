using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class BankSystemMain
    {
        static void Main()
        {
            //Make na instance of the log system
            AccountOperationsFileLogger accountLogger = new AccountOperationsFileLogger();
            CustomerOperationsFileLogger customerLogger = new CustomerOperationsFileLogger();

            //Add subscribers to the event add/remove account/customer
            BankEngine.Instance.AccountOperation += accountLogger.AddToLog;
            BankEngine.Instance.CustomerOperation += customerLogger.AddToLog;


            //Make a list of employees
            List<Employee> mladostEmployees = new List<Employee>{
                new Employee("Pesho","Peshev","Peshev", Sex.Male,new Address("Bulgaria", "Sofia",1713,"Mladost 1A",604,'A',4,18),7812123558M,852.75M,Position.President),
                new Employee("Kiro","Kirov","Kirov", Sex.Male,new Address("Bulgaria", "Sofia",1713,"Mladost 1A",607,'A',7,32),7412123558M,852.75M,Position.Casher),
                                              };

            //Make an address
            Address locationMladost = new Address("Bulgaria", "Sofia", 1713, "bul.Al. Malinow 75");
            //Make an office with the current employee set
            Office officeMladost1A = new Office("Mladost 1A", locationMladost, mladostEmployees);

            //Add the office to the system
            BankEngine.Instance.AddLocation(officeMladost1A);

            //Add an ATM to the system
            BankEngine.Instance.AddLocation(new ATM("Mladost 1A", locationMladost, 5410, Priority.High));

            //Add an individual customer to the system
            IndividualCustomer peshoIvanov = new IndividualCustomer("IC745547", "Pesho", "Ivanov", "Ivanov", Sex.Male, new Address("Bulgaria", "Sofia", 1713, "ul.Bydnina 13"),
                                                                     8709122554M);
            //IMPORTANT
            BankEngine.Instance.AddCustomer(peshoIvanov);

            //Make an account and add it to the system
            DepositAccount peshoOODDeposit = new DepositAccount(AccountType.Corporate, AccountCurrency.EUR, AccountPeriod.Six,
                                             new CorporateCustomer("CC55475", "PeshoOOD", new Address("Bulgaria", "Sofia", 1713, "ul.Igumen 12"), "BGCT855474V",
                                                 "Pesho", "Ivanov", "Ivanov", Sex.Male, 8709122554M), 558574L);
            //IMPORTANT
            BankEngine.Instance.AddAccount(peshoOODDeposit);

            Console.WriteLine("BankEngine added new customer and account! The information was logged!");
            Console.WriteLine();

            //Deposit some money in peshoOODDeposit
            peshoOODDeposit.Deposit(5841.54M);

            //Trying to withdraw more than the balance of peshoOODDeposit
            try
            {
                Console.WriteLine("Try to withdraw more than the balance of an account:");
                peshoOODDeposit.Withdraw(6000M);
            }
            catch (InsufficientFundsException ife)
            {

                Console.WriteLine(ife.Message + "You've tried to withdraw {0} but the current balance is {1}!", ife.Amount, ife.Balance);
            }
            Console.WriteLine();
        }
    }
}
