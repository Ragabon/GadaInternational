using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Gada.Accounts;
using Gada.Accounts.Repositories;
using Gada.Discussions;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using Gada.Infrastructure.Data.Dapper.Repositories.Accounts;
using Gada.Infrastructure.Data.Dapper.Repositories.Discussions;
using Gada.Infrastructure.Data.Dapper.Repositories.Interests;
using Gada.Infrastructure.Data.Dapper.Repositories.Skills;
using Gada.Infrastructure.Data.Dapper.Repositories.Usage;
using Gada.Infrastructure.Data.EntityFramework;
using Gada.Infrastructure.Data.EntityFramework.Skills;
using Gada.Interests;
using Gada.Interests.Entities;
using Gada.Interests.Repositories;
using Gada.News.Services;
using Gada.Services.RssReader.Services;
using Gada.Services.Twitter.Services;
using Gada.Skills;
using Gada.Skills.Entities;
using Gada.Skills.Repositories;
using Gada.Twitter.Services;
using Gada.Usage;
using Gada.Usage.Entities;
using Gada.Usage.Repositories;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gada.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(m => new SkillsContext()).As<ISkillsContext>();
            builder.Register(m => new InterestsContext()).As<IInterestsContext>();
            builder.Register(m => new AccountsContext()).As<IAccountsContext>();
            builder.Register(m => new SkillCategoriesRepository()).As<ISkillCategoriesRepository<SkillCategory>>();
            builder.Register(m => new InterestCategoriesRepository()).As<IInterestCategoriesRepository<InterestCategory>>();
            builder.Register(m => new SkillsRepository()).As<ISkillsRepository<Skill>>();
            builder.Register(m => new InterestsRepository()).As<IInterestsRepository<Gada.Interests.Entities.Interest>>();
            builder.Register(m => new AccountsRepository()).As<IAccountsRepository<Gada.Accounts.Entities.User>>();
            builder.Register(m => new DiscussionsContext()).As<IDiscussionsContext>();
            builder.Register(m => new DiscussionRepository()).As<IDiscussionRepository<Discussion>>();
            builder.Register(m => new PostRepository()).As<IPostRepository<Post>>();
            builder.Register(m => new AreasRepository()).As<IAreasRepository<Area>>();
            builder.Register(m => new UsersRepository()).As<IUsersRepository<User>>();
            builder.Register(m => new UsageContext()).As<IUsageContext>();
            builder.Register(m => new LogRepository()).As<ILogRepository<Log>>();
            builder.Register(m => new LogTypeRepository()).As<ILogTypeRepository<LogType>>();
            builder.Register(m => new RssReaderService()).As<IRssReaderService>();
            builder.Register(m => new TwitterService()).As<ITwitterService>();
            builder.RegisterType<MappingEngine>().As<IMappingEngine>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            // web api configuration
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
             new CamelCasePropertyNamesContractResolver();

            app.UseWebApi(config);
        }
    }
}