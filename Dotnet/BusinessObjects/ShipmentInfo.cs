using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class ShipmentInfo
    {
        public string City { get; set; }
        public string PostalAddress { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PhoneNumber { get; set; }

        public static ShipmentInfo createShipmentInfo(BaseOrder baseOrder)
        {
            return new ShipmentInfo
            {
                City = baseOrder.City,
                PostalAddress = baseOrder.PostalAddress,
                Street = baseOrder.Street,
                HouseNumber = baseOrder.HouseNumber,
                ApartmentNumber = baseOrder.ApartmentNumber,
                PhoneNumber = baseOrder.PhoneNumber
            };
        }
    }
}