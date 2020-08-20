using GitHubCloudStaff.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHubCloudStaff.Application.Queries
{
   
    public class GetGitHubUsernameQuery : IRequest<IList<UserProfileVm>>
    {
        public string UserName { get; set; }

    }
}
