using CharlesBank.BusinessLogicLayer.BALContracts;
using CharlesBank.DataAccessLayer;
using CharlesBank.DataAccessLayer.DALContracts;
using CharlesBank.Entities;
using CharlesBank.Entities.Contracts;
using CharlesBank.Exceptions;
using System;
using System.Collections.Generic;

namespace CharlesBank.BusinessLogicLayer
{
    /// <summary>
    /// Represents account business logic
    /// </summary>
    public class AccountsBusinessLogicLayer : IAccountsBusinessLogicLayer
    {
        #region < Private Fields >

        private IAccountsDataAccessLayer _accountsDataAccessLayer;

        #endregion

        #region < Constructors >

        /// <summary>
        /// Constructor that initialises AccountsDataAccessLayer
        /// </summary>
        public AccountsBusinessLogicLayer()
        {
            _accountsDataAccessLayer = new AccountsDataAccessLayer();
        }

        #endregion

        #region < Properties >

        /// <summary>
        /// Private property that represents reference of AccountsDataAccessLayer
        /// </summary>
        public IAccountsDataAccessLayer AccountsDataAccessLayer
        {
            set => _accountsDataAccessLayer = value;
            get => _accountsDataAccessLayer;
        }

        #endregion

        #region < Methods >

        /// <summary>
        /// Returns all existing accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        public List<Account> GetAccounts()
        {
            try
            {
                // invoke DAL
                return AccountsDataAccessLayer.GetAccounts();
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns a set of accounts that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list matching accounts</returns>
        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                // invoke DAL
                return AccountsDataAccessLayer.GetAccountsByCondition(predicate);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new account to the existing accounts list
        /// </summary>
        /// <param name="account">The account object to add</param>
        /// <param name="customerCode">The customer to add account object to</param>
        /// <returns>Returns true, that indicates the account is added successfully</returns>
        public Guid AddAccount(Account account, long customerCode)
        {
            try
            {
                // Create BL object for customer
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode);
                if (matchingCustomers.Count >= 1)
                {
                    account.CustomerId = matchingCustomers[0].CustomerId;

                    // get all accounts
                    List<Account> allAccounts = AccountsDataAccessLayer.GetAccounts();
                    long maxAccNo = 0;
                    foreach (var item in allAccounts)
                    {
                        if (item.AccountCode > maxAccNo)
                        {
                            maxAccNo = item.AccountCode;
                        }
                    }

                    // generate new account no
                    if (allAccounts.Count >= 1)
                    {
                        account.AccountCode = maxAccNo + 1;
                    }
                    else
                    {
                        account.AccountCode = CharlesBank.Configuration.Settings.BaseAccountNo + 1;
                    }

                    // invoke DAL
                    return AccountsDataAccessLayer.AddAccount(account);
                }
                else
                {
                    Console.WriteLine("Customer not found");
                    return Guid.Empty;
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Updates an existing account
        /// </summary>
        /// <param name="account">Account object that contains account details to update</param>
        /// <returns>Returns true, that indicates the account is updated successfully</returns>
        public bool UpdateAccount(Account account)
        {
            try
            {
                // invoke DAL
                return AccountsDataAccessLayer.UpdateAccount(account);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing account 
        /// </summary>
        /// <param name="accountId">AccountId to delete</param>
        /// <returns>Returns true, that indicates the account is deleted successfully</returns>
        public bool DeleteAccount(Guid accountId)
        {
            try
            {
                // invoke DAL
                return AccountsDataAccessLayer.DeleteAccount(accountId);
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifies the balance of the account
        /// </summary>
        /// <param name="transaction">transaction to apply to balance</param>
        /// <returns>Returns true, that indicates the balance is updated successfully</returns>
        public bool UpdateBalance(Transaction transaction)
        {
            try
            {
                var accountList = GetAccountsByCondition(item => item.AccountId == transaction.AccountId);

                if (accountList.Count >= 1)
                {
                    var account = accountList[0];
                    if (transaction.TransactionType == TransactionTypes.Debit)
                    {
                        account.CurrentBalance = +transaction.TransactionAmount;
                    }
                    else
                    {
                        account.CurrentBalance = -transaction.TransactionAmount;
                    }
                    // invoke DAL
                    return AccountsDataAccessLayer.UpdateAccount(account);
                }
                return false;
            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        #endregion
    }
}
