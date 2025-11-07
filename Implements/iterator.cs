namespace AlgoPortfolio.Implements;

public interface IIterator<T>
{
    bool HasNext();
    T Next();
}