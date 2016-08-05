using System;
using Csn.Logging;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Helpers
{
    public class LoggerHelper : ILogging
    {
        private readonly ILogger _logger;
        public LoggerHelper(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string message, params object[] p)
        {
            _logger.Debug(message, p);
        }
        public void Info(string message, params object[] p)
        {
            _logger.Info(message, p);
        }
        public void Warn(string message, params object[] p)
        {
            _logger.Warn(message, p);
        }
        public void Error(Exception ex, string message, params object[] p)
        {
            _logger.Error(ex, message, p);
        }

    }
}
