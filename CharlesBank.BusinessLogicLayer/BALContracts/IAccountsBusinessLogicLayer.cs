using CharlesBank.Entities;
using System;
using System.Collections.Generic;

namespace CharlesBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents accounts business logic
    /// </summary>
    public interface IAccountsBusinessLogicLayer
    {
        /// <summary>
        /// Returns all existing accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        List<Account> GetAccounts();

        /// <summary>
        /// Returns a set of accounts that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list matching accounts</returns>
        List<Account> GetAccountsByCondition(Predicate<Account> predicate);

        /// <summary>
        /// Adds a new account to the existing accounts list
        /// </summary>
        /// <param name="account">The account object to add</param>
        /// <param name="customerCode">The customer to add account object to</param>
        /// <returns>Returns true, that indicates the account is added successfully</returns>
        Guid AddAccount(Account account, long customerCode);

        /// <summary>
        /// Updates an existing account
        /// </summary>
        /// <param name="account">Account object that contains account details to update</param>
        /// <returns>Returns true, that indicates the account is updated successfully</returns>
        bool UpdateAccount(Account account);

        /// <summary>
        /// Deletes an existing account 
        /// </summary>
        /// <param name="accountId">AccountId to delete</param>
        /// <returns>Returns true, that indicates the account is deleted successfully</returns>
        bool DeleteAccount(Guid accountId);

        /// <summary>
        /// Modifies the balance of the account
        /// </summary>
        /// <param name="transaction">transaction to apply to balance</param>
        /// <returns>Returns true, that indicates the balance is updated successfully</returns>
        bool UpdateBalance(Transaction transaction);
    }
}
