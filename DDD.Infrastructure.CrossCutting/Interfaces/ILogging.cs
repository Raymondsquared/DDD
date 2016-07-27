using System;

namespace DDD.Infrastructure.CrossCutting.Interfaces
{
    public interface ILogging
    {
        void Debug(string message, params object[] p);
        void Info(string message, params object[] p);
        void Warn(string message, params object[] p);
        void Error(Exception ex, string message, params object[] p);
    }
}
