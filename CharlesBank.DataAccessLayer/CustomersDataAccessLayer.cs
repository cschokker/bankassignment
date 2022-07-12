using CharlesBank.DataAccessLayer.DALContracts;
using CharlesBank.Entities;
using CharlesBank.Exceptions;
using System;
using System.Collections.Generic;

namespace CharlesBank.DataAccessLayer
{
    /// <summary>
    /// Represents DAL for bank customers
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region < Fields >

        private static List<Customer> _customers;

        #endregion

        #region < Constructors >

        static CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region < Properties >

        private static List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }

        #endregion

        #region < Methods >

        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                // create a new customers list
                List<Customer> customersList = new List<Customer>();

                // copy all customers from the source collection into the new customers list
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression with condition</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                // create a new customers list
                List<Customer> customersList = new List<Customer>();

                // filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);

                // copy all customers from the source collection into the new customers list
                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new customer to the existing list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Guid of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // generate new Guid
                customer.CustomerId = Guid.NewGuid();

                // add customer
                Customers.Add(customer);

                return customer.CustomerId;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an existing customer's details
        /// </summary>
        /// <param name="customer">Customer object with updated details</param>
        /// <returns>Indicates whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                // find existing customer by CustomerId
                Customer existingCustomer = Customers.Find(item => item.CustomerId == customer.CustomerId);

                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true; // customer is updated
                }
                else
                {
                    return false;// no customer object updated
                }

            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing customer based on CustomerId
        /// </summary>
        /// <param name="customerId">CustomerId to delete</param>
        /// <returns>Indicates whether the customer is deleted or not</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                // delete customer by customerId
                if (Customers.RemoveAll(item => item.CustomerId == customerId) > 0)
                {
                    return true; // indicates one or more customers are deleted
                }
                else
                {
                    return false;// indicates no customer is deleted
                }

            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
