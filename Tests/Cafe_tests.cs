using System;
using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class Tests
    {
        private Repository _contentRepo;
        private Menu _content;

        [TestInitialize]
        public void Initialize()
        {
            _contentRepo = new Repository();
            _content = new Menu(1, "Hawaiian Pizza", "A twist on traditional pizza that provides a hint from the aloha state.", "12-inch pizza crusts, traditional pizza sauce, 3-cheese blend, ham, and pinapple.", "Price: $12.00");
        }

        [TestMethod]
        public void AddContentToList()
        {
            _contentRepo.AddOrder(_content);

            int expected = 1;
            int actual = _contentRepo.ListOrders().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveContentFromList()
        {
            Repository contentRepo = new Repository();

            contentRepo.AddOrder(_content);

            bool wasRemoved = contentRepo.RemoveOrder(_content);
            Assert.IsTrue(wasRemoved);
        }


        [TestMethod]
        public void POCOTest()
        {
            Menu neworder = new Menu(2, "Florentien Gnocchi", "An itialian inspired Gnocchi dish.", "Gnocchi, sausage, tomatos, and shallots.", "Price: $14.00");

            Assert.AreEqual(1, neworder.ItemNumber);
            Assert.AreEqual("Florentien Gnocchi", neworder.Name);
            Assert.AreEqual("An itialian inspired Gnocchi dish.", neworder.Description);
            Assert.AreEqual("Gnocchi, sausage, tomatos, and shallots.", neworder.Ingredients);
        }
    }
}
