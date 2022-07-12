using CharlesBank.BusinessLogicLayer;
using CharlesBank.BusinessLogicLayer.BALContracts;
using CharlesBank.Entities;
using System;
using System.Collections.Generic;

namespace CharlesBank.Presentation
{
    static class CustomersPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                //create an object of Customer
                Customer customer = new Customer();

                //read details from the user
                Console.WriteLine("\n******* ADD CUSTOMER *******");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);


                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerId == newGuid);
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added.\n");
                }
                else
                {
                    Console.WriteLine("Customer not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void DeleteCustomer()
        {
            try
            {
                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n******* DELETE CUSTOMER *******");

                System.Console.Write("\nCustomer Code: ");
                var customerCode = System.Convert.ToInt64(System.Console.ReadLine());

                // Find the customers with the criteria
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode);
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("Customer Name: " + matchingCustomers[0].CustomerName);
                    Console.Write("\nAre you sure you wish to delete: [Y/N] ");
                    var choice = System.Console.ReadLine();

                    if (choice.ToUpper() == "Y")
                    {
                        if (customersBusinessLogicLayer.DeleteCustomer(matchingCustomers[0].CustomerId))
                        {
                            Console.WriteLine("Customer deleted.\n");
                        }
                        else
                        {
                            Console.WriteLine("Customer not deleted.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Delete cancelled.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void SearchCustomer()
        {
            try
            {
                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n******* SEARCH CUSTOMER *******");

                System.Console.Write("\nCustomer Code: ");
                var customerCode = System.Convert.ToInt64(System.Console.ReadLine());

                // Find the customers with the criteria
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode);
                if (matchingCustomers.Count >= 1)
                {
                    // display customers found
                    foreach (var item in matchingCustomers)
                    {
                        Console.WriteLine("Customer Code: " + item.CustomerCode);
                        Console.WriteLine("Customer Name: " + item.CustomerName);
                        Console.WriteLine("Customer Address: " + item.Address);
                        Console.WriteLine("Customer Landmark: " + item.Landmark);
                        Console.WriteLine("Customer City: " + item.City);
                        Console.WriteLine("Customer Country: " + item.Country);
                        Console.WriteLine("Customer Mobile: " + item.Mobile);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void UpdateCustomer()
        {
            try
            {
                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n******* UPDATE CUSTOMER *******");

                System.Console.Write("\nCustomer Code: ");
                var customerCode = System.Convert.ToInt64(System.Console.ReadLine());

                // Find the customers with the criteria
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode);
                if (matchingCustomers.Count >= 1)
                {
                    // Display current values and allow user to change
                    var input = "";

                    Console.WriteLine("Customer Name: " + matchingCustomers[0].CustomerName);
                    input = Console.ReadLine();
                    if (input != String.Empty)
                    {
                        matchingCustomers[0].CustomerName = input;
                    }

                    Console.WriteLine("Address: " + matchingCustomers[0].Address);
                    input = Console.ReadLine();
                    if (input != String.Empty)
                    {
                        matchingCustomers[0].Address = input;
                    }

                    Console.WriteLine("Landmark: " + matchingCustomers[0].Landmark);
                    input = Console.ReadLine();
                    if (input != String.Empty)
                    {
                        matchingCustomers[0].Landmark = input;
                    }

                    Console.WriteLine("City: " + matchingCustomers[0].City);
                    input = Console.ReadLine();
                    if (input != String.Empty)
                    {
                        matchingCustomers[0].City = input;
                    }

                    Console.WriteLine("Country: " + matchingCustomers[0].Country);
                    input = Console.ReadLine();
                    if (input != String.Empty)
                    {
                        matchingCustomers[0].Country = input;
                    }

                    Console.WriteLine("Mobile: " + matchingCustomers[0].Mobile);
                    input = Console.ReadLine();
                    if (input != String.Empty)
                    {
                        matchingCustomers[0].Mobile = input;
                    }

                    if (customersBusinessLogicLayer.UpdateCustomer(matchingCustomers[0]))
                    {
                        Console.WriteLine("Customer updated.\n");
                    }
                    else
                    {
                        Console.WriteLine("Customer not updated.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewCustomers()
        {
            try
            {
                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n******* ALL CUSTOMERS *******");

                // display all customers
                foreach (var item in allCustomers)
                {
                    PrintCustomer(item);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void PrintCustomerCodeAndName(Guid customerId)
        {
            try
            {
                // Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                // display customer
                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(cust => cust.CustomerId == customerId);
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine($"Customer Code: {matchingCustomers[0].CustomerCode}   | Name: {matchingCustomers[0].CustomerName} ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void PrintCustomer(Customer customer)
        {
            try
            {
                Console.WriteLine("Customer Code: " + customer.CustomerCode);
                Console.WriteLine("Customer Name: " + customer.CustomerName);
                Console.WriteLine("Customer Address: " + customer.Address);
                Console.WriteLine("Customer Landmark: " + customer.Landmark);
                Console.WriteLine("Customer City: " + customer.City);
                Console.WriteLine("Customer Country: " + customer.Country);
                Console.WriteLine("Customer Mobile: " + customer.Mobile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

        }
    }
}
