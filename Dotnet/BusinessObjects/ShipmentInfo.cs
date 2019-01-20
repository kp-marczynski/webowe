using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class ShipmentInfo
    {
        [Required] public string FullName { get; set; }
        [Required] public string PhoneNumber { get; set; }
        [Required] public string City { get; set; }
        [Required] public string PostalAddress { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string HouseNumber { get; set; }
//        public string ApartmentNumber { get; set; }
        

        public static ShipmentInfo createShipmentInfo(BaseOrder baseOrder)
        {
            return new ShipmentInfo
            {
                City = baseOrder.City,
                PostalAddress = baseOrder.PostalAddress,
                Street = baseOrder.Street,
                HouseNumber = baseOrder.HouseNumber,
//                ApartmentNumber = baseOrder.ApartmentNumber,
                PhoneNumber = baseOrder.PhoneNumber,
                FullName = baseOrder.FullName
            };
        }
    }
}