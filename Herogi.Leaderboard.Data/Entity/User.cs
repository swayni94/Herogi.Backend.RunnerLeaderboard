using System;
namespace Herogi.Leaderboard.Data.Entity
{
    public class User : BaseEntity
    {
        public string username { get; set; }
        public int age { get; set; }
    }
}
