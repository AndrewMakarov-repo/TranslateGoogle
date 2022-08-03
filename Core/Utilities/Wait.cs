using System;
using System.Threading.Tasks;

namespace Core.Utilities
{
    public static class Wait
    {
        private static readonly int DefaultTimeOutMs = 15000;

        public static void For(Func<bool> condition)
        {
            For(condition, DefaultTimeOutMs);
        }

        public static void For(Func<bool> condition, int timeOut)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeOut)
            {
                try
                {
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                }

                TaskDelay(DefaultTimeOutMs / 200);
            }
        }

        public static void While(Func<bool> condition, int timeOut)
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalMilliseconds < timeOut)
            {
                try
                {
                    if (!condition())
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                }

                TaskDelay(DefaultTimeOutMs / 200);
            }
        }

        public static void TaskDelay(int milliseconds)
        {
            PutTaskDelay(milliseconds).Wait();
        }

        private static async Task PutTaskDelay(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }
    }
}