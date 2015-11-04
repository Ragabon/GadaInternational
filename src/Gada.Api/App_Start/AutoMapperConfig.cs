using System;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Autofac;
using System.Linq;
using AutoMapper.Mappers;
using Gada.Api.AutoMappings;

namespace Gada.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings(ContainerBuilder builder)
        {
            //var profiles =
            //AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(GetProfileTypes)
            //    .Where(t => t != typeof(Profile) && typeof(Profile).IsAssignableFrom(t));
            //foreach (var profile in profiles)
            //{
            //    Mapper.Configuration.AddProfile((Profile)Activator.CreateInstance(profile));
            //}

            builder.RegisterType<MappingEngine>().As<IMappingEngine>();

            builder.Register(m => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivating(x =>
                {
                    foreach (var profile in x.Context.Resolve<IEnumerable<Profile>>())
                    {
                        x.Instance.AddProfile(profile);
                    }
                });
        }

        private static IEnumerable<Type> GetProfileTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}