using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BS_MatchmakingAPI.Models;

namespace BS_MatchmakingAPI.Controllers
{
    [Route("matchmaking")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        public Queue queue = new Queue();

        [HttpGet("getqueue")]
        public ActionResult<int> GetQueue()
        {
            return queue.Count;
        }

        [HttpGet("joinqueue/{mmr}")]
        public ActionResult<int> JoinQueue(int mmr)
        {
            int id = queue.LowestMissingID++;
            queue.Ids.Add(new Player(id, mmr));
            queue.Count++;
            return id;
        }
        

        [NonAction]
        private async Task<bool> ComparePlayers()
        {
            IEnumerable<(Player, Player)> playerCombos = await GetAllPairs(queue.Ids);
            foreach ((Player p1, Player p2) in playerCombos)
            {

            }
            return false;
        }

        [NonAction]
        private Task<IEnumerable<(T, T)>> GetAllPairs<T>(IList<T> source)
        {
            return Task.FromResult(source.SelectMany((_, i) => source.Where((_, j) => i < j), (x, y) => (x, y)));
        }
    }
}
