using RefactoringChallenge.Models.Contracts;
namespace RefactoringChallenge.Models
{
    /// <summary>
    /// Base class for Order Detail
    /// </summary>
    /// <seealso cref="RefactoringChallenge.Models.Contracts.IBaseOrderDetail" />
    public class BaseOrderDetail : IBaseOrderDetail
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public short Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>
        /// The discount.
        /// </value>
        public float Discount { get; set; }
    }
}
