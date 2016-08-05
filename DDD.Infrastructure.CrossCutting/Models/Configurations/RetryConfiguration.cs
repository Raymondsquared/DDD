namespace DDD.Infrastructure.CrossCutting.Models.Configurations
{
    public class RetryConfiguration
    {
        public int Maximum { get; set; }
        public int DelayMillseconds { get; set; }  
    }
}
