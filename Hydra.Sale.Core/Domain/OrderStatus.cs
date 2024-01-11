namespace Hydra.Sale.Core.Domain
{
    /// <summary>
    /// Represents an order status enumeration
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Pending
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Processing
        /// </summary>
        Processing = 1,

        /// <summary>
        /// Complete
        /// </summary>
        Complete = 2,

        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled = 3
    }
}