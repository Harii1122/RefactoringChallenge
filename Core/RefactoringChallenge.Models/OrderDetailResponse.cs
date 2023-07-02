namespace RefactoringChallenge.Models
{
    /// <summary>
    /// Order Detail Response
    /// </summary>
    /// <seealso cref="RefactoringChallenge.Models.BaseOrderDetail" />
    public class OrderDetailResponse: BaseOrderDetail
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }        
    }
}