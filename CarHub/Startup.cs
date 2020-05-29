using AutoMapper;
using CarHub.Data;
using CarHub.Data.Repositories;
using CarHub.Data.Repositories.Interfaces;
using CarHub.Domain.Services;
using CarHub.Domain.Services.Interfaces;
using CarHub.Domain.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarHub
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IBodyTypeRepository, BodyTypeRepository>();
            services.AddTransient<ICarModelRepository, CarModelRepository>();
            services.AddTransient<ICarMakeRepository, CarMakeRepository>();
            services.AddTransient<ITrimRepository, TrimRepository>();
            services.AddTransient<IFuelTypeRepository, FuelTypeRepository>();
            services.AddTransient<IDriveTypeRepository, DriveTypeRepository>();
            services.AddTransient<IPurchaseTypeRepository, PurchaseTypeRepository>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryStatusRepository, InventoryStatusRepository>();
            services.AddTransient<IRepairRepository, RepairRepository>();
            services.AddTransient<IMediaRepository, MediaRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<InventoryViewModelValidator>());
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var enAUCulture = new CultureInfo("en-AU");
            var localizationOptions = new RequestLocalizationOptions()
            {
                SupportedCultures = new List<CultureInfo>() { enAUCulture },
                DefaultRequestCulture = new RequestCulture(enAUCulture),
                FallBackToParentCultures = false,
                FallBackToParentUICultures = false,
                RequestCultureProviders = null
            };

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
