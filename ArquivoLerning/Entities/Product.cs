using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ArquivoLerning.Entities
{
    class Product
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public Product() { }

        public Product(string[] vet)
        {

            Name = vet[0];
            Price = double.Parse(vet[1],CultureInfo.InvariantCulture);
            Quantity = int.Parse(vet[2]);
        }

        public double Total()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Name
                + ", "
                + Total().ToString("F2",CultureInfo.InvariantCulture);
        }
    }
}
