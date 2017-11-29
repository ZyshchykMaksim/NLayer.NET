namespace NLayer.Logging.NLog
{
    public class LogFactory : ILogFactory
    {
        public ILog<T> CreateLogger<T>() where T : class
        {
            return new Log<T>();
        }
    }
}
