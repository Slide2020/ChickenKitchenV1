using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChickenKitchenV1
{
    class Customers
    {
        public string Customer { get; set; }
        public string Allergry { get; set; }

        public Customers(string customerRow)
        {
      
            List<string> data = customerRow.Split(',').ToList();

            this.Customer = data[0];
            this.Allergry = data[1];

        }


    }
}
