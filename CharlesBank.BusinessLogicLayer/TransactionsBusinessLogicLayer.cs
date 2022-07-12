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
    /// Represents transaction business logic
    /// </summary>
    public class TransactionsBusinessLogicLayer : ITransactionsBusinessLogicLayer
    {
        #region < Private Fields >

        private ITransactionsDataAccessLayer _transactionsDataAccessLayer;

        #endregion

        #region < Constructors >

        /// <summary>
        /// Constructor that initialises TransactionsDataAccessLayer
        /// </summary>
        public TransactionsBusinessLogicLayer()
        {
            _transactionsDataAccessLayer = new TransactionsDataAccessLayer();
        }

        #endregion

        #region < Properties >

        /// <summary>
        /// Private property that represents reference of TransactionsDataAccessLayer
        /// </summary>
        public ITransactionsDataAccessLayer TransactionsDataAccessLayer
        {
            set => _transactionsDataAccessLayer = value;
            get => _transactionsDataAccessLayer;
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
                // invoke DAL
                return TransactionsDataAccessLayer.GetTransactions();
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
                // invoke DAL
                return TransactionsDataAccessLayer.GetTransactionsByCondition(predicate);
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
        /// <param name="accountCode">The account to add transaction object to</param>
        /// <returns>Returns true, that indicates the transaction is added successfully</returns>
        public Guid AddTransaction(Transaction transaction, long accountCode)
        {
            try
            {
                // Create BL object for account
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == accountCode);
                if (matchingAccounts.Count >= 1)
                {
                    transaction.AccountId = matchingAccounts[0].AccountId;

                    // invoke DAL
                    var trans = TransactionsDataAccessLayer.AddTransaction(transaction);
                    if (trans != Guid.Empty)
                    {
                        accountsBusinessLogicLayer.UpdateBalance(transaction);
                    }
                    return trans;
                }
                else
                {
                    Console.WriteLine("Account not found");
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
        /// Deletes an existing transaction 
        /// </summary>
        /// <param name="transactionId">TransactionId to delete</param>
        /// <returns>Returns true, that indicates the transaction is deleted successfully</returns>
        public bool DeleteTransaction(Guid transactionId)
        {
            try
            {
                // invoke DAL
                return TransactionsDataAccessLayer.DeleteTransaction(transactionId);
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
        /// Create transactions to transfer an amount between two accounts
        /// </summary>
        /// <param name="fromAcc"></param>
        /// <param name="toAcc"></param>
        /// <param name="transDate"></param>
        /// <param name="amount"></param>
        /// <returns>Returns true, that indicates the transactions is added successfully</returns>
        public bool PerformTransferBetweenAccounts(Guid fromAcc, Guid toAcc, DateTime transDate, double amount)
        {
            try
            {
                var fromTransaction = new Transaction
                {
                    AccountId = fromAcc,
                    TransactionDate = transDate,
                    TransactionAmount = amount,
                    TransactionType = TransactionTypes.Credit
                };

                var toTransaction = new Transaction
                {
                    AccountId = toAcc,
                    TransactionDate = transDate,
                    TransactionAmount = amount,
                    TransactionType = TransactionTypes.Debit
                };

                // invoke DAL
                return TransactionsDataAccessLayer.AddTransaction(fromTransaction) != Guid.Empty & TransactionsDataAccessLayer.AddTransaction(toTransaction) != Guid.Empty;
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
