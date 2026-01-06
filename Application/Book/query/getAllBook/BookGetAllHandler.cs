using Application.Dtos;
using Application.Utils;
using Domain.Book;

namespace Application.Book.query.getAllBook;

public class BookGetAllHandler:IQueryHandler<BookGetAllQuery, BookGetAllOutput>
{
    private readonly  IBookRepository _bookRepository;
    
    public BookGetAllHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<BookGetAllOutput> Handle(BookGetAllQuery request)
    {
        // On attend (await) que la base de données réponde
        var books = await _bookRepository.GetAllAsync();

        // Maintenant 'books' est une vraie liste, on peut la transformer
        var bookDtos = books.Select(i => new BookDto()
        {
            Id = i.Id,
            Title = i.Title,
            Author = i.Author,
            LastModifiedAt = i.LastModifiedAt 
        }).ToList();

        return new BookGetAllOutput
        {
            Books = bookDtos
        };
    }
}