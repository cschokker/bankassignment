using CharlesBank.DataAccessLayer.DALContracts;
using CharlesBank.Entities;
using CharlesBank.Exceptions;
using System;
using System.Collections.Generic;

namespace CharlesBank.DataAccessLayer
{
    /// <summary>
    /// Represents DAL for account transactions
    /// </summary>
    public class TransactionsDataAccessLayer : ITransactionsDataAccessLayer
    {
        #region < Fields >

        private static List<Transaction> _transactions;

        #endregion

        #region < Constructors >

        static TransactionsDataAccessLayer()
        {
            _transactions = new List<Transaction>();
        }
        #endregion

        #region < Properties >

        private static List<Transaction> Transactions
        {
            set => _transactions = value;
            get => _transactions;
        }

        #endregion

        #region < Methods >

        /// <summary>
        /// Returns all existing transactions
        /// </summary>
        /// <returns>List of transactions</returns>
        public List<Transaction> GetTransactions()
        {
            try
            {
                // create a new transactions list
                List<Transaction> transactionsList = new List<Transaction>();

                // copy all transactions from the source collection into the new transactions list
                Transactions.ForEach(item => transactionsList.Add(item.Clone() as Transaction));
                return transactionsList;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns a set of transactions that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list matching transactions</returns>
        public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
        {
            try
            {
                // create a new transactions list
                List<Transaction> transactionsList = new List<Transaction>();

                // filter the collection
                List<Transaction> filteredTransactions = Transactions.FindAll(predicate);

                // copy all accounts from the source collection into the new accounts list
                filteredTransactions.ForEach(item => transactionsList.Add(item.Clone() as Transaction));
                return transactionsList;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adds a new transaction to the existing transactions list
        /// </summary>
        /// <param name="transaction">The transaction object to add</param>
        /// <returns>Returns true, that indicates the transaction is added successfully</returns>
        public Guid AddTransaction(Transaction transaction)
        {
            try
            {
                // generate new Guid
                transaction.TransactionId = Guid.NewGuid();

                // add customer
                Transactions.Add(transaction);

                return transaction.AccountId;
            }
            catch (TransactionException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing transaction 
        /// </summary>
        /// <param name="transactionId">TransactionId to delete</param>
        /// <returns>Returns true, that indicates the transaction is deleted successfully</returns>
        public bool DeleteTransaction(Guid transactionId)
        {
            try
            {
                // delete transaction by transactionId
                if (Transactions.RemoveAll(item => item.TransactionId == transactionId) > 0)
                {
                    return true; // indicates one or more transactions are deleted
                }
                else
                {
                    return false;// indicates no transaction is deleted
                }

            }
            catch (TransactionException)
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
