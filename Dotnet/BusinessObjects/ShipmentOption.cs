namespace Shop.BusinessObjects
{
    public class ShipmentOption
    {
        public string ShipmentMethod { get; set; }
        public double ShipmentPrice { get; set; }

        public ShipmentOption()
        {
        }

        public ShipmentOption(string shipmentMethod, double shipmentPrice)
        {
            ShipmentMethod = shipmentMethod;
            ShipmentPrice = shipmentPrice;
        }
    }
}