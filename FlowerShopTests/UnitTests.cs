using NUnit.Framework;

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
    }
}