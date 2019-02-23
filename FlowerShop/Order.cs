using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }
        private IOrderDAO TheDoa;

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                double num = 0;
                foreach (Flower f in flowers)
                {
                    num += f.Cost + (f.Cost * 0.2);
                }
                return num;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            TheDoa = dao;
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            TheDoa = dao;
            Id = dao.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, IFlowerDAO dAO, int n)
        {
            flowers.Add(new Flower(dAO, flower.Description, flower.Cost, n));
        }

        public void Deliver()
        {
            TheDoa.SetDelivered(this);
        }
    }
}
