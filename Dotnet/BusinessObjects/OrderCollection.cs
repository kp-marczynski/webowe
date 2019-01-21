using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class OrderCollection
    {
        public List<OrderPosition> BasketPositions { get; set; } = new List<OrderPosition>();

        public int GetBasketCount()
        {
            var count = 0;
            foreach (var basketPosition in BasketPositions)
            {
                count += basketPosition.Quantity;
            }

            return count;
        }

        public void addToBasket(Event Event)
        {
            addFewToBasket(Event, 1);
        }

        public bool removeFromBasket(int EventId, int Quantity)
        {
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == EventId);
            if (doesContainEvent)
            {
                OrderPosition bp = BasketPositions.First(item => item.Event.Id == EventId);
                if (bp.Quantity > Quantity)
                {
                    bp.Quantity -= Quantity;
                }
                else
                {
                    BasketPositions.Remove(bp);
                }

                return true;
            }

            return false;
        }

        public bool setQuantity(int EventId, int quantity)
        {
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == EventId);
            if (!doesContainEvent)
            {
                return false;
            }

            OrderPosition bp = BasketPositions.First(item => item.Event.Id == EventId);
            bp.Quantity = quantity;
            return true;
        }

        public void addFewToBasket(Event Event, int quantity)
        {
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == Event.Id);
            if (!doesContainEvent)
            {
                BasketPositions.Add(OrderPosition.Create(Event, quantity));
            }
            else
            {
                OrderPosition bp = BasketPositions.First(item => item.Event.Id == Event.Id);
                bp.Quantity += quantity;
//                Console.WriteLine(bp.Event.Name +": " +bp.Quantity);
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

        public OrderCollection GetBasketWithCheckedPositions()
        {
            var result = new OrderCollection();
            foreach (var basketPosition in BasketPositions)
            {
                if (basketPosition.isChecked && basketPosition.Quantity > 0)
                {
                    result.BasketPositions.Add(basketPosition);
                }
            }

            return result;
        }
    }
}