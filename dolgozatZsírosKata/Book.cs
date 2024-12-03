public class Book
{
    public string ISBN { get; private set; }
    public List<Author> Authors { get; private set; }
    public string Title { get; private set; }
    public int PublicationYear { get; private set; }
    public string Language { get; private set; }
    public int Stock { get; private set; }
    public int Price { get; private set; }

    private static Random rnd= new Random();

    // Constructor with all parameters
    public Book(string title, int publicationYear, string language, int stock, int price, params string[] authorNames)
    {
        ISBN = GenerateRandomISBN();
        Authors = authorNames.Select(name => new Author(name)).ToList();
        Title = title;
        PublicationYear = publicationYear;
        Language = language;
        Stock = stock;
        Price = price;
    }
    
    public Book(string title, string authorName)
    {
        ISBN = GenerateRandomISBN();
        Authors = new List<Author> { new Author(authorName) };
        Title = title;
        PublicationYear = 2024;
        Language = "magyar";
        Stock = 0;
        Price = 4500;
    }


    private string GenerateRandomISBN()
    {
        return string.Concat(Enumerable.Range(0, 10).Select(x => rnd.Next(0, 10).ToString()));
    }

    public void minusStock()
    {
        if (Stock > 0)
        {
            Stock--;
        }
    }

    public void pluss(int szam)
    {
        Stock += szam;
    }

    public override string ToString()
    {
        var authorLabel = Authors.Count == 1 ? "szerző:" : "szerzők:";
        var stockLabel = Stock == 0 ? "beszerzés alatt" : $"{Stock} db";
        return $"{Title} ({PublicationYear})\n{authorLabel} {string.Join(", ", Authors.Select(a => $"{a.FirstName} {a.LastName}"))}\nNyelv: {Language}\nKészlet: {stockLabel}\nÁr: {Price} Ft";
    }
}
