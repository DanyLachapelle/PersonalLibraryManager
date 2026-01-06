using Application.Utils;
using Domain.Book;

namespace Application.Book.commands.addBook;

public class AddBookHandler:ICommandHandler<AddBookCommand,AddBookOutput>
{
    public readonly  IBookRepository _bookRepository;
    
    public AddBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<AddBookOutput> Handle(AddBookCommand command)
    {
        // 1. Création de l'entité de domaine à partir de la commande
        var newBook = new Domain.Book.Book()
        {
            Title = command.Title,
            Author = command.Author,
            LastModifiedAt = DateTime.UtcNow
        };

        // 2. Appel au repository pour l'insertion en base
        await _bookRepository.AddAsync(newBook);

        // 3. Retour de l'ID généré par MySQL
        return new AddBookOutput
        {
            Id = newBook.Id,
            Success = true
        };
    }
}