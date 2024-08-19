namespace Module25.EntityModels;
public class User
{
    public User() { }
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public List<Book> BooksOnHands { get; set; } = new List<Book>();
    public List<Book> WrittedBooks { get; set; } = new List<Book>();
}