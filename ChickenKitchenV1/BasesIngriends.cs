using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ChickenKitchenV1
{
    class BasesIngriends 
    {
        public string Ingrient;


        public BasesIngriends(string rowIngrient)
        {
            List<string> data = rowIngrient.Split(',').ToList();

            this.Ingrient = data[0];
        }

    }
}
