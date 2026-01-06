using Application.Dtos;

namespace Application.Book.query.getAllBook;

public class BookGetAllOutput
{
    public List<BookDto> Books { get; set; } = new List<BookDto>();
}