namespace DDD.Infrastructure.CrossCutting.Validators.Abstractions
{
    public interface IValidator<in T>
    {
        bool IsValid(T input);
    }
}
