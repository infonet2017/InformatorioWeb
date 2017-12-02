using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoNET_LocalDB.Models;
using Microsoft.EntityFrameworkCore;
using ProyectoNET_LocalDB.Extra_Models;

namespace ProyectoNET_LocalDB
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

            var connection = @"Server=(localdb)\mssqllocaldb;Database=InfoDb;Trusted_Connection=True;";
            services.AddDbContext<InfoDbContext>(options => options.UseSqlServer(connection));

            var sqlConnectionString = @"Server=(localdb)\mssqllocaldb;database=WebApiFileTable;Trusted_Connection=True;";

            services.AddDbContext<InfoDbContext>(options => options.UseSqlServer(sqlConnectionString, b => b.MigrationsAssembly("ProyectoNET-LocalDB")));

            services.AddMvc();

            services.AddScoped<FileRepository, FileRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Modules}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "edit",
                    template: "{controller=Modules}/{action=Index}/{id?}/{description?}/{note?}");
            });
        }
    }
}
