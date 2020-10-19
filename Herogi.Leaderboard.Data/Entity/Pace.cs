using System;
namespace Herogi.Leaderboard.Data.Entity
{
    public class Pace : BaseEntity
    {
        public int total_time { get; set; }
        public int distance { get; set; }
    }
}
