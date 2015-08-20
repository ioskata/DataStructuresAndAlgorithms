namespace ProductsInPriceRange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class ProductsInPriceRangeMain
    {
        private static OrderedMultiDictionary<decimal, string> productPrices = new
            OrderedMultiDictionary<decimal, string>(true);

        static void Main(string[] args)
        {
            FillProducts(10000);
            decimal startPrice = decimal.Parse(Console.ReadLine());
            decimal endPrice = decimal.Parse(Console.ReadLine());
            var top20 = productPrices.Range(startPrice, true, endPrice, true).Take(20);

            foreach (var product in top20)
            {
                foreach (var pName in product.Value)
                {
                    Console.WriteLine("{0} - {1:F2}", pName, product.Key);
                }
            }
        }

        private static void FillProducts(int productsCount)
        {
            Random rnd = new Random();
            StringBuilder productName = new StringBuilder();
            for (int i = 0; i < productsCount; i++)
            {
                // generate product name
                productName.Clear();
                int nameLength = rnd.Next(10, 55);
                for (int j = 0; j < nameLength; j++)
                {
                    int charPosition = rnd.Next(26) + 65;
                    productName.Append((char)charPosition);
                }

                decimal productPrice = Convert.ToDecimal(RandomNumberBetween(10, 250, rnd));
                productPrices.Add(productPrice, productName.ToString());
            }
        }

        private static double RandomNumberBetween(double minValue, double maxValue, Random random)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }
    }
}
