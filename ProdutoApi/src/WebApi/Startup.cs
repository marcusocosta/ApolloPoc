using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Produto;
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
      services.AddAutoMapper(cfg => cfg.CreateMap<ProdutoModel, Produto>());
      services.AddAutoMapper(cfg => cfg.AddProfile<ProdutoProfile>());

      Action<DataBaseConnectionParams> DataBaseparams = (opt =>
      {
        opt.ConnectionUrl = Configuration["ConnectionURL"];
        opt.DataBaseName = Configuration["DataBase:Name"];
        opt.ProdutoCollection = Configuration["DataBase:Collections:Produto"];
      });
      services.Configure(DataBaseparams);
      services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<DataBaseConnectionParams>>().Value);

      services.AddScoped<IProdutoService, ProdutoService>();
      services.AddScoped<IProdutoRepository, ProdutoRepository>();


      services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

      services.AddScoped<IDocumentExecuter, DocumentExecuter>();
      services.AddScoped<IDocumentWriter, DocumentWriter>();

      services.AddScoped<ProdutoQuery>();
      services.AddScoped<ProdutoMutation>();
      services.AddScoped<ProdutoType>();
      services.AddScoped<ProdutoInputType>();
      services.AddScoped<ISchema, ProdutoSchema>();

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
