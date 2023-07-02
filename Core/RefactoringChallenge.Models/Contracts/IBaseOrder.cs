using System;
using System.Collections.Generic;

namespace RefactoringChallenge.Models.Contracts
{
    /// <summary>
    /// Interface for IBaseOrder
    /// </summary>
    public interface IBaseOrder
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
         string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
         int? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the required date.
        /// </summary>
        /// <value>
        /// The required date.
        /// </value>
         DateTime? RequiredDate { get; set; }

        /// <summary>
        /// Gets or sets the ship via.
        /// </summary>
        /// <value>
        /// The ship via.
        /// </value>
         int? ShipVia { get; set; }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>
        /// The freight.
        /// </value>
         decimal? Freight { get; set; }

        /// <summary>
        /// Gets or sets the name of the ship.
        /// </summary>
        /// <value>
        /// The name of the ship.
        /// </value>
         string ShipName { get; set; }

        /// <summary>
        /// Gets or sets the ship address.
        /// </summary>
        /// <value>
        /// The ship address.
        /// </value>
         string ShipAddress { get; set; }
        /// <summary>
        /// Gets or sets the ship city.
        /// </summary>
        /// <value>
        /// The ship city.
        /// </value>
         string ShipCity { get; set; }
        /// <summary>
        /// Gets or sets the ship region.
        /// </summary>
        /// <value>
        /// The ship region.
        /// </value>
         string ShipRegion { get; set; }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        /// <value>
        /// The ship postal code.
        /// </value>
         string ShipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the ship country.
        /// </summary>
        /// <value>
        /// The ship country.
        /// </value>
         string ShipCountry { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>
        /// The order details.
        /// </value>
         IEnumerable<OrderDetailRequest> OrderDetails { get; set; }
    }
}
