using System;

public class Author
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid AuthorId { get; private set; }

    public Author(string fullName)
    {
        var nameParts = fullName.Split(' ');
        if (nameParts.Length != 2)
            throw new ArgumentException("Full name must contain first and last name");

        FirstName = nameParts[0];
        LastName = nameParts[1];    
        AuthorId = Guid.NewGuid();
    }
}
