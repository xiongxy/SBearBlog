using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SBear.Entities;
using SBear.Framework.Autofac;
using SBear.Framework.Config;
using SBear.Framework.Middleware;
namespace SBear.Web
{
    public class Startup
    {
        public static ILoggerRepository Repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Repository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
            SBear.Service.SBearMapperInitialize.Initialize();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            services.AddOptions();
            services.Configure<BlogAppSettingConfig>(Configuration.GetSection("BlogAppSetting"));
            //services.AddDbContext<DataContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnectionSqlite")));
            //services.AddDbContext<DataContext>(options=> options.UseMySql(@"Server=127.0.0.1;database=Blogmy;uid=root;pwd=root"));
            services.AddMvc();
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseSBearHttpContextMiddleware();
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRequestMsgMiddleware();
            InitializeDataBase(app.ApplicationServices);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{pageNum?}");
            });
        }

        private void InitializeDataBase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceProvider>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DataContext>();
                db.Database.EnsureCreated();
            }
        }
    }
}
