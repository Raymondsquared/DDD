using System.Threading.Tasks;

namespace DDD.Infrastructure.CrossCutting.Delegates
{
    public delegate Task<bool> RetryDelegate();
}
