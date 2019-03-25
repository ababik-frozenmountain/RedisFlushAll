using StackExchange.Redis;
using System;

namespace RedisFlushAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "127.0.0.1:52009,allowAdmin=true";
            var redis = ConnectionMultiplexer.Connect(connectionString);

            foreach (var endpoint in redis.GetEndPoints())
            {
                var server = redis.GetServer(endpoint);
                server.FlushDatabase();
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
