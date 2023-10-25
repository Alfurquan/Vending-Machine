namespace VendingMachineProj
{

    public class SoldOut : IState
    {
        private VendingMachine vendingMachine;

        public SoldOut(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }

        public void InsertCoin(Coin coin)
        {
            Console.WriteLine("Vending machine does not have items left");
        }
        public void SelectItem(string item)
        {
            Console.WriteLine("Vending machine does not have items left");
        }
        public void Dispense()
        {
            Console.WriteLine("Vending machine does not have items left");
        }
    }
}