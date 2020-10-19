using System;
namespace Herogi.Leaderboard.Api.Model
{
    public class InfoModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public int age { get; set; }
        public int total_time { get; set; }
        public int distance { get; set; }

        public InfoModel(int _i, string _u, int _a, int _t, int _d)
        {
            id = _i;
            username = _u;
            age = _a;
            total_time = _t;
            distance = _d;
        }
    }
}
