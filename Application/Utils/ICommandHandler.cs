namespace Application.Utils;

public interface ICommandHandler<I,O>
{
    Task<O> Handle(I query);
    
}