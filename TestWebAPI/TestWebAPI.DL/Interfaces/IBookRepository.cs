using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPIModels.Models;

namespace TestWebAPI.DL.Interfaces
{
    public interface IBookRepository
    {
        Book GetById(int id);

        void AddBook(Book book);


        Book? FindAuthorById(int id);


        void RemoveBook(Book book);
    }
}
