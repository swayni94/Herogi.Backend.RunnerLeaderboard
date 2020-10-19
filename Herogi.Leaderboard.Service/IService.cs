using System;
using System.Collections.Generic;
using Herogi.Leaderboard.Service.DTOModels;

namespace Herogi.Leaderboard.Service
{
    public interface IService
    {
        (bool, string) AddUserAndPace(int _id, string _username, int _age, int _total_time, int _distance);
        (List<List<InfoDTOModel>>, string) GroupAgeList();
        (List<InfoDTOModel>, string) UserAvgPaceList();
        (List<InfoDTOModel>, string) UserTotalTimeList();
        (List<InfoDTOModel>, string) UserDistanceList();
    }
}
