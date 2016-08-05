namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface ISerialiser
    {
        T Deserialise<T>(string input);
        string Serialise<T>(T input);
    }
}
