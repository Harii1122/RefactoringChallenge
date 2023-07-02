using System;

namespace RefactoringChallenge.Models
{
    /// <summary>
    /// Order Response Class
    /// </summary>
    /// <seealso cref="RefactoringChallenge.Models.BaseOrder" />
    public class OrderResponse : BaseOrder
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>
        /// The order date.
        /// </value>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the shipped date.
        /// </summary>
        /// <value>
        /// The shipped date.
        /// </value>
        public DateTime? ShippedDate { get; set; }
    }
}