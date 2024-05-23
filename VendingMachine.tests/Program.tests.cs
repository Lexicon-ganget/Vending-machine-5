using System;
using System.Collections.Generic;
using System.Linq;
using Vending_machine_5.Models;
using Vending_machine_5.Services;
using Xunit;

namespace Vending_machine_5.Test
{
    public class VendingMachineServiceTests
    {
        private VendingMachineService _vendingMachine;

        public VendingMachineServiceTests()
        {
            _vendingMachine = new VendingMachineService();
        }

    //  InsertMoney Tests
        [Fact]
    public void InsertMoneyTest()
        {
            _vendingMachine.InsertMoney(50);
            var change = _vendingMachine.EndTransaction();

            Assert.Equal(1, change[50]);
        }
        [Fact]
        public void InsertMoneyException()
        {
            Assert.Throws<ArgumentException>(() => _vendingMachine.InsertMoney(3));
        }
        [Fact]
        public void PurchaseSuccessTest()
        {
            _vendingMachine.InsertMoney(20);
            var product = _vendingMachine.Purchase(2);
            Assert.NotNull(product);
            Assert.Equal("Chips", product.Name);
        }
        [Fact]
        public void PurchaseFailureTest()
        {
            _vendingMachine.InsertMoney(5);
            Assert.Throws<InvalidOperationException>(() => _vendingMachine.Purchase(1));
        }
        [Fact]
        public void InvalidProductTest()
        {
            _vendingMachine.InsertMoney(1000);
            Assert.Throws<ArgumentException>(() => _vendingMachine.Purchase(100));
        }
        [Fact]
        public void ShowAllTest()
        {
            var product = _vendingMachine.ShowAll();
            Assert.Equal(3, product.Count);
        }
        [Fact]
        public void DetailEqualProduct()
        {
            var detail = _vendingMachine.Details(1);
            Assert.Contains("Cola", detail);
        }
    }
}