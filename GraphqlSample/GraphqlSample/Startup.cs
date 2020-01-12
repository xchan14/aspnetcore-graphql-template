using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphqlSample.GraphQLModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphqlSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<GqlSampleMutation>();
            services.AddSingleton<GqlSampleQuery>();
            services.AddSingleton<ItemType>();

            var sp = services.BuildServiceProvider();
            var gqlResolver = new FuncDependencyResolver(type => sp.GetService(type));
            var gqlSchema = new GqlSampleSchema(gqlResolver);
            services.AddSingleton<GraphQL.Types.ISchema>(gqlSchema);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseGraphiQLServer(new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions
                {
                   GraphQLEndPoint = "/api/graphql" 
                });
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
