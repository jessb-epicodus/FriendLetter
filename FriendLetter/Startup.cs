// import built-in .NET namespaces that are required for creating a web application
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FriendLetter
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)  //  constructor will create an iteration of the Startup class that contains specific settings and variables to run our project successfully
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }
    public IConfigurationRoot Configuration { get; }  // this is part of adding custom configurations to our project
    public void ConfigureServices(IServiceCollection services)  //  required built-in method used to set up an application's server
    {
      services.AddMvc();
    }
    public void Configure(IApplicationBuilder app)  //  states which area of our application should load by default when it launches
    {
      app.UseDeveloperExceptionPage();  // error when Razor template engine fails to load
      app.UseRouting();
      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });  // homepage
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }
}