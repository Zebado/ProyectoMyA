
public interface IMemento
{
    Memento SaveState();
    void RestoreState(Memento memento);

}
