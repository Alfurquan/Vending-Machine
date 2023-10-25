using System.Collections.Generic;

namespace VendingMachineProj
{
    public class VendingMachine
    {

        private Inventory inventory;
        private IState currentState;
        private Item selectedItem;
        private Coin insertedCoin;


        public VendingMachine()
        {
            this.inventory = new Inventory();
            this.currentState = new SoldOut(this);
        }

        public void FillMachine(Dictionary<Item, int> items)
        {
            this.inventory.Refill(items);
            this.SetState(new Idle(this));
        }

        public void SetState(IState state)
        {
            this.currentState = state;
        }

        public IState GetState()
        {
            return currentState;
        }

        public void InsertCoin(Coin coin)
        {
            currentState.InsertCoin(coin);
        }

        public void SelectItem(string item)
        {
            currentState.SelectItem(item);
        }

        public void Dispense()
        {
            currentState.Dispense();
        }

        public bool IsMachineEmpty()
        {
            return inventory.IsInventoryEmpty();
        }

        public bool IsItemAvailable(string item)
        {
            return inventory.IsItemAvailable(item);
        }

        public Dictionary<Item, int> GetItems()
        {
            return inventory.GetItems();
        }

        public void UpdateItemCount(Item item, int quantity)
        {
            inventory.UpdateItemCount(item, quantity);
        }

        public Coin GetInsertedCoin()
        {
            return insertedCoin;
        }

        public Item GetSelectedItem()
        {
            return selectedItem;
        }

        public void SetSelectedItem(string item)
        {
            this.selectedItem = inventory.GetItemByName(item);
        }

        public void SetInsertedCoin(Coin coin)
        {
            this.insertedCoin = coin;
        }

        public void RemoveInsertedCoin()
        {
            this.insertedCoin = null;
        }

        public int GetSelectedItemCount()
        {
            return inventory.GetItemCount(selectedItem.GetName());  
        }
    }
}