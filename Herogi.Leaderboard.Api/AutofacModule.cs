using System;
using Autofac;
using Autofac.Core;
using Herogi.Leaderboard.Data;
using Herogi.Leaderboard.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Herogi.Leaderboard.Api
{
    public class AutofacModule : Module
    {
        private IConfiguration _configuration;
        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).WithParameter(
         new ResolvedParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "connectionString",
           (pi, ctx) => _configuration["ConnectionString"]))
           .WithParameter(
         new ResolvedParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "dataBaseName",
           (pi, ctx) => _configuration["DatabaseName"]));

            builder.RegisterType<MyService>().As<IService>();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
        }
    }
}

