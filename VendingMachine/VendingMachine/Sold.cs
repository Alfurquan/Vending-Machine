namespace VendingMachineProj
{

    public class Sold : IState
    {
        private VendingMachine vendingMachine;

        public Sold(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }
        public void Dispense()
        {
            var selectedItem = vendingMachine.GetSelectedItem();
            Console.WriteLine($"Dispensing item: {selectedItem.GetName()}");

            var items = vendingMachine.GetItems();
            vendingMachine.UpdateItemCount(selectedItem, items[selectedItem] - 1);

            vendingMachine.RemoveInsertedCoin();

            if (items.Count == 0)
            {
                Console.WriteLine("Setting state to sold out");
                vendingMachine.SetState(new SoldOut(vendingMachine));
            }
            else
            {
                Console.WriteLine("Setting state to idle");
                vendingMachine.SetState(new Idle(vendingMachine));
            }
        }

        public void InsertCoin(Coin coin)
        {
            Console.WriteLine("Item already dispensed");
        }

        public void SelectItem(string item)
        {
            Console.WriteLine("Item already dispensed");
        }
    }
}