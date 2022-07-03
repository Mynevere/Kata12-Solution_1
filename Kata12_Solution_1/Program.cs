﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Timers;
using System.Xml;

namespace Kata12_Solution_1
{
    class Program
    {
        public static List<Product> CreateProducts()
        {
            List<Product> products = new List<Product> {
            new Product { Id = 1, Name = "Product 1", Price = 100, Sold = 5 },
            new Product { Id = 2, Name = "Product 2", Price = 200, Sold = 4 },
            new Product { Id = 3, Name = "Product 3", Price = 90, Sold = 2 },
            new Product { Id = 4, Name = "Product 4", Price = 400, Sold = 1 },
            new Product { Id = 5, Name = "Product 5", Price = 80, Sold = 1 },
            new Product { Id = 6, Name = "Product 6", Price = 100, Sold = 5 },
            new Product { Id = 7, Name = "Product 7", Price = 200, Sold = 4 },
            new Product { Id = 8, Name = "Product 8", Price = 100, Sold = 5 },
            new Product { Id = 9, Name = "Product 9", Price = 200, Sold = 4 },
            new Product { Id = 10, Name = "Product 10", Price = 100, Sold = 5 },
            new Product { Id = 11, Name = "Product 11", Price = 200, Sold = 11 },
            new Product { Id = 12, Name = "Product 12", Price = 200, Sold = 9 },
            new Product { Id = 13, Name = "Product 13", Price = 300, Sold = 10 },
            new Product { Id = 14, Name = "Product 14", Price = 400, Sold = 1 },
            new Product { Id = 15, Name = "Product 15", Price = 400, Sold = 1 },
            new Product { Id = 16, Name = "Product 16", Price = 400, Sold = 1 },
            new Product { Id = 17, Name = "Product 17", Price = 400, Sold = 1 },
            new Product { Id = 18, Name = "Product 18", Price = 400, Sold = 1 },
            new Product { Id = 19, Name = "Product 19", Price = 400, Sold = 1 },
            new Product { Id = 20, Name = "Product 20", Price = 400, Sold = 1 },
            new Product { Id = 21, Name = "Product 21", Price = 400, Sold = 1 },
            new Product { Id = 22, Name = "Product 22", Price = 400, Sold = 1 },
            new Product { Id = 23, Name = "Product 23", Price = 400, Sold = 1 },
            new Product { Id = 24, Name = "Product 24", Price = 400, Sold = 1 },
            new Product { Id = 25, Name = "Product 25", Price = 400, Sold = 1 },
            new Product { Id = 26, Name = "Product 26", Price = 400, Sold = 1 },
            new Product { Id = 27, Name = "Product 27", Price = 400, Sold = 1 },
            new Product { Id = 28, Name = "Product 28", Price = 400, Sold = 1 },
            new Product { Id = 29, Name = "Product 29", Price = 400, Sold = 1 },
            new Product { Id = 30, Name = "Product 30", Price = 400, Sold = 19 }};

            return products;
        }

        public BinarySearchTree TopTenBinaryTree(List<Product> products) 
        {
            var topTen = products.ToDictionary(x => x.Id, x => x.Sold).OrderByDescending(x => x.Value).Take(10).ToList();

            //Balanced BST of top ten products 
            BinarySearchTree binaryTree = new BinarySearchTree();
            foreach (var product in topTen)
            {
                binaryTree.Add(product.Key);
            }

            return binaryTree;
        }

        public bool SellProduct(int id)
        {
            var products = CreateProducts();
            foreach (var prod in products)
            {
                if (prod.Id == id)
                {
                    prod.Sold++;
                }
            }
            return true;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            var products = CreateProducts();
            var list = program.TopTenProducts(products, program);
            foreach (var o in list)
            {
                Console.WriteLine("Name: " + o.Name + "- Sold Nr: " + o.Sold);
            }
        }

        public List<Product> TopTenProducts(List<Product> products, Program program) 
        {
            var bst = program.TopTenBinaryTree(products);
            List<Product> topTen = new List<Product>();

            foreach (var product in products.OrderByDescending(x => x.Sold))
            {
                if (bst.Find(product.Id) != null)
                {
                    topTen.Add(product);
                }
            }
            return topTen;
        }
    }
}