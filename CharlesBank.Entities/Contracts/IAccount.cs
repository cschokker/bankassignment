using System;

namespace CharlesBank.Entities.Contracts
{
    /// <summary>
    /// Represents interface of account entity
    /// </summary>
    public interface IAccount
    {
        #region < Properties >

        Guid CustomerId { get; set; }
        Guid AccountId { get; set; }
        long AccountCode { get; set; }
        string AccountType { get; set; }
        double CurrentBalance { get; set; }

        #endregion

    }
}
