namespace Assets.Scripts.UI
{
    public interface IIntentContainer<T>
    {
        T Intent { get; }
        void SetIntent(T intent);
    }
}
