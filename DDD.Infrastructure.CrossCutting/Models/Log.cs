using System;

namespace DDD.Infrastructure.CrossCutting.Models
{
    public class Log
    {
        public DateTime StartedUtc { get; set; }
        public DateTime FinishedUtc { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
