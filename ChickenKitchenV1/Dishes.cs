using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ChickenKitchenV1
{
    public class Dishes
    {
        public List<string> Dish { get; set; }

        public List<string> Ingredients { get; set; }



        public Dishes(string rowDish)
        {
            Ingredients = new List<string>();
            Dish = new List<string>();

            List<string> data = rowDish.Split(',').ToList();

            this.Dish.Add(data[0]);

            for (int i = 1; i < data.Count; i++)
            {
                this.Ingredients.Add(data[i]);
    
            }
        }

    }
}

