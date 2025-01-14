using Automaton.Common.Auth;
using Automaton.Common.Extensions;
using Automaton.Studio.Areas.Identity;
using Automaton.Studio.Data;
using Automaton.Studio.Extensions;
using Automaton.Studio.Hubs;
using Automaton.Studio.Services;
using Automaton.Studio.ViewModels;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Automaton.Studio.DragDrop;
using System;
using System.Linq;
using System.Net.Mime;
using System.Reflection;

namespace Automaton.Studio
{
    public class Startup
    {
        private const string DatabaseConnection = "DefaultConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddRedis();
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>()
                .AddDbContextCheck<AutomatonDbContext>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(DatabaseConnection)));

            services.AddDbContext<AutomatonDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(DatabaseConnection)));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Token Authentication
            services.AddJwtAuthentication();

            // SignalR
            services.AddSignalR();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            // Ant Design
            services.AddAntDesign();

            // Blazor Drag & Drop
            services.AddBlazorDragDrop();

            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Elsa
            services.AddElsa(options => options
                .UseEntityFrameworkPersistence(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    db => db.MigrationsAssembly(typeof(SqlServerElsaContextFactory).Assembly.GetName().Name)), false)
                .AddElsaActivities()
            )
            .AddElsaApiEndpoints()
            .AddElsaSwagger();

            // ViewModels
            services.AddScoped<IMainLayoutViewModel, MainLayoutViewModel>();
            services.AddScoped<IWorkflowsViewModel, WorkflowsViewModel>();
            services.AddScoped<IDesignerViewModel, DesignerViewModel>();
            services.AddScoped<ITreeActivityViewModel, TreeActivityViewModel>();

            // Services
            services.AddScoped<IWorkflowService, WorkflowService>();
            services.AddScoped<IRunnerService, RunnerService>();

            // Automaton
            services.AddAutomaton();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // SignalR
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elsa"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseHealthChecks("/health");
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapHub<WorkflowHub>("/workflowhub");
                endpoints.MapFallbackToPage("/_Host");
            });

            #region Healthchecks

            var healthCheckOptions = new HealthCheckOptions();
            healthCheckOptions.ResultStatusCodes[HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable;

            healthCheckOptions.ResponseWriter = async (ctx, rpt) =>
            {
                var result = JsonConvert.SerializeObject(new
                {
                    Status = rpt.Status.ToString(),
                    Errors = rpt.Entries.Select(e => new
                    { key = e.Key, value = Enum.GetName(typeof(HealthStatus), e.Value.Status) })
                }, Formatting.None, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                ctx.Response.ContentType = MediaTypeNames.Application.Json;
                await ctx.Response.WriteAsync(result);
            };

            app.UseHealthChecks("/health", healthCheckOptions);

            #endregion
        }
    }
}
