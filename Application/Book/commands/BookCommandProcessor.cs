using Application.Book.commands.addBook;
using Application.Utils;

namespace Application.Book.commands;

public class BookCommandProcessor
{
    public readonly ICommandHandler<AddBookCommand, AddBookOutput> _addBookHandler;
    
    public BookCommandProcessor(ICommandHandler<AddBookCommand, AddBookOutput> addBookHandler)
    {
        _addBookHandler = addBookHandler;
    }
    
    public async Task<AddBookOutput> AddBook(AddBookCommand command)
    {
        return await _addBookHandler.Handle(command);
    }
}