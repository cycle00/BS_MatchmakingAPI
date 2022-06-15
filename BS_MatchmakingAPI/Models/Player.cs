namespace BS_MatchmakingAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int MMR { get; set; }

        public Player(int id, int mmr)
        {
            Id = id;
            MMR = mmr;
        }
    }
}
