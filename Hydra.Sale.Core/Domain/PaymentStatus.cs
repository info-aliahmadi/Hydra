namespace Hydra.Sale.Core.Domain
{
    /// <summary>
    /// Represents a payment status enumeration
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Authorized
        /// </summary>
        Authorized = 1,

        /// <summary>
        /// Paid
        /// </summary>
        Paid = 2,

        /// <summary>
        /// Partially Refunded
        /// </summary>
        PartiallyRefunded = 3,

        /// <summary>
        /// Refunded
        /// </summary>
        Refunded = 4,

        /// <summary>
        /// Voided
        /// </summary>
        Voided = 5
    }
}