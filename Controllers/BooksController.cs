using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using librarya.Models;
using librarya.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace librarya.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BooksService _bs;

    public BlogsController(BooksService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Book> Create([FromBody] Book newBook)
    {
      try
      {
        return Ok(_bs.Create(newBook));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Book> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}