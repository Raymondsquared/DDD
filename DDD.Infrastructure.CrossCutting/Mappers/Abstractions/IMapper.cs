namespace DDD.Infrastructure.CrossCutting.Mappers.Abstractions
{
    public interface IMapper<in TInput, out TOutput>
    {
        TOutput Map(TInput input);
    }
}