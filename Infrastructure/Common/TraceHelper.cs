using System;
using System.Diagnostics;

namespace SecretMadonna.NEMS.Infrastructure.Common
{
    public static class TraceHelper
    {
        public static void Exception(Exception exception)
        {
            var message = exception.Message;
            Trace.TraceError(message);
        }
        public static void Infomation(string infomation)
        {
            Trace.TraceInformation(infomation);
        }
    }
}
