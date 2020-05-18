using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using librarya.Models;

namespace librarya.Repositories
{
  public class BooksRepository
  {
    private readonly IDbConnection _db;

    public BooksRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Book> GetAll()
    {
      string sql = "SELECT * FROM books";
      return _db.Query<Book>(sql);
    }

    internal Book Create(Book newBook)
    {
      string sql = @"
      INSERT INTO books
      (title, Auther, isAvailable)
      VALUES
      (@Title, @Body, @IsPublished);
      SELECT LAST_INSERT_ID()";
      newBook.Id = _db.ExecuteScalar<int>(sql, newBook);
      return newBook;
    }

    internal Book GetById(int id)
    {
      string sql = "SELECT * FROM books WHERE id = @Id";
      return _db.QueryFirstOrDefault<Book>(sql, new { id });
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM books WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}