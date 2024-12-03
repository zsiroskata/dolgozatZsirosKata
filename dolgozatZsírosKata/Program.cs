using System;
using System.Collections.Generic;
using System.Linq;

class Program
{                                                                                       
    static Random rnd = new Random();
    static void Main(string[] args)
    {
        var books = GenerateRandomBooks(15);
        var StartedCount = books.Sum(book => book.Stock);
        var total = 0;
        var outOfStock = 0;

        for (int i = 0; i < 100; i++)
        {
            var selectedBook = books[rnd.Next(books.Count)];

            if (selectedBook.Stock > 0)
            {
                selectedBook.minusStock(); 
                total += selectedBook.Price;
            }
            else
            {
                
                if (rnd.NextDouble() < 0.5)
                {
                    selectedBook.pluss(rnd.Next(1, 11));
                }
                else
                {
                    outOfStock++;
                    books.Remove(selectedBook);
                }
            }
        }

        var StockCount = books.Sum(book => book.Stock);
        var stockDifference = StockCount - StartedCount;

        Console.WriteLine($"Eladások összesen: {total} Ft");
        Console.WriteLine($"Kifogyott könyvek a nagykerben: {outOfStock} db");
        Console.WriteLine($"Készlet változás: Kezdetben {StartedCount} db, most {StockCount} db, különbség: {stockDifference} db");
    }

    
    static List<Book> GenerateRandomBooks(int count)
    {
        var books = new List<Book>();
        var languages = new[] { "angol", "német", "magyar" };

        for (int i = 0; i < count; i++)
        {
            var language = rnd.NextDouble() < 0.8 ? "magyar" : "angol";
            var title = GenerateRandomTitle(language);
            var authorCount = rnd.Next(1, 4); 
            var authors = new List<string>();

            for (int j = 0; j < authorCount; j++)
            {
                authors.Add(GenerateRandomName());
            }

            var publicationYear = rnd.Next(2007, DateTime.Now.Year + 1);
            var stock = rnd.NextDouble() < 0.3 ? 0 : rnd.Next(5, 11);
            var price = rnd.Next(10, 101) * 100;

            var book = new Book(title, publicationYear, language, stock, price, authors.ToArray());
            books.Add(book);
        }

        return books;
    }

    static string GenerateRandomTitle(string language)
    {
        if (language == "magyar")
            return "Random könyv " + rnd.Next(1000, 9999);
        else if (language == "angol")
            return "Random book " + rnd.Next(1000, 9999);
        else
            return "Zufälliges Buch " + rnd.Next(1000, 9999);
    }

    static string GenerateRandomName()
    {
        var firstNames = new[] { "John", "Attila", "Béla", "Anna", "Réka", "Lajos", "Terike" };
        var lastNames = new[] { "Smith", "Fazekas", "", "Lakatos", "Kovács", "Nemtudom" };

        return $"{firstNames[rnd.Next(firstNames.Length)]} {lastNames[rnd.Next(lastNames.Length)]}";
    }
}
