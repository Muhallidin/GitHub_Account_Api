using GitHubCloudStaff.Application.Common;
using GitHubCloudStaff.Application.Common.GidHub;
using GitHubCloudStaff.Application.Common.Interface;
using GitHubCloudStaff.Application.Queries;
using GitHubCloudStaff.Application.Users.Action;
using GitHubCloudStaff.Application.ViewModel;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GitHubCloudStaff.Application.Users.Handlers
{
    public class GetGitHubUserHandler : IRequestHandler<GetGitHubUserQuery, IList<UserProfileVm>>
    {
        private IMemoryCache _cache;
        private readonly IApplicationSettings _applicationSettings;
        public GetGitHubUserHandler(IMemoryCache cache,  IOptions<ApplicationSettings>  applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;
            _cache = cache;
            //_webRequest = WebRequest.Create(_applicationSettings.ByUser) as HttpWebRequest;
        }
        public async Task<IList<UserProfileVm>> Handle(GetGitHubUserQuery request, CancellationToken cancellationToken)
        {
           
            var result = await Task.Run(() =>
            {
                return FetchGitHubUser.GetGitHubUser(_applicationSettings, _cache);
            }) ;

            return result;

        } 
    }
}
