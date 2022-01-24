using WebAPI.Models;

namespace WebAPI
{
    public static class DbInitializer
    {
        public static void Initialize(WebAPIContext context)
        {
            if (context.Counters.Any())
            {
                return;
            }

            var counters = new Counter[]
            {
                new Counter{ Value = "Hello world!" },
                new Counter{ Value = "Some other msg" },
            };

            context.Counters.AddRange(counters);
            context.SaveChanges();
        }
    }
}
