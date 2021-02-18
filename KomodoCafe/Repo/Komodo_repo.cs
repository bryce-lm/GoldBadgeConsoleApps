using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class Repository
    {
        private List<Menu> _orders = new List<Menu>();
        public void AddOrder(Menu order) 
        {
            _orders.Add(order);
        }

        public Menu FindOrderByID(int orderId)
        {
            foreach (Menu menuObject in _orders)
            {
                if (menuObject.ItemNumber == orderId)
                {
                    return menuObject;
                }
            }
            return null;
        }

        public bool RemoveOrder(Menu order) 
        {
            int initialCount = _orders.Count;

            _orders.Remove(order);

            if (initialCount > _orders.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> ListOrders() 
        {
            return _orders;
        }

    }
}
