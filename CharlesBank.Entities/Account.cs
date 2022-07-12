using CharlesBank.Entities.Contracts;
using CharlesBank.Exceptions;
using System;

namespace CharlesBank.Entities
{

    /// <summary>
    /// Represents an account of a customer
    /// </summary>
    public class Account : IAccount, ICloneable
    {
        #region < Private Fields >

        private Guid _customerId;
        private Guid _accountId;
        private long _accountCode;
        private string _accountType;
        private double _currentBalance;

        #endregion

        #region < Public Properties >

        /// <summary>
        /// Guid of Customer who owns this account 
        /// </summary>
        public Guid CustomerId { get => _customerId; set => _customerId = value; }

        /// <summary>
        /// Guid of Account for Unique Identification
        /// </summary>
        public Guid AccountId { get => _accountId; set => _accountId = value; }

        /// <summary>
        /// Auto-generated code number of the account
        /// </summary>
        public long AccountCode
        {
            get => _accountCode;
            set
            {
                // account code should be positive
                if (value > 0)
                {
                    _accountCode = value;
                }
                else
                {
                    throw new AccountException("Account code should be positive only.");
                }
            }
        }

        public string AccountType { get => _accountType; set => _accountType = value; }

        /// <summary>
        /// current balance of account
        /// </summary>
        public double CurrentBalance { get => _currentBalance; set => _currentBalance = value; }

        #endregion

        #region < Methods >

        public object Clone()
        {
            return new Account()
            {
                CustomerId = this.CustomerId,
                AccountId = this.AccountId,
                AccountCode = this.AccountCode,
                AccountType = this.AccountType,
                CurrentBalance = this.CurrentBalance
            };
        }

        #endregion
    }
}
