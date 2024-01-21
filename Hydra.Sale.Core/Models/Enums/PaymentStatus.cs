namespace Hydra.Sale.Core.Models.Enums
{
    /// <summary>
    /// Represents a payment status enumeration
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Authorized
        /// </summary>
        Authorized = 2,

        /// <summary>
        /// Paid
        /// </summary>
        Paid = 3,

        /// <summary>
        /// Partially Refunded
        /// </summary>
        PartiallyRefunded = 4,

        /// <summary>
        /// Refunded
        /// </summary>
        Refunded = 5,

        /// <summary>
        /// Voided
        /// </summary>
        Voided = 6
    }
}