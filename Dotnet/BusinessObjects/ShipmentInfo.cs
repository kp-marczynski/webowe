using System.ComponentModel.DataAnnotations;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class ShipmentInfo
    {
        [Required] public string FullName { get; set; }
        [Required] public string PhoneNumber { get; set; }
        [Required] public string City { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{3}$")]
        public string PostalAddress { get; set; }

        [Required] public string Street { get; set; }
        [Required] public string HouseNumber { get; set; }
        
        public string PaymentMethod { get; set; }
        
        public ShipmentOption ShipmentOption { get; set; }

        public static ShipmentInfo CreateShipmentInfo(BaseOrder baseOrder)
        {
            return new ShipmentInfo
            {
                FullName = baseOrder.FullName,
                PhoneNumber = baseOrder.PhoneNumber,
                City = baseOrder.City,
                PostalAddress = baseOrder.PostalAddress,
                Street = baseOrder.Street,
                HouseNumber = baseOrder.HouseNumber
            };
        }
    }
}