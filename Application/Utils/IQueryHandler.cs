namespace Application.Utils;

public interface IQueryHandler<I,O>
{
    Task<O> Handle(I query);
}