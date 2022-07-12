using CharlesBank.Entities;
using System;
using System.Collections.Generic;

namespace CharlesBank.DataAccessLayer.DALContracts
{
    /// <summary>
    /// Interface that represents transaction data access layer
    /// </summary>
    public interface ITransactionsDataAccessLayer
    {
        /// <summary>
        /// Returns all existing transactions
        /// </summary>
        /// <returns>List of transactions</returns>
        List<Transaction> GetTransactions();

        /// <summary>
        /// Returns a set of transactions that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list matching transactions</returns>
        List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate);

        /// <summary>
        /// Adds a new transaction to the existing transactions list
        /// </summary>
        /// <param name="transaction">The account object to add</param>
        /// <returns>Returns true, that indicates the transaction is added successfully</returns>
        Guid AddTransaction(Transaction transaction);

        /// <summary>
        /// Deletes an existing account 
        /// </summary>
        /// <param name="accountId">AccountId to delete</param>
        /// <returns>Returns true, that indicates the account is deleted successfully</returns>
        bool DeleteTransaction(Guid accountId);
    }
}
