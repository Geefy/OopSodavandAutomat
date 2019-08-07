using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    public enum ItemName
    {
        Cola,
        Fanta
    }

    public struct Item
    {
        private ItemName name;
        private int price;

        public ItemName Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public Item(ItemName name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
