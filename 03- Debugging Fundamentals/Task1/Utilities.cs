using System;

namespace Task1
{
    public static class Utilities
    {
        /// <summary>
        /// Sorts an array in ascending order using bubble sort.
        /// </summary>
        /// <param name="numbers">Numbers to sort.</param>
        public static void Sort(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            var length = numbers.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        // feature introduced in C# 7.0 called "tuple deconstruction" or "tuple swapping."
                        // It allows you to swap the values of two variables (or array elements, in this case) without using a temporary variable.
                        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the index of a product in an <paramref name="products"/> 
        /// based on a <paramref name="predicate"/>.
        /// </summary>
        /// <param name="products">Products used for searching.</param>
        /// <param name="predicate">Product predicate.</param>
        /// <returns>If match found then returns index of product in <paramref name="products"/>
        /// otherwise -1.</returns>
        public static int IndexOf(Product[] products, Predicate<Product> predicate)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            for (int i = 0; i < products.Length; i++)
            {
                if (predicate(products[i]))
                    return i;
            }

            return -1;
        }
    }
}
