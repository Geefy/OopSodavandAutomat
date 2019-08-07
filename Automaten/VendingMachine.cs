using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class VendingMachine
    {
        private int maxCola;
        private int maxFanta;

        #region Properties
        
        public int MaxCola
        {
            get
            {
                return this.maxCola;
            }
            set
            {
                this.maxCola = value;
            }
        }

        public int MaxFanta
        {
            get
            {
                return this.maxFanta;
            }
            set
            {
                this.maxFanta = value;
            }
        }

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }
        #endregion

       private List<Item> items = new List<Item>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxCola"></param>
        /// <param name="maxFanta"></param>
       public VendingMachine(int maxCola, int maxFanta)
        {
            this.maxCola = maxCola;
            this.maxFanta = maxFanta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// Counts items in list
        /// <returns>nmb</returns>
        public int ItemCount(ItemName itemName)
        {
            int nmb = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (this.items[i].Name == itemName)
                {
                    nmb++;
                }
            }
                return nmb;
        }

        /// <summary>
        /// Creates item objects and adds them to the items list
        /// </summary>
        public void Refill()
        {
            for (int i = 0; i < this.MaxCola; i++)
            {
                if (this.maxCola > ItemCount(ItemName.Cola))
                {
                    this.items.Add(new Item(ItemName.Cola,20));
                }
            }
            for (int i = 0; i < this.maxFanta; i++)
            {
                if (this.maxFanta > ItemCount(ItemName.Fanta))
                {
                    this.items.Add(new Item(ItemName.Fanta,20));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// Items and costs
        /// <returns>builder</returns>
        public string BuyItem()
        {
            string builder = "";
            foreach (Item i in items)
            {
                builder += string.Format("{0}, Cost: {1} Kr. \n", i.Name, i.Price);
            }
            return builder;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// item remover
        /// <returns>builder</returns>
        public int ItemBought(int index)
        {

            if (index >= 0 && index < this.items.Count)
            {
                int price = this.items[index].Price;
                this.items.Remove(this.items[index]);

                return price;
            }
            else
                throw new Exception("The item index was not found");
            
        }

        /// <summary>
        /// Override to string, print out items in machine
        /// </summary>
        /// <returns>builder</returns>
        public override string ToString()
        {
            string builder = "";
            Dictionary<ItemName, int> dic = this.CollectAvailebleItem();
            foreach (KeyValuePair<ItemName, int> entry in dic)
            {
                builder += string.Format("{0}, Amount left: {1} \n", entry.Key, entry.Value);
                
            }

            return builder;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// Creates a dictionary and inserts a ItemName once making it unique, also icreases the value by 1 after every duplicate ItemName that is found.
        /// <returns>Returns Dictionary availbleitems</returns>
        public Dictionary<ItemName, int> CollectAvailebleItem()
        {
            Dictionary<ItemName, int> availbleitems = new Dictionary<ItemName, int>();
            foreach (Item item in this.items)
            {
                bool itemExists = false;
                foreach  (KeyValuePair<ItemName, int> entry in availbleitems)
                {
                    if (entry.Key == item.Name)
                    {
                        itemExists = true;
                    }
                }

                if (itemExists)
                {
                    availbleitems[item.Name] += 1;
                }
                else
                {
                    availbleitems.Add(item.Name, 1);
                }
            }
            return availbleitems;
        }
    }
}