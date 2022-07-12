using CharlesBank.Entities;
using System;
using System.Collections.Generic;

namespace CharlesBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents transactions business logic
    /// </summary>
    public interface ITransactionsBusinessLogicLayer
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
        /// <param name="transaction">The transaction object to add</param>
        /// <param name="accountCode">The account to add transaction object to</param>
        /// <returns>Returns true, that indicates the transaction is added successfully</returns>
        Guid AddTransaction(Transaction transaction, long accountCode);

        /// <summary>
        /// Deletes an existing transaction 
        /// </summary>
        /// <param name="transactionId">TransactionId to delete</param>
        /// <returns>Returns true, that indicates the transaction is deleted successfully</returns>
        bool DeleteTransaction(Guid transactionId);

        /// <summary>
        /// Create transactions to transfer an amount between two accounts
        /// </summary>
        /// <param name="fromAcc"></param>
        /// <param name="toAcc"></param>
        /// <param name="transDate"></param>
        /// <param name="amount"></param>
        /// <returns>Returns true, that indicates the transactions is added successfully</returns>
        bool PerformTransferBetweenAccounts(Guid fromAcc, Guid toAcc, DateTime transDate, double amount);
    }
}
