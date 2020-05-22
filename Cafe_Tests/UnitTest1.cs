using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class UnitTest1
    {
    private readonly MenuRepository _repo = new MenuRepository();
        [TestInitialize]
        public void SeedRepo()
        {
            Menu coffee = new Menu(1, "1. Coffee", "Bean juice", new List<string>() { "Water", "Beans" }, 2.99);
            Menu espresso = new Menu(2, "2. Shot of Espresso", "Instant gratification", new List<string>() { "Water", "Espresso" }, 1.99);
            Menu pastry = new Menu(3, "3. Pastry", "Tasty treat to go with your drink", new List<string>() { "Sugar", "Spice", "Everything Nice" }, 3.49);

            _repo.CreateItem(coffee);
            _repo.CreateItem(espresso);
            _repo.CreateItem(pastry);
        }

        [TestMethod]
        public void AddItemToMenu()
        {
            Menu cupcake = new Menu(4, "Cupcake", "A cake in the shape of a cup", new List<string> { "Cups", "Cakes" }, 2.49);
            Menu latte = new Menu(5, "Latte", "Tasty treat", new List<string> { "Espresso", "Milk" }, 5.49);

            _repo.CreateItem(cupcake);
            _repo.CreateItem(latte);

            int expected = 5;
            int actual = _repo.GetListOfItems().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveItemFromMenu()
        {
            _repo.DeleteItem(3);

            int expected = 2;
            int actual = _repo.GetListOfItems().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReceiveItemByNumber()
        {
            Menu espressoCake = new Menu(6, "Espresso Cake", "Do not eat this!", new List<string> { "Espresso", "That's it" }, 0.99);
            _repo.CreateItem(espressoCake);

            Menu testContent = _repo.GetItemByNumber(6);

            Assert.AreEqual(espressoCake, testContent);
        }
    }
}
