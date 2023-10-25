namespace VendingMachineProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDriver();
        }

        static void TestDriver()
        {
            var vendingMachine = new VendingMachine();
            PopulateInventory(vendingMachine);
            vendingMachine.SelectItem("Pepsi");
            vendingMachine.InsertCoin(new Coin(35));
            vendingMachine.Dispense();
            vendingMachine.SelectItem("Pepsi");
            vendingMachine.InsertCoin(new Coin(35));
            vendingMachine.Dispense();
            vendingMachine.SelectItem("Pepsi");
            vendingMachine.InsertCoin(new Coin(25));
            vendingMachine.Dispense();
            vendingMachine.SelectItem("Coke");
            vendingMachine.InsertCoin(new Coin(25));
            vendingMachine.Dispense();
            vendingMachine.SelectItem("Soda");
            vendingMachine.InsertCoin(new Coin(45));
            vendingMachine.Dispense();
            vendingMachine.SelectItem("Soda");
            vendingMachine.InsertCoin(new Coin(45));
            vendingMachine.Dispense();
        }

        static void PopulateInventory(VendingMachine vendingMachine)
        {
            var items = new Dictionary<Item, int>
            {
                { new Item("Coke", 25), 2 },
                { new Item("Pepsi", 35), 2 },
                { new Item("Soda", 45), 2 }
            };
            vendingMachine.FillMachine(items);
        }
    }
}