using Shop.BusinessObjects;
using Shop.Pages.Shared;
using Shop.Services;

namespace Shop.Pages
{
    public class OrderSummaryModel: LayoutModel
    {
        public ShipmentInfo ShipmentInfo { get; set; }
        private IOrderService _orderService;
        private IBasketService _basketService;
        public OrderSummaryModel(ILayoutService layoutService, IOrderService orderService, IBasketService basketService) : base(layoutService)
        {
            _orderService = orderService;
            _basketService = basketService;
        }

        public void OnGet()
        {
            
            ShipmentInfo = _orderService.GetShipmentInfoFromSession() ?? new ShipmentInfo();
            _basketService.RemoveOrderedItemsFromCookie();
            initializeLayout();
        }

        public void OnGetSingleOrder(ShipmentInfo shipmentInfo)
        {
            initializeLayout();
            ShipmentInfo = shipmentInfo;   
        }
    }
}