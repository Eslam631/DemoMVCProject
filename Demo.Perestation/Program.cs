using Demo.Business.Profiles;
using Demo.Business.Services.AttachmentServices;
using Demo.Business.Services.DepartmentSevices;
using Demo.Business.Services.EmployeeServices;
using Demo.Data.Access.Data.Context;
using Demo.Data.Access.Models.IdentityModel;
using Demo.Data.Access.Repositories.DepartmentRepo;
using Demo.Data.Access.Repositories.EmployeeRepo;
using Demo.Data.Access.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Perestation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(Option =>
            {
                Option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

            });
            builder.Services.AddDbContext<ApplicationDbContext>(Option =>
            { Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                Option.UseLazyLoadingProxies();
            });

            builder.Services.AddAutoMapper(E => E.AddProfile(new MappingProfiles()));
            
            //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
          

            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
