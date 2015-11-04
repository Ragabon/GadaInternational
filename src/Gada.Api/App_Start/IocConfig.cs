using Autofac;
using Autofac.Integration.WebApi;
using Gada.Discussions;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using Gada.Infrastructure.Data.Dapper.Repositories;
using Gada.Infrastructure.Data.Dapper.Repositories.Discussions;
using Gada.Infrastructure.Data.EntityFramework;
using Gada.News.Services;
using Gada.Services.RssReader.Services;
using System.Reflection;
using System.Web.Http;
using Gada.Services.Twitter.Services;
using Gada.Twitter.Services;
using Gada.Infrastructure.Data.Dapper.Repositories.Accounts;
using Gada.Skills.Entities;
using Gada.Accounts.Repositories;
using Gada.Infrastructure.Data.Dapper.Repositories.Interests;
using Gada.Interests.Repositories;
using Gada.Skills.Repositories;

namespace Gada.Api.App_Start
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);
            
            //builder.Register(m => new SkillsRepository()).As<ISkillsRepository<Skill>>();
            builder.Register(m => new DiscussionsContext()).As<IDiscussionsContext>();
            builder.Register(m => new DiscussionRepository()).As<IDiscussionRepository<Discussion>>();
            builder.Register(m => new PostRepository()).As<IPostRepository<Post>>();
            builder.Register(m => new InterestsRepository()).As<IInterestsRepository<Interest>>();
            builder.Register(m => new AreasRepository()).As<IAreasRepository<Area>>();
            builder.Register(m => new UsersRepository()).As<IUsersRepository<User>>();
            builder.Register(m => new RssReaderService()).As<IRssReaderService>();
            builder.Register(m => new TwitterService()).As<ITwitterService>();
            
            AutoMapperConfig.RegisterMappings(builder);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}