namespace VendingMachineProj
{

    public class Processing : IState
    {
        private VendingMachine vendingMachine;

        public Processing(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
        }
        public void InsertCoin(Coin coin)
        {
            Console.WriteLine($"Inserting coin: {coin.GetValue()}");
            if (vendingMachine.GetInsertedCoin() != null)
            {
                Console.WriteLine("Coin already inserted");
                return;
            }
            var selectedItem = vendingMachine.GetSelectedItem();

            if (coin.GetValue() < selectedItem.GetPrice())
            {
                Console.WriteLine("Not enough money inserted");
                return;
            }

            vendingMachine.SetInsertedCoin(coin);
            vendingMachine.SetState(new Sold(vendingMachine));
        }

        public void SelectItem(string item)
        {
            Console.WriteLine("Item already selected");
        }

        public void Dispense()
        {
            Console.WriteLine("Insert coin first");
        }
    }
}