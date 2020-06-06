using System;
using System.Collections.Generic;

namespace ProductInventoryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // ID - [Initials of Product]_[The Order of the Same Product]
            Product oakChair = new Product("Oak_Chair", 25.0f, 2, "OC_05");
            Product blueKeyboard = new Product("Blue_Keyboard", 36.0f, 1, "BK_17");

            Inventory inventory = new Inventory();

            inventory.AddProduct(oakChair);
            inventory.AddProduct(blueKeyboard);

            float totalPrice = 0f;

            totalPrice = inventory.CalculatePrice();

            Console.WriteLine(totalPrice);

            Console.ReadLine();
        }
    }

    class Product 
    {
        // Properties that store each product
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Id { get; set; }

        public Product()
        {
            Name = "Undefined";
            Price = 0;
            Quantity = 0;
            Id = "Undefined";
        }

        public Product(string name, float price, int quantity, string id)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Id = id;
        }
    }

    class Inventory
    {
        // Store each product
        public List<Product> ProductList { get; set; }

        public Inventory()
        {
            ProductList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }

        // Find the total price of every product added
        public float CalculatePrice()
        {
            if (ProductList.Count != 0)
            {
                float totalPrice = 0;

                foreach (Product product in ProductList)
                {
                    totalPrice += product.Price * product.Quantity;
                }

                Math.Round(totalPrice, 2);

                return totalPrice;
            }
            else
            {
                return 0;
            }
        }
    }
}
