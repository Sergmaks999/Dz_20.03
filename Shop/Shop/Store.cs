using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement
{
    public class Store<T> : IStore<T> where T : IProduct
    {
        private List<T> products = new List<T>();

        public void Add(T product)
        {
            if (products.Any(p => p.Id == product.Id))
            {
                throw new ArgumentException($"Товар с Id {product.Id} уже существует в магазине.");
            }

            products.Add(product);
        }

        public void Remove(int id)
        {
            T productToRemove = products.FirstOrDefault(p => p.Id == id);

            if (productToRemove == null)
            {
                throw new InvalidOperationException($"Товара с Id {id} не найдено в магазине.");
            }

            products.Remove(productToRemove);
        }

        public T GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePrice(int id, decimal newPrice)
        {
            T productToUpdate = products.FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
            {
                throw new ArgumentException($"Товара с Id {id} не найдено для обновления цены.");
            }

            productToUpdate.Price = newPrice;
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            T productToUpdate = products.FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
            {
                throw new ArgumentException($"Товара с Id {id} не найдено для обновления количества.");
            }

            productToUpdate.Quantity = newQuantity;
        }

        public List<T> GetProductsByCategory(string category)
        {
            return products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Dictionary<string, List<T>> GroupByCategory()
        {
            return products.GroupBy(p => p.Category)
                           .ToDictionary(g => g.Key, g => g.ToList());
        }

        public void PrintAllProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}