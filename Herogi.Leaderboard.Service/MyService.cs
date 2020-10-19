using System;
using System.Collections.Generic;
using System.Linq;
using Herogi.Leaderboard.Data;
using Herogi.Leaderboard.Data.Entity;
using Herogi.Leaderboard.Service.DTOModels;
using Microsoft.Extensions.Logging;

namespace Herogi.Leaderboard.Service
{
    public class MyService : IService
    {
        readonly IRepository<User> userRepository;
        readonly IRepository<Pace> paceRepository;
        private ILogger<MyService> logger;
        private Comparison<InfoDTOModel> comparison;

        public MyService(IRepository<User> user, IRepository<Pace> pace, ILogger<MyService> service)
        {
            userRepository = user;
            paceRepository = pace;
            logger = service;
        }

        public (bool, string) AddUserAndPace(int _id, string _username, int _age, int _total_time, int _distance)
        {
            userRepository.AddEntity(new User { Id = _id, username = _username, age = _age });
            paceRepository.AddEntity(new Pace { Id = _id, total_time = _total_time, distance = _distance });

            return (true, string.Empty);
        }

        public (List<List<InfoDTOModel>>, string) GroupAgeList()
        {
            var fulldatas = new List<List<InfoDTOModel>>();
            var term20_30 = new List<InfoDTOModel>();
            var term30_40 = new List<InfoDTOModel>();
            var term40_60 = new List<InfoDTOModel>();
            List<InfoDTOModel> infos = getListFun();

            foreach (var item in infos)
            {
                if (item.age >= 20 && item.age < 30)
                {
                    term20_30.Add(item);
                }
                else if (item.age >= 30 && item.age < 40)
                {
                    term30_40.Add(item);
                }
                else if (item.age >= 40 && item.age <= 60)
                {
                    term40_60.Add(item);
                }
                else { logger.LogError("Age error", "age<20 or age>60"); }
            }

            fulldatas.Add(term20_30);
            fulldatas.Add(term30_40);
            fulldatas.Add(term40_60);

            return (fulldatas, string.Empty);
        }

        public (List<InfoDTOModel>, string) UserAvgPaceList()
        {
            var retval = getListFun();

            comparison = new Comparison<InfoDTOModel>(delegate (InfoDTOModel x, InfoDTOModel y) {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                return x.avgpace != null || y.avgpace != null ? x.avgpace.CompareTo(y.avgpace) : x.avgpace.CompareTo(y.avgpace);
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            });
            retval.Sort(comparison);
            return (retval, string.Empty);
        }

        public (List<InfoDTOModel>, string) UserDistanceList()
        {
            var retval = getListFun();
            comparison = new Comparison<InfoDTOModel>(delegate (InfoDTOModel x, InfoDTOModel y) {
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                return x.distance != null || y.distance != null ? x.distance.CompareTo(y.distance) : x.distance.CompareTo(y.distance);
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            });
            retval.Sort(comparison);

            return (retval, string.Empty);
        }

        public (List<InfoDTOModel>, string) UserTotalTimeList()
        {
            var retval = getListFun();
            var term = new InfoDTOModel();
            for(int i = 0; i < retval.Count-1; i++)
            {
                for(int j=0; j < retval.Count - 1; j++)
                {
                    if(retval[j].total_time > retval[j + 1].total_time)
                    {
                        term = retval[j+1];
                        retval[j + 1] = retval[j];
                        retval[j] = term;
                    }
                }
            }

            return (retval, string.Empty);
        }

        private List<InfoDTOModel> getListFun()
        {
            var datas = new List<InfoDTOModel>();
            

            var users = userRepository.GetList(x=> x.Id != 0).ToList();
            var paces = paceRepository.GetList(x => x.Id != 0).ToList();
            
            for(int i=0;i<users.Count; i++)
            {
                var data = new InfoDTOModel();
                data.id = users[i].Id;
                data.username = users[i].username;
                data.age = users[i].age;
                data.total_time = paces[i].total_time;
                data.distance = paces[i].distance;
                data.avgpace = data.distance / data.total_time;

                datas.Add(data);
            }
            return datas;
        }
    }
}
