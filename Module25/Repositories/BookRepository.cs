using Microsoft.EntityFrameworkCore;
using Module25.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Repositories
{
    public class BookRepository
    {
        AppContext db = new AppContext();

        public Book? GetBookById(Guid id)
        {
            return db.Books.Where(book => book.Id == id).FirstOrDefault();
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public void CreateBook(string name, int year)
        {
            Book book = new Book(name, year);
            book.Id = Guid.NewGuid();
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void DeleteBookById(Guid id)
        {
            db.Books.Where(book => book.Id == id).ExecuteDelete();
            db.SaveChanges();
        }

        public void EditBookYear(Guid id, int year)
        {
            Book? book = GetBookById(id);
            if (book == null) { throw new Exception("Книги с этим ID не существует"); }
            book.YearOfRelease = year;
            db.SaveChanges();
        }

        //Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> GetByYearsDiaposoneAndGenre(Genres genre, int minYear, int  maxYear)
        {
            return db.Books.Where(book=> book.YearOfRelease<=maxYear && book.YearOfRelease>=minYear && book.Genre == genre).ToList();
        }

        //Получать количество книг определенного автора в библиотеке.
        public int GetBooksCountByAuthor(User Author)
        {
            int count = 0;
            count = db.Books.Where(book => book.Author == Author).Count();
            return count;
        }

        //Получать количество книг определенного жанра в библиотеке.
        public int GetBooksCountByGenre(Genres genre)
        {
            int count = 0;
            count = db.Books.Where(book => book.Genre == genre).Count();
            return count;
        }

        //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool HasBookByAuthorAndName(string name, User Author)
        {
            return db.Books.Where(Book => Book.Name == name && Book.Author == Author).Any();
        }

        //Получение последней вышедшей книги.
        public Book GetLastBook()
        {
            return db.Books.OrderBy(book => book.YearOfRelease).FirstOrDefault();
        }

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> GetBooksSortedByName()
        {
            return db.Books.OrderBy(book => book.Name).ToList();
        }

        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> GetBooksSortedByYear()
        {
            return db.Books.OrderByDescending(book=>book.YearOfRelease).ToList();
        }

    }
}
