using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LoginApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Controllers
{
    public class OrderController : Controller
    {

        private readonly AuthenticationContext _context;

        public OrderController(AuthenticationContext context)
        {
            _context = context;

        }


        public Object GetOrders()
        {

            var result = (from a in _context.Orders
                          join b in _context.Customers on a.CustomerID equals b.CustomerID

                          select new
                          {
                              a.OrderID,
                              a.OrderNo,
                              Customer = b.Name,
                              a.PMethod,
                              a.GTotal
                          }).ToList();

            return result;


        }

        [ResponseType(typeof(OrderModel))]
        public IActionResult GetOrder(long id)
        {
            var order = (from a in _context.Orders
                         where a.OrderID == id

                         select new
                         {
                             a.OrderID,
                             a.OrderNo,
                             a.CustomerID,
                             a.PMethod,
                             a.GTotal,
                             DeletedOrderItemIDs = ""
                         }).FirstOrDefault();

            var orderDetails = (from a in _context.OrderItems
                                join b in _context.Items on a.ItemID equals b.ItemID
                                where a.OrderID == id

                                select new
                                {
                                    a.OrderID,
                                    a.OrderItemID,
                                    a.ItemID,
                                    ItemName = b.Name,
                                    b.Price,
                                    a.Quantity,
                                    Total = a.Quantity * b.Price
                                }).ToList();

            return Ok( new { order, orderDetails });


        }

        [ResponseType(typeof(OrderModel))]
        public IActionResult PostOrder(OrderModel order)
        {
            try
            {
                //Order table
                if (order.OrderID == 0)
                    _context.Orders.Add(order);
                else
                    _context.Entry(order).State = EntityState.Modified;

                //OrderItems table
                foreach (var item in order.OrderItems)
                {
                    if (item.OrderItemID == 0)
                        _context.OrderItems.Add(item);
                    else
                        _context.Entry(item).State = EntityState.Modified;
                }

                //Delete for OrderItems
                foreach (var id in order.DeletedOrderItemIDs.Split(',').Where(x => x != ""))
                {
                    OrderItemsModel x = _context.OrderItems.Find(Convert.ToInt64(id));
                    _context.OrderItems.Remove(x);
                }


                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/Order/5
        [ResponseType(typeof(OrderModel))]
        public IActionResult DeleteOrder(long id)
        {
            OrderModel order = _context.Orders.Include(y => y.OrderItems)
                .SingleOrDefault(x => x.OrderID == id);

            foreach (var item in order.OrderItems.ToList())
            {
                _context.OrderItems.Remove(item);
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Count(e => e.OrderID == id) > 0;
        }
    }
}