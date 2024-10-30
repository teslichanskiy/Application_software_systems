using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3
{
    public class Purchase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Purchase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    //Абстрактная фабрика
    public interface IPurchaseFactory
    {
        Purchase CreatePurchase(string name, decimal price);
    }

    //Конкретная фабрика
    public class DefaultPurchaseFactory : IPurchaseFactory
    {
        public Purchase CreatePurchase(string name, decimal price)
        {
            return new Purchase(name, price);
        }
    }


    public sealed class PurchaseManager
    {
        private static readonly PurchaseManager instance = new PurchaseManager();

        private PurchaseManager()
        {
            Purchases = new List<Purchase>();
        }

        public static PurchaseManager Instance => instance;

        public List<Purchase> Purchases { get; }

        public void AddPurchase(Purchase purchase)
        {
            Purchases.Add(purchase);
        }

        public decimal GetTotalCost()
        {
            return Purchases.Sum(p => p.Price);
        }
    }
}
