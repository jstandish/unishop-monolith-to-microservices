using System;

namespace MonoToMicroLambda.Extensions
{
    public static class PrintStackTraceExtension
    {
        public static void PrintStackTrace(this Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}