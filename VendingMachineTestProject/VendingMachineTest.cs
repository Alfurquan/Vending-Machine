using NUnit.Framework;
using System;
using System.Collections.Generic;
using VendingMachineProj;

namespace VendingMachineTestProject
{
    public class VendingMachineTests
    {
        private static VendingMachine vendingMachineMock;

        [SetUp]
        public void Setup()
        {
            vendingMachineMock = new VendingMachine();
            PopulateVendingMachine(vendingMachineMock);
        }

        [Test]
        [TestCaseSource(nameof(TestDataForSelectItem))]
        public void SelectItem_WhenCalled_SetsSelectedItemAndMovesToProcessingState(VendingMachine vendingMachine, string itemSelected, Type expectedStateType)
        {
            vendingMachine.SelectItem(itemSelected);
            Assert.That(vendingMachine.GetState().GetType(), Is.EqualTo(expectedStateType));
        }

        [Test]
        [TestCaseSource(nameof(TestDataForInsertCoin))]
        public void InsertCoint_WhenCalled_SetsSelectedCoinAndChangesState(VendingMachine vendingMachine, int coinValue, Type expectedStateType)
        {
           
            vendingMachine.InsertCoin(new Coin(coinValue));
            Assert.That(vendingMachine.GetState().GetType(), Is.EqualTo(expectedStateType));
        }

        [Test]
        [TestCaseSource(nameof(TestDataForDispense))]
        public void Dispense_WhenCalled_DispensesItemAndChangesState(VendingMachine vendingMachine, int expectedItemCount, Type expectedStateType)
        {
            vendingMachine.Dispense();
            Assert.That(vendingMachine.GetState().GetType().Equals(expectedStateType));
            Assert.That(vendingMachine.GetSelectedItemCount(), Is.EqualTo(expectedItemCount));
        }


        private static IEnumerable<object[]> TestDataForSelectItem()
        {
            VendingMachine vendingMachine = new VendingMachine();
            PopulateVendingMachine(vendingMachine);
            vendingMachine.SetState(new Idle(vendingMachine));
            yield return new object[] { vendingMachine, "Coke", typeof(Processing) };

            vendingMachine = new VendingMachine();
            PopulateVendingMachine(vendingMachine);
            vendingMachine.SetState(new Idle(vendingMachine));
            yield return new object[] { vendingMachine, "Sprite", typeof(Idle) };

        }

        private static IEnumerable<object[]> TestDataForInsertCoin()
        {
            VendingMachine vendingMachine = new VendingMachine();
            PopulateVendingMachine(vendingMachine);
            vendingMachine.SetState(new Idle(vendingMachine));
            vendingMachine.SelectItem("Coke");
            yield return new object[] {vendingMachine, 25, typeof(Sold)};

            vendingMachine = new VendingMachine();
            PopulateVendingMachine(vendingMachine);
            vendingMachine.SetState(new Idle(vendingMachine));
            vendingMachine.SelectItem("Coke");
            yield return new object[] { vendingMachine, 20, typeof(Processing) };
        }
        
        private static IEnumerable<object[]> TestDataForDispense()
        {
            VendingMachine vendingMachine = new VendingMachine();
            PopulateVendingMachine(vendingMachine);
            vendingMachine.SetState(new Idle(vendingMachine));
            vendingMachine.SelectItem("Coke");
            vendingMachine.InsertCoin(new Coin(25));
            yield return new object[] { vendingMachine, 1, typeof(Idle)};

            vendingMachine = new VendingMachine();
            vendingMachine.FillMachine(new Dictionary<Item, int> {
                {
                    new Item("Soda", 45), 1
                } 
            });
            vendingMachine.SetState(new Idle(vendingMachine));
            vendingMachine.SelectItem("Soda");
            vendingMachine.InsertCoin(new Coin(45));
            yield return new object[] { vendingMachine, 0, typeof(SoldOut) };
        }

        private static void PopulateVendingMachine(VendingMachine vendingMachine)
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