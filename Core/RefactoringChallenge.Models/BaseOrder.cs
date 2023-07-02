using RefactoringChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RefactoringChallenge.Models
{
    /// <summary>
    /// Base class for Order
    /// </summary>
    /// <seealso cref="RefactoringChallenge.Models.Contracts.IBaseOrder" />
    public class BaseOrder: IBaseOrder
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [Required]        
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        [Required]        
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the required date.
        /// </summary>
        /// <value>
        /// The required date.
        /// </value>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// Gets or sets the ship via.
        /// </summary>
        /// <value>
        /// The ship via.
        /// </value>
        public int? ShipVia { get; set; }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>
        /// The freight.
        /// </value>
        public decimal? Freight { get; set; }

        /// <summary>
        /// Gets or sets the name of the ship.
        /// </summary>
        /// <value>
        /// The name of the ship.
        /// </value>
        [Required]
        public string ShipName { get; set; }

        /// <summary>
        /// Gets or sets the ship address.
        /// </summary>
        /// <value>
        /// The ship address.
        /// </value>
        public string ShipAddress { get; set; }
        /// <summary>
        /// Gets or sets the ship city.
        /// </summary>
        /// <value>
        /// The ship city.
        /// </value>
        public string ShipCity { get; set; }
        /// <summary>
        /// Gets or sets the ship region.
        /// </summary>
        /// <value>
        /// The ship region.
        /// </value>
        public string ShipRegion { get; set; }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        /// <value>
        /// The ship postal code.
        /// </value>
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the ship country.
        /// </summary>
        /// <value>
        /// The ship country.
        /// </value>
        public string ShipCountry { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>
        /// The order details.
        /// </value>
        public IEnumerable<OrderDetailRequest> OrderDetails { get; set; }
        
    }
}
