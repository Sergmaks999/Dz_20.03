using System;
using System.Collections.Generic;
using StoreManagement;

public class Program
{
    public static void Main(string[] args)
    {
        Store<Product> store = new Store<Product>();

        try
        {
            store.Add(new Product { Id = 1, Name = "Яблоки", Price = 50, Category = "Продукты", Quantity = 100 });
            store.Add(new Product { Id = 2, Name = "Телевизор", Price = 15000, Category = "Бытовая техника", Quantity = 5 });
            store.Add(new Product { Id = 3, Name = "Футболка", Price = 800, Category = "Одежда", Quantity = 30 });
            store.Add(new Product { Id = 4, Name = "Молоко", Price = 60, Category = "Продукты", Quantity = 50 });
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка при добавлении товара: {ex.Message}");
        }

        Console.WriteLine("Все товары в магазине:");
        store.PrintAllProducts();
        Console.WriteLine();

        Console.WriteLine("Товары категории 'Продукты':");
        List<Product> productsInCategory = store.GetProductsByCategory("Продукты");
        foreach (var product in productsInCategory)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();

        Console.WriteLine("Товары, сгруппированные по категориям:");
        Dictionary<string, List<Product>> groupedProducts = store.GroupByCategory();
        foreach (var category in groupedProducts)
        {
            Console.WriteLine($"Категория: {category.Key}");
            foreach (var product in category.Value)
            {
                Console.WriteLine($"  {product}");
            }
        }
        Console.WriteLine();

        try
        {
            store.UpdatePrice(2, 16000);
            Console.WriteLine("Цена товара с Id 2 успешно обновлена.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка при обновлении цены: {ex.Message}");
        }

        try
        {
            store.Remove(3);
            Console.WriteLine("Товар с Id 3 успешно удален.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка при удалении товара: {ex.Message}");
        }

        Console.WriteLine("Все товары в магазине после изменений:");
        store.PrintAllProducts();
    }
}