using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ChickenKitchenV1
{
    public class Comparer : IEqualityComparer<Dishes>
    {
        public bool Equals(Dishes x, Dishes y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            return x.Ingredients == y.Ingredients && x.Dish == y.Dish;
        }

        public int GetHashCode(Dishes obj)
        {
            throw new NotImplementedException();
        }
    }
}
