using Microsoft.EntityFrameworkCore;
using Module25.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Repositories
{
    public class UserRepository
    {
        AppContext db = new AppContext();

        public User? GetUserBuId(Guid id)
        {
            return db.Users.Where(user => user.Id == id).FirstOrDefault();
        }

        public List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public void CreateUser(string Name, string Email)
        {
            User user = new User(Name, Email);
            user.Id = Guid.NewGuid();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteUserById(Guid id)
        {
            db.Users.Where(user => user.Id == id).ExecuteDelete();
            db.SaveChanges();
        }
        
        public void EditUserName(Guid id, string Name)
        {
            User? User = GetUserBuId(id);
            if (User == null) { throw new Exception("Пользователя с этим ID не существует"); }
            User.Name = Name;
            db.SaveChanges();
        }

        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool HasBookOnHands(Guid id, Book book)
        {
            return db.Users.Where(user => user.Id == id && user.BooksOnHands.Contains(book)).Any();
        }

        //Получать количество книг на руках у пользователя.
        public int GetBooksOnHandsCount(Guid id)
        {
            int count = 0;
            var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
            count = user.BooksOnHands.Count();
            return count;
        }



    }
}
