namespace DDD.Infrastructure.CrossCutting.Interfaces
{
    public interface ISerialiser
    {
        T Deserialise<T>(string input);
        string Serialise<T>(T input);
    }
}
