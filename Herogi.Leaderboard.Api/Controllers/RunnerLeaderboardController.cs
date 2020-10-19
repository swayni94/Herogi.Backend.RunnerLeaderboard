using System.Collections.Generic;
using Herogi.Leaderboard.Api.Helper;
using Herogi.Leaderboard.Api.Model;
using Herogi.Leaderboard.Service;
using Microsoft.AspNetCore.Mvc;

namespace Herogi.Leaderboard.Api.Controllers
{
    public class RunnerLeaderboardController : BaseController
    {
        private IService _service;


        public RunnerLeaderboardController(IService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult CreateTablos()
        {
            var info = new InfoList();
            List<InfoModel> models = info.addList();
            if (models == null)
            {
                return BadRequest("false");
            }

            for(int i = 0; i< models.Count;i++)
            {
                _service.AddUserAndPace(models[i].id, models[i].username, models[i].age, models[i].total_time, models[i].distance);
            }
            return Ok("true");
        }

        [HttpPost]
        public IActionResult CreateTablosNewUser([FromBody] InfoModel model)
        {
            if (model == null)
            {
                return BadRequest("false");
            }

            var (user, errorMessage) = _service.AddUserAndPace(model.id, model.username, model.age, model.total_time, model.distance);

            if (user)
            {
                return Ok("true");
            }

            return BadRequest(errorMessage);
        }

        [HttpPost]
        public IActionResult GetAgeGroupList()
        {
            var (retval, errormessage) = _service.GroupAgeList();

            if (!string.IsNullOrEmpty(errormessage))
            {
                return BadRequest(errormessage);
            }
            /*ViewData["GetAgeGroupList"] = retval;
            return View();*/
            return Ok(retval);
        }

        [HttpPost]
        public IActionResult GetAvgPaceList()
        {
            var (retval, errormessage) = _service.UserAvgPaceList();
            if (!string.IsNullOrEmpty(errormessage))
            {
                return BadRequest(errormessage);
            }
            return Ok(retval);
        }

        [HttpPost]
        public IActionResult GetTotalTimeList()
        {
            var (retval, errormessage) = _service.UserTotalTimeList();
            if (!string.IsNullOrEmpty(errormessage))
            {
                return BadRequest(errormessage);
            }
            return Ok(retval);
        }

        [HttpPost]
        public IActionResult GetDistanceList()
        {
            var (retval, errormessage) = _service.UserDistanceList();
            if (!string.IsNullOrEmpty(errormessage))
            {
                return BadRequest(errormessage);
            }
            return Ok(retval);
        }


    }
}
