using Microsoft.AspNetCore.Mvc;

using StackExchange.Redis;

namespace RedisStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameRankController : ControllerBase
    {
        private readonly ILogger<GameRankController> _logger;
        private readonly IConnectionMultiplexer _redis;
        public const byte REDIS_DATABASE_NUMBER = 2;
        public GameRankController(ILogger<GameRankController> logger, IConnectionMultiplexer redis)
        {
            _logger = logger;
            _redis = redis;
        }

        #region GET

        /// <summary>
        /// ���� ��ŷ�� ��ȸ�մϴ�.
        /// </summary>
        /// <param name="db_key">Redis key</param>
        [HttpGet]
        [Route("game-rank")]
        public void GetGameRank(string db_key)
        {
            var db = _redis.GetDatabase(REDIS_DATABASE_NUMBER);
            db.SortedSetScan(db_key);
        }

        #endregion

        #region POST

        /// <summary>
        /// ȸ���� ���� ������ DB�� �߰��մϴ�. 
        /// </summary>
        /// <param name="key">����� db key</param>
        /// <param name="member">ȸ�� ���а�</param>
        /// <param name="score">ȸ���� ����</param>
        [HttpPost]
        [Route("game-rank")]
        public void PostGameRank(string key, string member, UInt64 score)
        {
            var db = _redis.GetDatabase(REDIS_DATABASE_NUMBER);
            db.SortedSetAdd(key, member, score);
        }

        #endregion
    }
}