using CharlesBank.Entities.Contracts;
using System;

namespace CharlesBank.Entities
{

    /// <summary>
    /// Represents transaction of an account
    /// </summary>
    public class Transaction : ITransaction, ICloneable
    {
        #region < Private Fields >

        private Guid _transactionId;
        private Guid _accountId;
        private DateTime _transactionDate;
        private double _transactionAmount;
        private TransactionTypes _transactionType;

        #endregion

        #region Constructor

        #endregion

        #region < Public Properties >

        /// <summary>
        /// Guid of this transaction
        /// </summary>
        public Guid TransactionId { get => _transactionId; set => _transactionId = value; }

        /// <summary>
        /// Guid of Account this transaction belongs to
        /// </summary>
        public Guid AccountId { get => _accountId; set => _accountId = value; }

        /// <summary>
        /// Date and time the transaction occurred
        /// </summary>
        public DateTime TransactionDate { get => _transactionDate; set => _transactionDate = value; }

        /// <summary>
        /// Value of the transaction
        /// </summary>
        public double TransactionAmount { get => _transactionAmount; set => _transactionAmount = value; }

        /// <summary>
        /// Type of transaction
        /// </summary>
        public TransactionTypes TransactionType { get => _transactionType; set => _transactionType = value; }

        #endregion

        #region < Methods >

        public object Clone()
        {
            return new Transaction
            {
                TransactionId = this.TransactionId,
                AccountId = this.AccountId,
                TransactionDate = this.TransactionDate,
                TransactionAmount = this.TransactionAmount,
                TransactionType = this.TransactionType
            };
        }

        #endregion
    }
}
