using Microsoft.AspNetCore.Mvc;
using Rocketseat_CSharp_SecondDesafio.Communication.Requests;

namespace Rocketseat_CSharp_SecondDesafio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestRegisterBookJson request)
    {
        var response = new Book
        {
            Id = 1,
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Quantity = request.Quantity
        };
        
        return Created(string.Empty, response);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "The Secret of C#",
                Author = "John Developer",
                Genre = "Non-fiction",
                Price = 39.90m,
                Quantity = 12
            },
            new Book
            {
                Id = 2,
                Title = "Mysteries of ASP.NET",
                Author = "Maria Code",
                Genre = "Mystery",
                Price = 49.90m,
                Quantity = 8
            },
            new Book
            {
                Id = 3,
                Title = "Journey to Razor Mountain",
                Author = "Lucas Razor",
                Genre = "Fantasy",
                Price = 29.50m,
                Quantity = 20
            },
            new Book
            {
                Id = 4,
                Title = "Entity Framework Tales",
                Author = "Sofia Database",
                Genre = "Fiction",
                Price = 45.00m,
                Quantity = 15
            },
            new Book
            {
                Id = 5,
                Title = "The Lost Algorithms",
                Author = "Pedro Logic",
                Genre = "Science Fiction",
                Price = 55.30m,
                Quantity = 5
            }
        };
        
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string),StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        if (id != 1)
        {
            return NotFound();
        }
        
        var response = new Book
        {
            Id = 1,
            Title = "The Secret of C#",
            Author = "John Developer",
            Genre = "Non-fiction",
            Price = 39.90m,
            Quantity = 12
        };
            
        return Ok(response);

    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, [FromBody] RequestRegisterBookJson request)
    {
        if (id != 1)
        {
            return NotFound();
        }

        var response = new Book
        {
            Id = 1,
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Quantity = request.Quantity
        };
        
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}