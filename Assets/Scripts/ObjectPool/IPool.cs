public interface IPool
{
    string Name { get; }
    
    void GetFromPool();
    void ReturnToPool();
}