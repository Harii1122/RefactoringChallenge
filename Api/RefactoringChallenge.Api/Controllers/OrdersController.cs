using System;
using System.Collections.Generic;
using System.Linq;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefactoringChallenge.Data;
using RefactoringChallenge.Data.Context;
using RefactoringChallenge.Models;

namespace RefactoringChallenge.Api.Controllers
{
    /// <summary>
    /// Orders Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        #region Properties
       
        private readonly NorthwindDbContext _northwindDbContext;
        private readonly IMapper _mapper;

        public OrdersController(NorthwindDbContext northwindDbContext, IMapper mapper)
        {
            _northwindDbContext = northwindDbContext;
            _mapper = mapper;
        }

        #endregion

        /// <summary>
        /// Gets the list of order with specified filters.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OrderResponse>> Get(int? skip = null, int? take = null)
        {
            var query = _northwindDbContext.Orders;
            if (skip != null)
            {
                query.Skip(skip.Value);
            }
            if (take != null)
            {
                query.Take(take.Value);
            }

            if (query == null)
                return NoContent();

            var result = _mapper.From(query).ProjectToType<OrderResponse>().ToList();
            return Ok(result);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int orderId)
        {
            var result = _mapper.From(_northwindDbContext.Orders).ProjectToType<OrderResponse>().FirstOrDefault(o => o.OrderId == orderId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        /// <summary>
        /// Creates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create(OrderRequest order)
        {
            //Validate Model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Build Request
            var newOrder = new Order
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = DateTime.Now,
                RequiredDate = order.RequiredDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                OrderDetails = order.OrderDetails.Select(x => new OrderDetail()
                {
                    ProductId = x.ProductId,
                    Discount = x.Discount,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                }).ToList()
            };
            //Save to DB
            _northwindDbContext.Orders.Add(newOrder);
            _northwindDbContext.SaveChanges();

            return Created("",newOrder.Adapt<OrderResponse>());
        }


        /// <summary>
        /// Adds the products to order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="orderDetails">The order details.</param>
        /// <returns></returns>
        [HttpPost("{orderId}/Products")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddProductsToOrder([FromRoute] int orderId, IEnumerable<OrderDetailRequest> orderDetails)
        {
            //Validations
            if (orderId <= 0)
                return BadRequest();

            var order = _northwindDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                return NotFound();

            //Build Request
            var newOrderDetails = order.OrderDetails.Select(x => new OrderDetail()
            {
                ProductId = x.ProductId,
                Discount = x.Discount,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
            }).ToList();

            //Update to DB
            _northwindDbContext.OrderDetails.AddRange(newOrderDetails);
            _northwindDbContext.SaveChanges();

            return Created("",newOrderDetails.Select(od => od.Adapt<OrderDetailResponse>()));
        }

        /// <summary>
        /// Deletes the specified order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        [HttpPost("{orderId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Delete([FromRoute] int orderId)
        {
            //Validations
            if (orderId <= 0)
                return BadRequest();

            var order = _northwindDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                return NotFound();

            //Get record
            var orderDetails = _northwindDbContext.OrderDetails.Where(od => od.OrderId == orderId);

            //Delete from DB
            _northwindDbContext.OrderDetails.RemoveRange(orderDetails);
            _northwindDbContext.Orders.Remove(order);
            _northwindDbContext.SaveChanges();

            return Ok();
        }
    }
}
