using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Entities;

namespace Shop.BusinessObjects
{
    public class BasketSet
    {
        public HashSet<BasketPosition> BasketPositions = new HashSet<BasketPosition>();

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
                BasketPosition bp = BasketPositions.First(item => item.Event.Id == EventId);
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

            BasketPosition bp = BasketPositions.First(item => item.Event.Id == EventId);
            bp.Quantity = quantity;
            return true;
        }

        public void addFewToBasket(Event Event, int quantity)
        {
            Console.WriteLine("Addfewtobasket");
            bool doesContainEvent = BasketPositions.Any(item => item.Event.Id == Event.Id);
            if (!doesContainEvent)
            {
                BasketPositions.Add(new BasketPosition(Event, quantity));
            }
            else
            {
                BasketPosition bp = BasketPositions.First(item => item.Event.Id == Event.Id);
                bp.Quantity += quantity;
            }
        }
    }
}