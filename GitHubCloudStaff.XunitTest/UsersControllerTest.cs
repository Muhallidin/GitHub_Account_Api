

 
using GitHubCloudStaff.Application.Common.GidHub;
using GitHubCloudStaff.Application.Common.Interface;
using GitHubCloudStaff.Application.Users.Action;
using GitHubCloudStaff.Application.ViewModel;
using GitHubCloudStaff.XunitTest.Common;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Newtonsoft.Json;
using StructureMap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GitHubCloudStaff.XunitTest
{
    public class UsersControllerTest
    {

        public class GetGitHubUserQuery : IRequest<IList<UserProfileVm>> { }
        public class GetGitHubUserHandler : IRequestHandler<GetGitHubUserQuery, IList<UserProfileVm>>
        {
            private HttpWebRequest _webRequest;
            public GetGitHubUserHandler()
            {
                //  __cache = cache;
                _webRequest = WebRequest.Create("https://api.github.com/users") as HttpWebRequest;
            }
            public async Task<IList<UserProfileVm>> Handle(GetGitHubUserQuery request, CancellationToken cancellationToken)
            {

                var result = await Task.Run(() =>
                {
                    IMemoryCache __cache = new MemoryCache(new MemoryCacheOptions());
                    IList<GitHudUserList> user = new List<GitHudUserList>();
 
                    if (user == null)
                    {
                        if (_webRequest != null)
                        {
                            _webRequest.Method = "GET";
                            _webRequest.UserAgent = "Anything";
                            _webRequest.ServicePoint.Expect100Continue = false;
                            try
                            {
                                using (StreamReader responseReader = new StreamReader(_webRequest.GetResponse().GetResponseStream()))
                                {
                                    string reader = responseReader.ReadToEnd();
                                    user = JsonConvert.DeserializeObject<List<GitHudUserList>>(reader);
                                }
                            }
                            catch
                            {
                                throw;
                            }
                        }
                    }

                    List<UserProfileVm> userProfileVms = new List<UserProfileVm>();
                    GitHubUserDetail usr = new GitHubUserDetail();

                    foreach (GitHudUserList i in user.OrderBy(e => e.login).Take(2))
                    {

                        usr = new GitHubUserDetail(i.login);

                        userProfileVms.Add(new UserProfileVm
                        {
                            Company = usr.Company,
                            Followers = usr.Followers,
                            Login = usr.Login,
                            Name = usr.Name,
                            Repositories = usr.Repositories,
                        });

                    }
                    return userProfileVms;
                });
                return result;
            }
        }


        [Fact]
        public async Task  GetGitHubUser_alphabetical()
        {


            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(UsersControllerTest));
                    scanner.IncludeNamespaceContainingType<GetGitHubUserQuery>();
                    scanner.WithDefaultConventions();
                    scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
                   
                });
                cfg.For<ServiceFactory>().Use<ServiceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<IMediator>().Use<Mediator>();
            });

            var mediator = container.GetInstance<IMediator>();

            var response = await  mediator.Send(new GetGitHubUserQuery());
            var re = response.Select(e => e).OrderBy(e => e.Name);
 
            Assert.Empty(response);
        }

        [Fact]
        public void GetGitHubUser_alphabetical_xunitTest()
        {

            IMock<IMemoryCache> cache = new Mock<IMemoryCache>();
            IMock<IApplicationSettings> applicationSetting = new Mock<IApplicationSettings>();

            applicationSetting.Object.ByUser = "https://api.github.com/users";
            applicationSetting.Object.ByUserDetail = "https://api.github.com/users/";
            applicationSetting.Object.ListCount = "5";

            IList<string> response = FetchGitHubUser.GetGitHubUserTest("https://api.github.com/users", cache.Object).Select(n => n.Name).ToList();
            IList<string> Validation = UserList.GetList().Select(e => e.Name).OrderBy(e => e).ToList();
            Assert.Equal(Validation, response);
 
        }






    }
}
