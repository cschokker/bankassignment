using CharlesBank.DataAccessLayer.DALContracts;
using CharlesBank.Entities;
using CharlesBank.Exceptions;
using System;
using System.Collections.Generic;

namespace CharlesBank.DataAccessLayer
{
    /// <summary>
    /// Represents DAL for bank accounts
    /// </summary>
    public class AccountsDataAccessLayer : IAccountsDataAccessLayer
    {
        #region < Fields >

        private static List<Account> _accounts;

        #endregion

        #region < Constructors >

        static AccountsDataAccessLayer()
        {
            _accounts = new List<Account>();
        }
        #endregion

        #region < Properties >

        private static List<Account> Accounts
        {
            set => _accounts = value;
            get => _accounts;
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
                // create a new Accounts list
                List<Account> accountsList = new List<Account>();

                // copy all accounts from the source collection into the new accounts list
                Accounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
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
                // create a new Accounts list
                List<Account> accountsList = new List<Account>();

                // filter the collection
                List<Account> filteredAccounts = Accounts.FindAll(predicate);

                // copy all accounts from the source collection into the new accounts list
                filteredAccounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
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
        /// <returns>Returns true, that indicates the account is added successfully</returns>
        public Guid AddAccount(Account account)
        {
            try
            {
                // generate new Guid
                account.AccountId = Guid.NewGuid();

                // add customer
                Accounts.Add(account);

                return account.AccountId;
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
                // find existing account by AccountId
                Account existingAccount = Accounts.Find(item => item.AccountId == account.AccountId);

                if (existingAccount != null)
                {
                    existingAccount.AccountId = account.AccountId;
                    existingAccount.AccountType = account.AccountType;
                    existingAccount.CustomerId = account.CustomerId;
                    existingAccount.CurrentBalance = account.CurrentBalance;

                    return true; // account is updated
                }
                else
                {
                    return false;// no account object updated
                }

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
                // delete account by accountId
                if (Accounts.RemoveAll(item => item.AccountId == accountId) > 0)
                {
                    return true; // indicates one or more accounts are deleted
                }
                else
                {
                    return false;// indicates no account is deleted
                }

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

        #endregion

    }
}
