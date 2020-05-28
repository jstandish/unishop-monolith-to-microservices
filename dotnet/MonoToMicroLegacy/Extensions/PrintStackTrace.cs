using System;
using System.Web.DynamicData;

namespace MonoToMicroLegacy.Extensions
{
    public static class PrintStackTraceExtension
    {
        public static void PrintStackTrace(this Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }
}