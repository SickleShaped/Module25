using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.EntityModels;

public class Book
{
    public Book() { }
    public Book(string name, int year)
    {
        Name = name;
        YearOfRelease = year;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public int YearOfRelease {get; set;}
    //Можно сдлеать даже не просто энамом, а листом энамов, чтобы реализовать теги
    public Genres Genre { get; set; }

    public Guid UserId { get; set; }
    public User UserHavingThisOnHands { get; set; }
    public User Author { get; set; }
}
