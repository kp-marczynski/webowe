using System;
using System.Collections.Generic;
using Shop.BusinessObjects.Enums;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class OrderPosition
    {
        public BaseOrder BaseOrder { get; set; }
        public List<OrderEvent> OrderEvents { get; set; }

        public OrderPosition(BaseOrder baseOrder, List<OrderEvent> orderEvents)
        {
            BaseOrder = baseOrder;
            OrderEvents = orderEvents;
        }

        public string GetOrderStatus()
        {
            OrderProcessingStatus parsedEnum;
            try
            {
                parsedEnum =
                    (OrderProcessingStatus) Enum.Parse(typeof(OrderProcessingStatus), BaseOrder.OrderStatus);
            }
            catch (ArgumentException ex)
            {
                parsedEnum = OrderProcessingStatus.UnknownError;
            }

            var daysFromOrder = (DateTime.Now - BaseOrder.OrderDate).TotalDays;
            if (parsedEnum == OrderProcessingStatus.Verified && daysFromOrder > 1)
            {
                parsedEnum = OrderProcessingStatus.PaymentAccepted;
            }
            else if (parsedEnum == OrderProcessingStatus.PaymentAccepted && daysFromOrder > 2)
            {
                parsedEnum = OrderProcessingStatus.InRealization;
            }
            else if (parsedEnum == OrderProcessingStatus.InRealization && daysFromOrder > 3)
            {
                parsedEnum = OrderProcessingStatus.InShipping;
            }
            else if (parsedEnum == OrderProcessingStatus.InShipping && daysFromOrder > 4)
            {
                parsedEnum = OrderProcessingStatus.Delivered;
            }


            switch (parsedEnum)
            {
                case OrderProcessingStatus.VerificationFailed:
                    return "Zamówienie anulowane z powodu braku dostępności żadanej liczby biletów.";
                case OrderProcessingStatus.NotVerified:
                    return "Zamówienie w trakcie weryfikacji.";
                case OrderProcessingStatus.Verified:
                    return "Zamówienie oczekuje na płatność.";
                case OrderProcessingStatus.PaymentAccepted:
                    return "Płatność zaakceptowana.";
                case OrderProcessingStatus.InRealization:
                    return "Zamówienie w trakcie realizacji";
                case OrderProcessingStatus.InShipping:
                    return "Zamówienie w trakcie dostawy";
                case OrderProcessingStatus.Delivered:
                    return "Zamówienie dostarczono";
                default:
                    return "Wystąpił nieznany błąd. Skontaktuj się z administratorem w celu wyjaśnienia.";
            }
        }
    }
}