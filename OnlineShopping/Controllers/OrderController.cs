using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;

namespace OnlineShopping.Web.Controllers
{
    public class OrderController(IUserShippingAddressService userShippingAddressService, IOrderService orderService) : Controller
    {
        private readonly IUserShippingAddressService _userShippingAddress = userShippingAddressService;
        private readonly IOrderService _orderService = orderService;
        public IActionResult Index()
        {
            var m = new Order
            {
                OrderDetails = new OrderDetail()
            };
            int? UserId = HttpContext.Session.GetInt32("UserId"); // Retrieve the integer ID from the session
            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
           var i = _orderService.ChangeOrder('i', m.OrderId, UserId, m.SellerId, m.OrderStatusId, m.TotalAmount ,m.PaymentMethodId,m.PaymentStatusId,m.ShippingAddress??"",m.BillingAddress??"",m.ShippingMethod??"",m.TrackingNumber??"",m.EstimatedDeliveryDate, m.DeliveryDate,m.OrderDetails.ProductId,m.OrderDetails.Quantity,m.OrderDetails.Price,m.OrderDetails.Discount).ToList().FirstOrDefault();  
            
           if(i!=null)
            {
                if(i.Code=="000")
                {
                    var j = _orderService.ReturnOrderList('s', m.OrderId, UserId, m.SellerId, m.OrderStatusId, m.TotalAmount, m.PaymentMethodId, m.PaymentStatusId, m.ShippingAddress??"", m.BillingAddress??"", m.ShippingMethod??"", m.TrackingNumber??"", m.EstimatedDeliveryDate, m.DeliveryDate, m.OrderDetails.ProductId, m.OrderDetails.Quantity, m.OrderDetails.Price, m.OrderDetails.Discount).ToList();
                    if (j != null)
                    {
                        return View(j);
                    }
                }
            }

            return View();
        }


        public IActionResult ApproveOrder()
        {
            var m = new Order
            {
                OrderDetails = new OrderDetail()
            };
            int? UserId = HttpContext.Session.GetInt32("UserId"); // Retrieve the integer ID from the session
            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
            var i = _orderService.ChangeOrder('u', m.OrderId, UserId, m.SellerId, m.OrderStatusId, m.TotalAmount, m.PaymentMethodId, m.PaymentStatusId, m.ShippingAddress??"", m.BillingAddress??"", m.ShippingMethod??"", m.TrackingNumber??"", m.EstimatedDeliveryDate, m.DeliveryDate, m.OrderDetails.ProductId, m.OrderDetails.Quantity, m.OrderDetails.Price, m.OrderDetails.Discount).ToList().FirstOrDefault();
            
            return RedirectToAction("Index");
        }
            public IActionResult Create(List<Cart> OrderList)
        {

            return View(OrderList);
        }
        [HttpPost]
        public IActionResult PaymentMethod(UserShippingAddress m) 
        {
            int? UserId = HttpContext.Session.GetInt32("UserId"); // Retrieve the integer ID from the session
            if (!UserId.HasValue)
            {
                // Handle case where ID is not in session
                ViewBag.Message = "No UserId in Session";
                return RedirectToAction("Login", "User");
            }
            var i  = _userShippingAddress.ChangeUserShippingAddress("i",m.Id, UserId, m.EmailAddress??"" ,m.PhoneNo??"" , m.ShippingAddress??"").ToList();
            return View();
        }
    }
}
