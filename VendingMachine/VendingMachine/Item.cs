namespace VendingMachineProj
{

    public class Item
    {
        private string name;
        private int price;

        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string GetName()
        {
            return name;
        }

        public int GetPrice()
        {
            return price;
        }
    }
}