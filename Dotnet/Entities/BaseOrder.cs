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
        [Required] [Column("phone_number")] public string PhoneNumber { get; set; }
        [Required] [Column("city")] public string City { get; set; }
        [Required] [Column("postal_address")] public string PostalAddress { get; set; }
        [Required] [Column("street")] public string Street { get; set; }
        [Required] [Column("house_number")] public string HouseNumber { get; set; }

        [Required] [Column("order_status")] public string OrderStatus { get; set; }

//        [Column(TypeName = "Date")] public DateTime ReportDate { get; set; }
        [Column("order_date")] public DateTime OrderDate { get; set; } = DateTime.Now;

        public static BaseOrder createBaseOrder(User user, ShipmentInfo shipmentInfo,
            OrderProcessingState orderProcessingState, int? orderId, DateTime? orderDate)
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
                    FullName = shipmentInfo.FullName,
                    OrderStatus = orderProcessingState.ToString(),
                    OrderDate = orderDate ?? DateTime.Now
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
                FullName = shipmentInfo.FullName,
                OrderStatus = orderProcessingState.ToString()
            };
        }

        public static BaseOrder createBaseOrder(CompleteOrder completeOrder)
        {
            return createBaseOrder(completeOrder.user, completeOrder.shipmentInfo, completeOrder.OrderProcessingState,
                completeOrder.orderId, completeOrder.OrderDate);
        }
    }
}