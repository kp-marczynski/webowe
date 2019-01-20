using System.ComponentModel.DataAnnotations.Schema;
using Shop.BusinessObjects;

namespace Shop.Entities
{
    [Table("orders")]
    public class BaseOrder
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string PostalAddress { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
//        public string ApartmentNumber { get; set; }

        public static BaseOrder createBaseOrder(User user, ShipmentInfo shipmentInfo)
        {
            return new BaseOrder
            {
                UserId = user.Id,
                City = shipmentInfo.City,
                PostalAddress = shipmentInfo.PostalAddress,
                Street = shipmentInfo.Street,
                HouseNumber = shipmentInfo.HouseNumber,
//                ApartmentNumber = shipmentInfo.ApartmentNumber,
                PhoneNumber = shipmentInfo.PhoneNumber,
                FullName = shipmentInfo.FullName
            };
        }

        public static BaseOrder createBaseOrder(CompleteOrder completeOrder)
        {
            return createBaseOrder(completeOrder.user, completeOrder.shipmentInfo);
        }
    }
}