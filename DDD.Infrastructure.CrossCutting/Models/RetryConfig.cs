namespace DDD.Infrastructure.CrossCutting.Models
{
    public class RetryConfig
    {
        public int Maximum { get; set; }
        public int DelayMillseconds { get; set; }  
    }
}
