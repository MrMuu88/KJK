using KJK.Data;
using KJK.Server.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KJK.Server
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
			
			services.AddDbContext<KJKDbContext>(options=> options.UseSqlServer(Configuration.GetConnectionString("KJKDB")));
			services.AddSwaggerGen(c=> {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "KJK Api", Version = "v1" });
				c.IncludeXmlComments(@".\KJK.Server.xml"); 
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

	#if !DEBUG
			app.UseHttpsRedirection();
	#endif
			
			app.UseSwagger();
			app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "KJK Api"));

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseMiddleware<ExceptionMiddleware>();
			app.UseMiddleware<LoggerMiddleware>();
			
		}
	}
}
