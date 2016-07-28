namespace DDD.Infrastructure.CrossCutting.Mappers.Abstractions
{
    namespace DataSyncWorker.Mappers.Abstractions
    {
        public interface IMapperResolver<in TInput, TOutput>
        {
            void Resolve(TInput input, ref TOutput output);
        }
    }
}
