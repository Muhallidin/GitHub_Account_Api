using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHubCloudStaff.Application.Queries;
using GitHubCloudStaff.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubCloudStaff.Api.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public async Task<IList<UserProfileVm>> Get()
        {
            return await Mediator.Send(new GetGitHubUserQuery());
        }
 
        [HttpGet]
        [Route("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var result = await Mediator.Send(new GetGitHubUsernameQuery { UserName = username });
            if (result.Count > 0)
                return Ok(result);
            else
                return NotFound("[No user found...]");
            
        }
    }
}
