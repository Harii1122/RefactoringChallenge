using Mapster;
using MapsterMapper;
using RefactoringChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringChallenge.Tests
{
    public static class TestHelpers
    {
        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <returns></returns>
        public static Mapper GetMapper()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(IMapper).Assembly);
            return new Mapper(config);
        }

        /// <summary>
        /// Gets the fake order list.
        /// </summary>
        /// <returns></returns>
        public static List<Order> GetFakeOrderList()
        {
            return new List<Order>()
            {
                new Order{ OrderId=1001, CustomerId="1098" ,EmployeeId=120, RequiredDate=DateTime.Now, ShipVia=108, ShipName="Fedx", ShipAddress="1 Street", ShipPostalCode="FY1 9XQ", ShipCountry="UK", OrderDetails=new List<OrderDetail>{ new OrderDetail { Discount = 10, Quantity = 1, UnitPrice = 1098 } }   },
                new Order{ OrderId=1002, CustomerId="1099", EmployeeId=121, RequiredDate=DateTime.Now, ShipVia=107, ShipName="Fedx", ShipAddress="2 Street", ShipPostalCode="FY1 9XQ", ShipCountry="UK", OrderDetails=new List<OrderDetail>{ new OrderDetail { Discount = 10, Quantity = 1, UnitPrice = 1098 } }   },
            };
        }

        public static List<OrderDetail> GetFakeOrderDetailsList()
        {
            return new List<OrderDetail>()
            {
                 new OrderDetail { Discount = 10, Quantity = 1, UnitPrice = 1098 } ,
                new OrderDetail { Discount = 10, Quantity = 1, UnitPrice = 1098 }
            };
        }

    }
}
