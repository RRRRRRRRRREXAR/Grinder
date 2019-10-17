using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grinder.BLL.Interfaces;
using Grinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        IMapper mapper;
        IFindService findService;
        public SearchController(IMapper mapper, IFindService findService)
        {
            this.findService = findService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FindModel>> Get(FindModel query)
        {
            return mapper.Map<IEnumerable<FindModel>>(await findService.GetUsersBy(d => d.FirstName == query.FirstName && d.LastName == query.LastName && d.IsAnonymous ==false));
        }
        [HttpPost]
        public async Task<IEnumerable<FindModel>> Post(FindModel query)
        {
            return mapper.Map<IEnumerable<FindModel>>(await findService.GetUsersBy(d=>d.FirstName==query.FirstName && d.LastName==query.LastName && d.MeetGoal==d.MeetGoal && d.Other==d.Other && d.IsOnline==query.IsOnline && d.Interests==d.Interests && d.BirthDate==d.BirthDate));
        }
    }
}