using Application.Dtos;
using Application.Utils;
using Domain.Book;

namespace Application.Book.query.getByIdBook;

public class BookgetByIdHandler: IQueryHandler<BookgetByIdQuery, BookgetByIdOutput>
{
    public readonly IBookRepository _bookRepository;
    
    public BookgetByIdHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<BookgetByIdOutput> Handle(BookgetByIdQuery query)
    {
        // 1. Chercher le livre en base via le repository
        var book = await _bookRepository.GetByIdAsync(query.Id);

        // 2. Préparer l'output
        var output = new BookgetByIdOutput();

        if (book != null)
        {
            output.Book = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                LastModifiedAt = book.LastModifiedAt
            };
        }

        return output;
    }
}