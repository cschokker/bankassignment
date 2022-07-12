using CharlesBank.BusinessLogicLayer.BALContracts;
using CharlesBank.DataAccessLayer;
using CharlesBank.DataAccessLayer.DALContracts;
using CharlesBank.Entities;
using CharlesBank.Exceptions;
using System;
using System.Collections.Generic;

namespace CharlesBank.BusinessLogicLayer
{
    /// <summary>
    /// Represents customer business logic
    /// </summary>
    public class CustomersBusinessLogicLayer : ICustomersBusinessLogicLayer
    {
        #region < Private Fields >

        private ICustomersDataAccessLayer _customersDataAccessLayer;

        #endregion

        #region < Constructors >

        /// <summary>
        /// Constructor that initialises CustomersDataAccessLayer
        /// </summary>
        public CustomersBusinessLogicLayer()
        {
            _customersDataAccessLayer = new CustomersDataAccessLayer();
        }

        #endregion

        #region < Properties >

        /// <summary>
        /// Private property that represents reference of CustomersDataAccessLayer
        /// </summary>
        public ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set => _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;
        }

        #endregion

        #region < Methods >

        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                // invoke DAL
                return CustomersDataAccessLayer.GetCustomers();
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
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                // invoke DAL
                return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
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
        /// Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Returns true, that indicates the customer is added successfully</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                // get all customers
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustNo = 0;
                foreach (var item in allCustomers)
                {
                    if (item.CustomerCode > maxCustNo)
                    {
                        maxCustNo = item.CustomerCode;
                    }
                }

                // generate new customer no
                if (allCustomers.Count >= 1)
                {
                    customer.CustomerCode = maxCustNo + 1;
                }
                else
                {
                    customer.CustomerCode = CharlesBank.Configuration.Settings.BaseCustomerNo + 1;
                }

                // invoke DAL
                return CustomersDataAccessLayer.AddCustomer(customer);
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
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update</param>
        /// <returns>Returns true, that indicates the customer is updated successfully</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                // invoke DAL
                return CustomersDataAccessLayer.UpdateCustomer(customer);
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
        /// Deletes an existing customer 
        /// </summary>
        /// <param name="customerId">CustomerId to delete</param>
        /// <returns>Returns true, that indicates the customer is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                // invoke DAL
                return CustomersDataAccessLayer.DeleteCustomer(customerId);
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
