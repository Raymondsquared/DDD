using DDD.Infrastructure.CrossCutting.Abstractions;
using Newtonsoft.Json;

namespace DDD.Infrastructure.CrossCutting.Serialisers
{
    public class JsonSerializer : ISerialiser
    {
        public T Deserialise<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        public string Serialise<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
