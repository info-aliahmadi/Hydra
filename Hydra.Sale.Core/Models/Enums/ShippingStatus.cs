namespace Hydra.Sale.Core.Models.Enums
{
    /// <summary>
    /// Represents the shipping status enumeration
    /// </summary>
    public enum ShippingStatus
    {
        /// <summary>
        /// Shipping not required
        /// </summary>
        ShippingNotRequired = 1,

        /// <summary>
        /// Not yet shipped
        /// </summary>
        NotYetShipped = 2,

        /// <summary>
        /// Partially shipped
        /// </summary>
        PartiallyShipped = 3,

        /// <summary>
        /// Shipped
        /// </summary>
        Shipped = 4,

        /// <summary>
        /// Delivered
        /// </summary>
        Delivered = 5
    }
}