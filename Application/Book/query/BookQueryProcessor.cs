using Application.Book.query.getAllBook;
using Application.Book.query.getByIdBook;
using Application.Utils;

namespace Application.Book.query;

public class BookQueryProcessor
{
    public readonly IQueryHandler<BookGetAllQuery, BookGetAllOutput> _bookGetAllHandler;
    public readonly IQueryHandler<BookgetByIdQuery, BookgetByIdOutput> _bookGetByIdHandler;
    
    public BookQueryProcessor(
        IQueryHandler<BookGetAllQuery, BookGetAllOutput> bookGetAllHandler,
        IQueryHandler<BookgetByIdQuery, BookgetByIdOutput> bookGetByIdHandler)
    {
        _bookGetAllHandler = bookGetAllHandler;
        _bookGetByIdHandler = bookGetByIdHandler;
    }
    
    public async Task<BookGetAllOutput> GetAllBooks(BookGetAllQuery query)
    {
        // On ajoute 'async' et 'await' ici
        return await _bookGetAllHandler.Handle(query);
    }
    
    public async Task<BookgetByIdOutput> GetBookById(BookgetByIdQuery query)
    {
        return await _bookGetByIdHandler.Handle(query);
    }
}