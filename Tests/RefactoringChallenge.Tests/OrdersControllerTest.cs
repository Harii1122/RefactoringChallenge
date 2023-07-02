using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using RefactoringChallenge.Api.Controllers;
using RefactoringChallenge.Data;
using RefactoringChallenge.Data.Context;
using RefactoringChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RefactoringChallenge.Tests
{
    [TestFixture]
    public class OrdersControllerTest
    {
        private  IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mapper = TestHelpers.GetMapper();
        }

        #region Get Method

        [Test]
        public void GivenNoParameters_WhenGET_ReturnNullResponse()
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Get();

            //Assert
            Assert.IsInstanceOf<ActionResult<IEnumerable<OrderResponse>>>(actionResult);
            Assert.True(actionResult.Result is NoContentResult);
        }


        [Test]
        public void GivenNoParameters_WhenGET_ReturnSuccessResponse()
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Get();

            //Assert
            Assert.IsInstanceOf<ActionResult<IEnumerable<OrderResponse>>>(actionResult);
            Assert.True(actionResult.Result is OkObjectResult);
        }

        [TestCase(1,1)]
        [TestCase(1)]
        public void GivenParameters_WhenGET_ReturnSuccessResponse(int? skip = null, int? take = null)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Get(skip,take);

            //Assert
            Assert.IsInstanceOf<ActionResult<IEnumerable<OrderResponse>>>(actionResult);
            Assert.True(actionResult.Result is OkObjectResult);
        }

      
        #endregion

        #region GetById

        [TestCase(1003)]
        public void GivenNotAValidId_WhenGetById_ReturnNotFoundResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.GetById(orderId);

            //Assert            
            Assert.True(actionResult is NotFoundResult);
        }


        [TestCase(1001)]
        [TestCase(1002)]
        public void GivenAValidId_WhenGetById_ReturnSuccessResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.GetById(orderId);

            //Assert            
            Assert.True(actionResult is OkObjectResult);
        }

        
       

        #endregion


        #region Create a Order

        [Test]
        public void GivenRequest_WhenCreateOrder_ReturnSuccessResponse()
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            var orderRequest = new OrderRequest {  CustomerId = "1098", EmployeeId = 120, RequiredDate = DateTime.Now, ShipVia = 108, ShipName = "Fedx", ShipAddress = "1 Street", ShipPostalCode = "FY1 9XQ", ShipCountry = "UK", OrderDetails = new List<OrderDetailRequest> { new OrderDetailRequest { Discount = 10, Quantity = 1, UnitPrice = 1098 } } };

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Create(orderRequest);

            //Assert            
            Assert.True(actionResult is CreatedResult);
        }

        #endregion


        #region Add a product to Order

       

        [TestCase(0)]
        [TestCase(-1)]
        public void GivenInValidOrderIds_WhenAddProductsToOrder_ReturnBadResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            employeeContextMock.Setup(x => x.OrderDetails).ReturnsDbSet(TestHelpers.GetFakeOrderDetailsList());
            var orderDetailRequest = new List<OrderDetailRequest> { new OrderDetailRequest { Discount = 10, Quantity = 1, UnitPrice = 1098 } };

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.AddProductsToOrder(orderId, orderDetailRequest);

            //Assert            
            Assert.True(actionResult is BadRequestResult);
        }


        [TestCase(1003)]
        [TestCase(2000)]
        public void GivenNotExistsOrderIds_WhenAddProductsToOrder_ReturnNotFoundResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            employeeContextMock.Setup(x => x.OrderDetails).ReturnsDbSet(TestHelpers.GetFakeOrderDetailsList());
            var orderDetailRequest = new List<OrderDetailRequest> { new OrderDetailRequest { Discount = 10, Quantity = 1, UnitPrice = 1098 } };

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.AddProductsToOrder(orderId, orderDetailRequest);

            //Assert            
            Assert.True(actionResult is NotFoundResult);
        }

        [TestCase(1001)]
        [TestCase(1002)]
        public void GivenData_WhenAddProductsToOrder_ReturnSuccessResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            employeeContextMock.Setup(x => x.OrderDetails).ReturnsDbSet(TestHelpers.GetFakeOrderDetailsList());
            var orderDetailRequest = new List<OrderDetailRequest> { new OrderDetailRequest { Discount = 10, Quantity = 1, UnitPrice = 1098 } };

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.AddProductsToOrder(orderId, orderDetailRequest);

            //Assert            
            Assert.True(actionResult is CreatedResult);
        }

        #endregion


        #region Delete

        [TestCase(0)]
        [TestCase(-1)]
        public void GivenInValidOrderIds_WhenDeleteOrder_ReturnBadResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            employeeContextMock.Setup(x => x.OrderDetails).ReturnsDbSet(TestHelpers.GetFakeOrderDetailsList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Delete(orderId);

            //Assert            
            Assert.True(actionResult is BadRequestResult);
        }


        [TestCase(1003)]
        [TestCase(2000)]
        public void GivenNotExistsOrderIds_WhenDeleteOrder_ReturnNotFoundResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            employeeContextMock.Setup(x => x.OrderDetails).ReturnsDbSet(TestHelpers.GetFakeOrderDetailsList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Delete(orderId);

            //Assert            
            Assert.True(actionResult is NotFoundResult);
        }

        [TestCase(1001)]
        [TestCase(1002)]
        public void GivenData_WhenDeleteOrder_ReturnSuccessResponse(int orderId)
        {
            // Arrange
            var employeeContextMock = new Mock<NorthwindDbContext>();
            employeeContextMock.Setup(x => x.Orders).ReturnsDbSet(TestHelpers.GetFakeOrderList());
            employeeContextMock.Setup(x => x.OrderDetails).ReturnsDbSet(TestHelpers.GetFakeOrderDetailsList());

            //Act
            var ordersController = new OrdersController(employeeContextMock.Object, _mapper);
            var actionResult = ordersController.Delete(orderId);

            //Assert            
            Assert.True(actionResult is OkResult);
        }

        #endregion

    }
}