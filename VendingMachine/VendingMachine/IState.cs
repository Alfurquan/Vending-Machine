namespace VendingMachineProj
{

    public interface IState
    {
        public void InsertCoin(Coin coin);

        public void SelectItem(string item);

        public void Dispense();

    }
}