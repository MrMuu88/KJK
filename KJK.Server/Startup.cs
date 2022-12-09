using KJK.Data;
using KJK.Server.Configurations;
using KJK.Server.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace KJK.Server
{
	public class Startup
	{
		private static OpenApiSecurityScheme SecurityScheme = new OpenApiSecurityScheme
		{
			In = ParameterLocation.Header,
			Description = "Please enter a vaild Token",
			Name = "Authorization",
			Type = SecuritySchemeType.Http,
			BearerFormat = "JWT",
			Scheme = "Bearer"
		};

		private static OpenApiSecurityRequirement SecurityRequirement = new OpenApiSecurityRequirement {
			{ new OpenApiSecurityScheme{
				Reference = new OpenApiReference
				{
					Type= ReferenceType.SecurityScheme,
					Id= "Bearer"
				}
			}, new string[0]}
		};

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

				c.AddSecurityDefinition("Bearer",SecurityScheme);

				c.AddSecurityRequirement(SecurityRequirement);
			});

			services.Configure<JwtConfiguration>(Configuration.GetSection("JwtConfiguration"));

			services.AddAuthentication(o => {
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = Configuration["JwtConfiguration:Issuer"],
					ValidAudience = Configuration["JwtConfiguration:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfiguration:Key"])),
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true
                };
			});

			services.AddAuthorization();
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

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseMiddleware<ExceptionMiddleware>();
			app.UseMiddleware<LoggerMiddleware>();
			
		}
    }
}
