using CharlesBank.BusinessLogicLayer;
using CharlesBank.BusinessLogicLayer.BALContracts;
using CharlesBank.Entities;
using System;
using System.Collections.Generic;

namespace CharlesBank.Presentation
{
    static class AccountsPresentation
    {
        internal static void AddAccount()
        {
            try
            {
                //create an object of Account
                Account account = new Account();

                //read details from the user
                Console.WriteLine("\n******* ADD ACCOUNT *******");
                Console.Write("Account Customer Code: ");
                var customerCode = System.Convert.ToInt64(System.Console.ReadLine());
                Console.Write("Account Type [Savings, Cheque, Credit, Loan]: ");
                account.AccountType = Console.ReadLine();
                Console.Write("Starting Balance: ");
                account.CurrentBalance = System.Convert.ToDouble(System.Console.ReadLine());

                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                Guid newGuid = accountsBusinessLogicLayer.AddAccount(account, customerCode);

                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountId == newGuid);
                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("New account Code: " + matchingAccounts[0].AccountCode);
                    Console.WriteLine("Account Added.\n");
                }
                else
                {
                    Console.WriteLine("Account not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void DeleteAccount()
        {
            try
            {
                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Account> allAccounts = accountsBusinessLogicLayer.GetAccounts();
                Console.WriteLine("\n******* DELETE ACCOUNT *******");

                System.Console.Write("\nAccount Code: ");
                var accountCode = System.Convert.ToInt64(System.Console.ReadLine());

                // Find the accounts with the criteria
                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == accountCode);
                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("Account Code: " + matchingAccounts[0].AccountCode);
                    Console.WriteLine("Account Type: " + matchingAccounts[0].AccountType);

                    // Find the customer with the criteria
                    List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerId == matchingAccounts[0].CustomerId);
                    if (matchingCustomers.Count >= 1)
                    {
                        Console.WriteLine("\tCustomer Code: " + matchingCustomers[0].CustomerCode);
                        Console.WriteLine("\tCustomer Name: " + matchingCustomers[0].CustomerName);
                    }
                    Console.WriteLine("Balance: $" + matchingAccounts[0].CurrentBalance);

                    Console.Write("\nAre you sure you wish to delete: [Y/N] ");
                    var choice = System.Console.ReadLine();

                    if (choice.ToUpper() == "Y")
                    {
                        if (accountsBusinessLogicLayer.DeleteAccount(matchingAccounts[0].AccountId))
                        {
                            Console.WriteLine("Account deleted.\n");
                        }
                        else
                        {
                            Console.WriteLine("Account not deleted.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Delete cancelled.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void UpdateAccount()
        {
            try
            {
                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Account> allAccounts = accountsBusinessLogicLayer.GetAccounts();
                Console.WriteLine("\n******* UPDATE ACCOUNT *******");

                System.Console.Write("\nAccount Code: ");
                var accountCode = System.Convert.ToInt64(System.Console.ReadLine());

                // Find the accounts with the criteria
                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == accountCode);
                if (matchingAccounts.Count >= 1)
                {
                    List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();


                    // Find the customers with the criteria
                    List<Customer> accountCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerId == matchingAccounts[0].CustomerId);

                    // Display current values and allow user to change
                    var input = "";

                    Console.WriteLine("Customer Name: " + accountCustomers[0].CustomerName);
                    Console.WriteLine("Customer Code: " + accountCustomers[0].CustomerCode);
                    input = Console.ReadLine();


                    // Find the customers with the criteria
                    List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerId == matchingAccounts[0].CustomerId);
                    if (matchingCustomers.Count >= 1)
                    {
                        if (accountsBusinessLogicLayer.UpdateAccount(matchingAccounts[0]))
                        {
                            Console.WriteLine("Account updated.\n");
                        }
                        else
                        {
                            Console.WriteLine("Account not updated.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Customer not found. Account not updated.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewAccounts()
        {
            try
            {
                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                List<Account> allAccounts = accountsBusinessLogicLayer.GetAccounts();
                Console.WriteLine("\n******* ALL ACCOUNTS *******");

                // display all accounts
                foreach (var item in allAccounts)
                {
                    PrintAccount(item);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void PrintAccountHeader(Guid accountId)
        {
            try
            {
                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                // display account of
                List<Account> matchingAccounts =
                    accountsBusinessLogicLayer.GetAccountsByCondition(acc => acc.AccountId == accountId);
                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("Account Code: " + matchingAccounts[0].AccountCode);
                    CustomersPresentation.PrintCustomerCodeAndName(matchingAccounts[0].CustomerId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void PrintAccount(Account account)
        {
            try
            {
                Console.WriteLine($"Account Code: {account.AccountCode}    |  Type: {account.AccountType} ");

                // display customer of account
                CustomersPresentation.PrintCustomerCodeAndName(account.CustomerId);

                Console.WriteLine("Balance: $" + account.CurrentBalance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

    }
}
