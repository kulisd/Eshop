namespace Eshop.Application.Configuration.Commands;

public abstract class InternalCommandBase(Guid id) : ICommand
{
    public Guid Id { get; } = id;
}

public abstract class InternalCommandBase<TResult>(Guid id) : ICommand<TResult>
{
    public Guid Id { get; } = id;

    protected InternalCommandBase() : this(Guid.NewGuid())
    {
    }
}