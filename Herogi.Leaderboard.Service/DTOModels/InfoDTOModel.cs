using System;
namespace Herogi.Leaderboard.Service.DTOModels
{
    public class InfoDTOModel : BaseDTOModel
    {
        public string username { get; set; }
        public int age { get; set; }
        public int total_time { get; set; }
        public int distance { get; set; }
        public double avgpace { get; set; }
    }
}
