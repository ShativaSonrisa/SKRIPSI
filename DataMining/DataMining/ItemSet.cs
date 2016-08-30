using System.Collections.Generic;
using System.Linq;

namespace DataMining
{
    public class ItemSet
    {
        public ItemSet()
        {
            Items = new List<Item>();
            SupportCount = -1;
        }

        public List<Item> Items { get; set; }

        public void AddItem(Item item)
        {
            Items.Add(item);
            SupportCount = -1;
        }

        private int SupportCount { get; set; }

        public string Nobill { get; private set; }

        public int Coda { get; set; }

        //constructor
        public ItemSet(string nobill, List<Item> items)
        {
            Nobill = nobill;
            Nobill = nobill;
            Items = items;
        }

        public Item GetLastItem()
        {
            return Items.Last();
        }

        public ItemSet Clone()
        {
            var itemSet = new ItemSet { SupportCount = SupportCount };
            foreach (var anItem in Items)
            {
                itemSet.AddItem(anItem.Clone());
            }
            return itemSet;
        }
    }
}
