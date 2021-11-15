using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace ChickenKitchenV1
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvBaseIngriends = "BaseIngredients.csv";
            string csvDishesWithIngreinds = "FoodIngredients.csv";
            string csvCustomersWithAllergies = "CustomersAllergies.csv";


            //listy (potrawa, skladnik, skladnik, skladnik, czy też klient, alergia)
            var listOfDishesWithIngredients = File.ReadAllLines(csvDishesWithIngreinds).ToList();
            var listOfBaseIngrients = File.ReadAllLines(csvBaseIngriends).ToList();
            var listOfCustomersWithAllergies = File.ReadAllLines(csvCustomersWithAllergies).ToList();

            //stworzenie list obiektowych 
            var listOfObjectDishesWithIngriends = new List<Dishes>();
            var listOfObjectBaseIngrients = new List<BasesIngriends>();
            var listOfObjectCustomersWithAllergies = new List<Customers>();

            //dodanie do list obiektowych obiektów - klientów, alergi, dan itd.
            listOfObjectBaseIngrients.AddRange(listOfBaseIngrients.Select(x => new BasesIngriends(x.ToString())));
            listOfObjectDishesWithIngriends.AddRange(listOfDishesWithIngredients.Select(x => new Dishes(x.ToString())));
            listOfObjectCustomersWithAllergies.AddRange(
                listOfCustomersWithAllergies.Select(x => new Customers(x.ToString())));


            Console.WriteLine("---------------List Of Dishes--------------");
            listOfObjectDishesWithIngriends.ForEach(x => { Console.WriteLine(x.Dish[0]); });

            Console.WriteLine("\n");
            Console.WriteLine("---------------List Of Customers--------------");
            listOfObjectCustomersWithAllergies.ForEach(x => { Console.WriteLine(x.Customer); });

            Console.WriteLine("\n");
            Console.WriteLine("Write FullName dishes");
            var selectedDish = Console.ReadLine();
            do
            {
                if (listOfObjectDishesWithIngriends.Any(x => x.Dish[0].ToString() == selectedDish)) break;
                Console.WriteLine("There is no such dish, please try again");
                selectedDish = Console.ReadLine();
            } while (listOfObjectDishesWithIngriends.Any(x => x.Dish[0].ToString() != selectedDish));


            Console.WriteLine("\n");
            Console.WriteLine("Write FullName of customer");
            var selectedCustomer = Console.ReadLine();
            do
            {
                if (listOfObjectCustomersWithAllergies.Any(x => x.Customer.ToString() == selectedCustomer)) break;
                Console.WriteLine("There is no such customer, please try again");
                selectedCustomer = Console.ReadLine();
            } while (listOfObjectCustomersWithAllergies.Any(x => x.Customer.ToString() != selectedCustomer));

            var selectedCustomerWithAllergies = listOfObjectCustomersWithAllergies.Where(x => x.Customer == selectedCustomer).ToList();

            var selectedDishesWithIngriends = listOfObjectDishesWithIngriends.Where(x => x.Dish[0].ToString() == selectedDish).ToList();

            var comparer = new Comparer();

            var listofIn = selectedDishesWithIngriends.SelectMany(x => x.Ingredients.ToString()).ToList();
            var listnew = selectedCustomerWithAllergies.Select(x => x.Allergry).ToList();

            var listOfOnlyIngirends = selectedDishesWithIngriends.Where(x=>x.Equals(x.Ingredients));


         
            Console.WriteLine("s");
        }
    }
}

