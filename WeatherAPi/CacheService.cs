namespace IntegrationTests;

public class CacheService : ICacheService
{
    public int SetCache(string key, object value)
    {
        throw new NotImplementedException();
    }
}

public interface ICacheService
{
   int SetCache(string key, object value);
}