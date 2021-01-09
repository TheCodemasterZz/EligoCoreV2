namespace EligoCore.Interfaces
{
    public interface IEntityWithKey<TKey>: IAggregation
    {
        TKey Id { get; }
    }
}
