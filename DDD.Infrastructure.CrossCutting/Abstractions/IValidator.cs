namespace DDD.Infrastructure.CrossCutting.Abstractions
{
    public interface IValidator<in T>
    {
        bool IsValid(T input);
    }
}
