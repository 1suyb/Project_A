public interface ICommand
{
    void Execute();
}
public interface IUndoCommand : ICommand
{
    void Undo();
}