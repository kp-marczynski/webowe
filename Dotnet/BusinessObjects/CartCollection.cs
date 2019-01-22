using System.Collections.Generic;
using System.Linq;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class CartCollection
    {
        public List<CartPosition> BasketPositions { get; set; } = new List<CartPosition>();

        public int GetBasketCount()
        {
            var count = 0;
            foreach (var basketPosition in BasketPositions)
            {
                count += basketPosition.Quantity;
            }

            return count;
        }

        public void AddToBasket(Event Event)
        {
            AddFewToBasket(Event, 1);
        }

        public bool RemoveFromBasket(int eventId, int quantity)
        {
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == eventId);
            if (doesContainEvent)
            {
                CartPosition bp = BasketPositions.First(item => item.Event.Id == eventId);
                if (bp.Quantity > quantity)
                {
                    bp.Quantity -= quantity;
                }
                else
                {
                    BasketPositions.Remove(bp);
                }

                return true;
            }

            return false;
        }

        public bool SetQuantity(int eventId, int quantity)
        {
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == eventId);
            if (!doesContainEvent)
            {
                return false;
            }

            CartPosition bp = BasketPositions.First(item => item.Event.Id == eventId);
            bp.Quantity = quantity;
            return true;
        }

        public void AddFewToBasket(Event Event, int quantity)
        {
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == Event.Id);
            if (!doesContainEvent)
            {
                BasketPositions.Add(CartPosition.Create(Event, quantity));
            }
            else
            {
                CartPosition bp = BasketPositions.First(item => item.Event.Id == Event.Id);
                bp.Quantity += quantity;
            }
        }

        public List<string> GetEventsIdList()
        {
            var result = new List<string>();
            foreach (var basketPosition in BasketPositions)
            {
                for (var i = 0; i < basketPosition.Quantity; ++i)
                {
                    result.Add(basketPosition.Event.Id.ToString());
                }
            }

            return result;
        }

        public CartCollection GetBasketWithCheckedPositions()
        {
            var result = new CartCollection();
            foreach (var basketPosition in BasketPositions)
            {
                if (basketPosition.IsChecked && basketPosition.Quantity > 0)
                {
                    result.BasketPositions.Add(basketPosition);
                }
            }

            return result;
        }
    }
}