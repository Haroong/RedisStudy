using StackExchange.Redis;

namespace RedisStudy
{
    public class Redis
    {
        private ConnectionMultiplexer redis;
        private IDatabase db;

        //// Redis connection
        //public bool Init()
        //{
        //    try
        //    {
        //        this.redis = ConnectionMultiplexer.Connect("localhost:6389");
        //        if (redis != null)
        //        {
        //            this.db = redis.GetDatabase();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        // Set string to database
        public bool SetString(string key, string value)
        {
            return this.db.StringSet(key, value);
        }

        // Get string from database
        public string GetString(string key)
        {
            return this.db.StringGet(key);
        }
    }
}