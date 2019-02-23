using NUnit.Framework;
using NSubstitute​;
using FlowerShop;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // ARRANGE
            IClientDAO ns = Substitute​.For<IClientDAO>();
            Client newClient = new Client(ns, "Name", "0215005421540");

            IOrderDAO sd = Substitute​.For<IOrderDAO>();
            Order newOrder = new Order(sd, newClient);
            IOrder order = Substitute.For<IOrder>();

            // ACT
            newOrder.Deliver();

            // ASSERT 
            Assert.AreEqual(2, sd.ReceivedCalls().Count());
        }

        [Test]
        public void Test2()
        {
            // ARRANGE
            IClientDAO ns = Substitute​.For<IClientDAO>();
            Client newClient = new Client(ns, "Name", "0215005421540");

            IOrderDAO sd = Substitute​.For<IOrderDAO>();
            Order newOrder = new Order(sd, newClient, false);
            IOrder order = Substitute.For<IOrder>();
            
            IFlowerDAO flo = Substitute​.For<IFlowerDAO>();
            IFlower mflo = Substitute​.For<IFlower>();

            mflo = new Flower(flo, "sjdnskjdb as", 100, 20);

            // ACT
            newOrder.AddFlowers(mflo, flo, 21);

            // ASSERT 
            Assert.AreEqual(120, newOrder.Price);
        }
    }
}