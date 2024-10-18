using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Web.Services.IService;
using System.Net.Mail;

namespace OnlineShopping.Web.Services.Service
{
    public class OrderService(EshopContext context) : IOrderService
    {
        private readonly EshopContext _context = context;

        public List<ResponseCode> ChangeOrder(char? flag, int? id, int? userId, int? sellerId, int? orderStatusId, decimal? totalAmount, int? paymentMethodId, int? paymentStatusId, string shippingAddress, string billingAddress, string shippingMethod, string trackingNumber, DateTime? estimatedDeliveryDate, DateTime? deliveryDate,  int? productId, int? quantity, decimal? pricePerUnit, decimal? discount)
        {// Define parameters
            var pflag = new SqlParameter("@Flag", (object)flag ?? DBNull.Value);
            var pid = new SqlParameter("@Id", (object)id ?? DBNull.Value);
            var puserId = new SqlParameter("@UserId", (object)userId ?? DBNull.Value);
            var psellerId = new SqlParameter("@SellerId", (object)sellerId ?? DBNull.Value); // Corrected name
            var porderStatusId = new SqlParameter("@OrderStatusId", (object)orderStatusId ?? DBNull.Value);
            var ptotalAmount = new SqlParameter("@TotalAmount", (object)totalAmount ?? DBNull.Value);
            var ppaymentMethodId = new SqlParameter("@PaymentMethodId", (object)paymentMethodId ?? DBNull.Value);
            var ppaymentStatusId = new SqlParameter("@PaymentStatusId", (object)paymentStatusId ?? DBNull.Value); // Corrected name
            var pshippingAddress = new SqlParameter("@ShippingAddress", (object)shippingAddress ?? DBNull.Value);
            var pbillingAddress = new SqlParameter("@BillingAddress", (object)billingAddress ?? DBNull.Value);
            var pshippingMethod = new SqlParameter("@ShippingMethod", (object)shippingMethod ?? DBNull.Value);
            var ptrackingNumber = new SqlParameter("@TrackingNumber", (object)trackingNumber ?? DBNull.Value);
            var pestimatedDeliveryDate = new SqlParameter("@EstimatedDeliveryDate", (object)estimatedDeliveryDate ?? DBNull.Value);
            var pdeliveryDate = new SqlParameter("@DeliveryDate", (object)deliveryDate ?? DBNull.Value);
            // var pcreatedDate = new SqlParameter("@CreatedDate", (object)createdDate ?? DBNull.Value); // Commented out
            // var pupdatedDate = new SqlParameter("@UpdatedDate", (object)updatedDate ?? DBNull.Value); // Commented out
            var pproductId = new SqlParameter("@ProductID", (object)productId ?? DBNull.Value);
            var pquantity = new SqlParameter("@Quantity", (object)quantity ?? DBNull.Value);
            var ppricePerUnit = new SqlParameter("@PricePerUnit", (object)pricePerUnit ?? DBNull.Value);
            var pdiscount = new SqlParameter("@Discount", (object)discount ?? DBNull.Value);

            // Execute the stored procedure
            return _context.ResponseCodes.FromSqlRaw(
                "EXEC Proc_Order @Flag, @Id, @UserId,@SellerId, @OrderStatusId, @TotalAmount, @PaymentMethodId, @PaymentStatusId, @ShippingAddress, @BillingAddress, @ShippingMethod, @TrackingNumber, @EstimatedDeliveryDate, @DeliveryDate, @ProductID, @Quantity, @PricePerUnit, @Discount",
                pflag, pid, puserId, psellerId, porderStatusId, ptotalAmount, ppaymentMethodId, ppaymentStatusId, pshippingAddress, pbillingAddress, pshippingMethod, ptrackingNumber, pestimatedDeliveryDate, pdeliveryDate, pproductId, pquantity, ppricePerUnit, pdiscount
            ).ToList();
        }

        public List<OrderDetailResult> ReturnOrderList(char? flag, int? id, int? userId, int? sellerId, int? orderStatusId, decimal? totalAmount, int? paymentMethodId, int? paymentStatusId, string shippingAddress, string billingAddress, string shippingMethod, string trackingNumber, DateTime? estimatedDeliveryDate, DateTime? deliveryDate, int? productId, int? quantity, decimal? pricePerUnit, decimal? discount)
        {
            var pflag = new SqlParameter("@Flag", (object)flag ?? DBNull.Value);
            var pid = new SqlParameter("@Id", (object)id ?? DBNull.Value);
            var puserId = new SqlParameter("@UserId", (object)userId ?? DBNull.Value);
            var psellerId = new SqlParameter("@SellerId", (object)sellerId ?? DBNull.Value); // Corrected name
            var porderStatusId = new SqlParameter("@OrderStatusId", (object)orderStatusId ?? DBNull.Value);
            var ptotalAmount = new SqlParameter("@TotalAmount", (object)totalAmount ?? DBNull.Value);
            var ppaymentMethodId = new SqlParameter("@PaymentMethodId", (object)paymentMethodId ?? DBNull.Value);
            var ppaymentStatusId = new SqlParameter("@PaymentStatusId", (object)paymentStatusId ?? DBNull.Value); // Corrected name
            var pshippingAddress = new SqlParameter("@ShippingAddress", (object)shippingAddress ?? DBNull.Value);
            var pbillingAddress = new SqlParameter("@BillingAddress", (object)billingAddress ?? DBNull.Value);
            var pshippingMethod = new SqlParameter("@ShippingMethod", (object)shippingMethod ?? DBNull.Value);
            var ptrackingNumber = new SqlParameter("@TrackingNumber", (object)trackingNumber ?? DBNull.Value);
            var pestimatedDeliveryDate = new SqlParameter("@EstimatedDeliveryDate", (object)estimatedDeliveryDate ?? DBNull.Value);
            var pdeliveryDate = new SqlParameter("@DeliveryDate", (object)deliveryDate ?? DBNull.Value);
            // var pcreatedDate = new SqlParameter("@CreatedDate", (object)createdDate ?? DBNull.Value); // Commented out
            // var pupdatedDate = new SqlParameter("@UpdatedDate", (object)updatedDate ?? DBNull.Value); // Commented out
            var pproductId = new SqlParameter("@ProductID", (object)productId ?? DBNull.Value);
            var pquantity = new SqlParameter("@Quantity", (object)quantity ?? DBNull.Value);
            var ppricePerUnit = new SqlParameter("@PricePerUnit", (object)pricePerUnit ?? DBNull.Value);
            var pdiscount = new SqlParameter("@Discount", (object)discount ?? DBNull.Value);

            // Execute the stored procedure
            return _context.OrderDetailResult.FromSqlRaw(
                "EXEC Proc_Order @Flag, @Id, @UserId,@SellerId, @OrderStatusId, @TotalAmount, @PaymentMethodId, @PaymentStatusId, @ShippingAddress, @BillingAddress, @ShippingMethod, @TrackingNumber, @EstimatedDeliveryDate, @DeliveryDate, @ProductID, @Quantity, @PricePerUnit, @Discount",
                pflag, pid, puserId, psellerId, porderStatusId, ptotalAmount, ppaymentMethodId, ppaymentStatusId, pshippingAddress, pbillingAddress, pshippingMethod, ptrackingNumber, pestimatedDeliveryDate, pdeliveryDate, pproductId, pquantity, ppricePerUnit, pdiscount
            ).ToList();
        }
    }
}






  