using GitHubCloudStaff.Application.ViewModel;
using MediatR;
using System.Collections.Generic;

namespace GitHubCloudStaff.Application.Queries
{
    public class GetGitHubUserQuery :  IRequest<IList<UserProfileVm>> { }
}
