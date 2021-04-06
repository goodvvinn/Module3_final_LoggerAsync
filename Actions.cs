using LoggerAsync.Configs;

namespace LoggerAsync
{
    public static class Actions
    {
        public static Result FirstMethod()
        {
            Result result = new Result()
            {
                Message = "First Method()",
            };
            return result;
        }

        public static Result SecondMethod()
        {
            Result result = new Result()
            {
                Message = "Second Method()",
            };
            return result;
        }
    }
}
