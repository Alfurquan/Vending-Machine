using System;

namespace VendingMachineProj
{
    public class Idle : IState
    {

        private VendingMachine vendingMachine;

        public Idle(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }

        public void SelectItem(string item)
        {
            Console.WriteLine($"Selecting item: {item}");
            if (vendingMachine.IsItemAvailable(item))
            {
                vendingMachine.SetSelectedItem(item);
                vendingMachine.SetState(new Processing(vendingMachine));
            }
            else
            {
                Console.WriteLine("Item is not available");
            }
        }

        public void InsertCoin(Coin coin)
        {
            Console.WriteLine("Please select an item first");
        }

        public void Dispense()
        {
            Console.WriteLine("Please select an item first");
        }
    }
}