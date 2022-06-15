using System.Collections.Generic;

namespace BS_MatchmakingAPI.Models
{
    public class Queue
    {
        public int Count { get; set; } = 0;
        public int LowestMissingID { get; set; } = 0;
        public List<Player> Ids { get; set; } = new List<Player>();

    }
}
