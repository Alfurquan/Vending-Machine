using System.Collections.Generic;

namespace VendingMachineProj
{
    public class Inventory
    {
        private Dictionary<Item, int> items;
        private Dictionary<string, Item> itemNames;
        public Inventory()
        {
            this.items = new Dictionary<Item, int>();
            this.itemNames = new Dictionary<string, Item>();
        }

        public void Refill(Dictionary<Item, int> items)
        {
            foreach (var item in items)
            {
                Refill(item.Key, item.Value);
            }
        }
        private void Refill(Item item, int quantity)
        {
            if (items.ContainsKey(item))
            {
                items[item] += quantity;
            }
            else
            {
                items.Add(item, quantity);
                itemNames.Add(item.GetName(), item);
            }
        }

        public Dictionary<Item, int> GetItems()
        {
            return items;
        }

        public Item? GetItemByName(string name)
        {
            return itemNames.ContainsKey(name) ? itemNames[name] : null;
        }

        public int GetItemCount(string name)
        {
            var item = itemNames[name];
            return items.ContainsKey(item) ? items[item] : 0;
        }

        public bool IsItemAvailable(string itemLabel)
        {
            var item = GetItemByName(itemLabel);
            return item != null && items.ContainsKey(item) && items[item] > 0;
        }

        public bool IsInventoryEmpty()
        {
            return items.Count == 0;
        }

        public void UpdateItemCount(Item item, int quantity)
        {
            items[item] = quantity;

            if (quantity == 0)
            {
                items.Remove(item);
            }
        }
    }
}