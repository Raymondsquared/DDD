namespace DDD.Infrastructure.CrossCutting
{
    public static class Constants
    {
        public static class Defaults
        {
            public static class Retry
            {
                public const int Maximum = 3;
                public const int DelayMillseconds = 900000; //15 minutes       
            }
            public static class Batch
            {
                public const int Size = 1;
            }
        }

        public static class Enumerations
        {
            public enum Days { Sat, Sun, Mon, Tue, Wed, Thu, Fri };
        }
    }
}
