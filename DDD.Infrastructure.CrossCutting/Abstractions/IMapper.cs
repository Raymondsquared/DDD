namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IMapper<in TInput, out TOutput>
    {
        TOutput Map(TInput input);
    }
}