using System;
using System.Collections.Generic;
using librarya.Models;
using librarya.Repositories;

namespace librarya.Services
{
  public class BooksService
  {
    private readonly BooksRepository _repo;

    public BooksService(BooksRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Book> GetAll()
    {
      return _repo.GetAll();
    }

    internal Book Create(Book newBook)
    {
      Book createdBook = _repo.Create(newBook);
      return createdBook;
    }

    internal Book GetById(int id)
    {
      Book foundBook = _repo.GetById(id);
      if (foundBook == null)
      {
        throw new Exception("Invalid id.");
      }
      return foundBook;
    }

    internal Book Delete(int id)
    {
      Book foundBook = GetById(id);
      if (_repo.Delete(id))
      {
        return foundBook;
      }
      throw new Exception("Something bad happened...");
    }
  }
}