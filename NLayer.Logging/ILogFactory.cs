namespace NLayer.Logging
{
    public interface ILogFactory
    {
        ILog<T> CreateLogger<T>() where T : class;
    }
}
