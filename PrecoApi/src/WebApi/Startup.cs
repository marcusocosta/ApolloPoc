using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Preco;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Respository;
using Respository.Models;
using Respository.Parametros;
using Respository.Profiles;
using Service;
using WebApi.Models.Graphql;
using WebApi.Queries;

namespace WebApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper(cfg => cfg.CreateMap<PrecoModel, Preco>());
      services.AddAutoMapper(cfg => cfg.AddProfile<PrecoProfile>());

      Action<DataBaseConnectionParams> DataBaseparams = (opt =>
      {
        opt.ConnectionUrl = Configuration["ConnectionURL"];
        opt.DataBaseName = Configuration["DataBase:Name"];
        opt.PrecoCollection = Configuration["DataBase:Collections:Preco"];
      });
      services.Configure(DataBaseparams);
      services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value);

      services.AddScoped<IPrecoService, PrecoService>();
      services.AddScoped<IPrecoRepository, PrecoRepository>();


      services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

      services.AddScoped<IDocumentExecuter, DocumentExecuter>();
      services.AddScoped<IDocumentWriter, DocumentWriter>();

      services.AddScoped<PrecoQuery>();
      services.AddScoped<PrecoMutation>();
      services.AddScoped<PrecoType>();
      services.AddScoped<PrecoInputType>();
      services.AddScoped<ISchema, PrecoSchema>();

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddGraphQL(_ =>
      {
        _.EnableMetrics = true;
        _.ExposeExceptions = true;
      });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole();
      app.UseDeveloperExceptionPage();

      // add http for Schema at default url /graphql
      app.UseGraphQL<ISchema>("/graphql");

      // use graphql-playground at default url /ui/playground
      app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
      {
        Path = "/ui/playground"
      });
    }
  }
}
