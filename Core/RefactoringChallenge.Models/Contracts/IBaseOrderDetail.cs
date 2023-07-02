namespace RefactoringChallenge.Models.Contracts
{
    /// <summary>
    /// Interface for Base Order Detail
    /// </summary>
    public interface IBaseOrderDetail
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        short Quantity { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>
        /// The discount.
        /// </value>
        float Discount { get; set; }
    }
}
