using System;
using System.Collections.Generic;
using Herogi.Leaderboard.Api.Model;

namespace Herogi.Leaderboard.Api.Helper
{
    public class InfoList
    {
        public InfoList()
        {
        }

        public List<InfoModel> addList()
        {
            var retval = new List<InfoModel>();
            retval.Add(new InfoModel(1, "user1", 24, 25, 5000));
            retval.Add(new InfoModel(2, "ahmet", 21, 24, 4800));
            retval.Add(new InfoModel(3, "yunus", 28, 28, 6000));
            retval.Add(new InfoModel(4, "null", 20, 40, 10000));
            retval.Add(new InfoModel(5, "john", 34, 12, 2000));
            retval.Add(new InfoModel(6, "adam", 31, 42, 10000));
            retval.Add(new InfoModel(7, "brian", 41, 20, 5000));
            retval.Add(new InfoModel(8, "tyler", 26, 21, 5000));
            retval.Add(new InfoModel(9, "ceren", 35, 30, 5000));
            retval.Add(new InfoModel(10, "hasan", 43, 22, 5000));
            retval.Add(new InfoModel(11, "selen", 29, 30, 6000));
            retval.Add(new InfoModel(12, "diana", 45, 28, 4500));
            retval.Add(new InfoModel(13, "thomas", 44, 18, 5000));
            retval.Add(new InfoModel(14, "james", 39, 60, 10000));
            retval.Add(new InfoModel(15, "janet", 36, 45, 8000));


            return retval;
        }
    }
}
