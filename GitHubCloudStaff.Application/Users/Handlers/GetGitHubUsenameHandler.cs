using GitHubCloudStaff.Application.Common;
using GitHubCloudStaff.Application.Common.GidHub;
using GitHubCloudStaff.Application.Common.Interface;
using GitHubCloudStaff.Application.Queries;
using GitHubCloudStaff.Application.Users.Action;
using GitHubCloudStaff.Application.ViewModel;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubCloudStaff.Application.Users.Handlers
{
    public class GetGitHubUsenameHandler : IRequestHandler<GetGitHubUsernameQuery, IList<UserProfileVm>>
    {
        private IMemoryCache _cache;
        private readonly IApplicationSettings _applicationSettings;
        public GetGitHubUsenameHandler(IMemoryCache cache, IOptions<ApplicationSettings> applicationSettings)
        {
            _cache = cache;
            _applicationSettings = applicationSettings.Value;

        }
        public async Task<IList<UserProfileVm>> Handle(GetGitHubUsernameQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.Run(() =>
            {
              

                return FetchGitHubUser.GetGitHubUserDetail(_applicationSettings, _cache, request.UserName);
            });
            return result;

        }
    }
}
