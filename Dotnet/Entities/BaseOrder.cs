using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.BusinessObjects;
using Shop.BusinessObjects.Enums;

namespace Shop.Entities
{
    [Table("orders")]
    public class BaseOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [Column("user_id")] public int UserId { get; set; }
        [Required] [Column("full_name")] public string FullName { get; set; }
        [Column("phone_number")] public string PhoneNumber { get; set; }
        [Required] [Column("email")] public string Email { get; set; }
        [Required] [Column("city")] public string City { get; set; }
        [Required] [Column("postal_address")] public string PostalAddress { get; set; }
        [Required] [Column("street")] public string Street { get; set; }
        [Required] [Column("house_number")] public string HouseNumber { get; set; }
        [Required] [Column("order_status")] public string OrderStatus { get; set; }
        [Required] [Column("total_price")] public double TotalPrice { get; set; }
        [Required] [Column("shipping_cost")] public double ShippingCost { get; set; }
        [Column("order_date")] public DateTime OrderDate { get; set; } = DateTime.Now;

        public static BaseOrder CreateBaseOrder(User user, ShipmentInfo shipmentInfo,
            OrderProcessingStatus orderProcessingStatus, int? orderId, DateTime orderDate, double shipping, double total)
        {
            if (orderId == null)
            {
                return new BaseOrder
                {
                    UserId = user.Id,
                    City = shipmentInfo.City,
                    PostalAddress = shipmentInfo.PostalAddress,
                    Street = shipmentInfo.Street,
                    HouseNumber = shipmentInfo.HouseNumber,
                    PhoneNumber = shipmentInfo.PhoneNumber,
                    Email = user.Email,
                    FullName = shipmentInfo.FullName,
                    OrderStatus = orderProcessingStatus.ToString(),
                    OrderDate = orderDate,
                    ShippingCost = shipping,
                    TotalPrice = total
                };
            }

            return new BaseOrder
            {
                Id = (int) orderId,
                UserId = user.Id,
                City = shipmentInfo.City,
                PostalAddress = shipmentInfo.PostalAddress,
                Street = shipmentInfo.Street,
                HouseNumber = shipmentInfo.HouseNumber,
                PhoneNumber = shipmentInfo.PhoneNumber,
                Email = user.Email,
                FullName = shipmentInfo.FullName,
                OrderStatus = orderProcessingStatus.ToString(),
                ShippingCost = shipping,
                OrderDate = orderDate,
                TotalPrice = total
            };
        }

        public static BaseOrder CreateBaseOrder(CompleteOrder completeOrder)
        {

            return CreateBaseOrder(completeOrder.User, completeOrder.ShipmentInfo, completeOrder.OrderProcessingStatus,
                completeOrder.OrderId, completeOrder.OrderDate, completeOrder.ShippingCost, completeOrder.TotalPrice());
        }
    }
}