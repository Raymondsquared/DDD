namespace DDD.Infrastructure.CrossCutting.Validators.Abstractions
{
    public interface IValidationChecker<in T>
    {
        bool IsValid(T input);
    }
}
