using System;
using StackExchange.Redis;

namespace BfuDay2
{
    public static class ShortenHelper
    {
        private static Lazy<ConnectionMultiplexer> multiplexer = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect("bfushortener.redis.cache.windows.net,ssl=true,password=t+KWLajo2IyudT0PcoUnR/gH84kedbsfe30rj3Wc+6Q="));

        public static void Add(string key, string value)
        {
            multiplexer.Value.GetDatabase().StringSet(key, value);
        }

        public static bool TryGet(string key, out string value)
        {
            value = multiplexer.Value.GetDatabase().StringGet(key);
            return !string.IsNullOrEmpty(value);
        }
    }
}