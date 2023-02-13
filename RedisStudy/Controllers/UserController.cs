using Microsoft.AspNetCore.Mvc;

using StackExchange.Redis;

namespace RedisStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConnectionMultiplexer _redis;

        public const byte REDIS_DATABASE_NUMBER = 1;
        public UserController(ILogger<UserController> logger, IConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
        }


        #region GET

        /// <summary>
        /// 회원 목록을 조회합니다.
        /// </summary>
        /// <param name="db_key">Redis key</param>
        [HttpGet]
        [Route("user")]
        public void GetUsers(string db_key)
        {
            var db = _redis.GetDatabase(REDIS_DATABASE_NUMBER);
            db.StringGet(db_key);

        }

        #endregion

        #region POST

        /// <summary>
        /// 회원 정보를 등록합니다. 
        /// </summary>
        /// <param name="key">사용할 db key</param>
        /// <param name="value">db에 추가하려는 value</param>
        [HttpPost]
        [Route("user")]
        public void PostUserInfo(string key, string value)
        {
            var db = _redis.GetDatabase(REDIS_DATABASE_NUMBER);
            db.StringSet(key, value);
        }

        #endregion
    }
}