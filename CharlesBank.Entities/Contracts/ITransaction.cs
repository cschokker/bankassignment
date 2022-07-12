using System;

namespace CharlesBank.Entities.Contracts
{
    /// <summary>
    /// Enumeration for transaction types
    /// </summary>
    public enum TransactionTypes
    {
        Debit,
        Credit,
    }

    /// <summary>
    /// Represents interface of transaction entity
    /// </summary>
    public interface ITransaction
    {
        #region < Properties >

        Guid TransactionId { get; set; }
        Guid AccountId { get; set; }
        DateTime TransactionDate { get; set; }
        double TransactionAmount { get; set; }
        TransactionTypes TransactionType { get; set; }

        #endregion
    }
}
