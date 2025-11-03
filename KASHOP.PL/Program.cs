using KASHOP.BLL.Services.Classes;
using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository.Classes;
using KASHOP.DAL.Repository.Interfaces;
using KASHOP.DAL.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar;
using Scalar.AspNetCore;

namespace KASHOP.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<IBrandRepository,BrandRepository>();
            builder.Services.AddScoped<IBrandService,BrandService>();
            builder.Services.AddScoped<ISeedData,SeedData>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            //Data Seeding Just Once
            var scope = app.Services.CreateScope();
            var ObjectOfSeedData = scope.ServiceProvider.GetRequiredService<ISeedData>();
            await ObjectOfSeedData.DataSeedingAsync();
            await ObjectOfSeedData.IdentityDataSeedingAsync();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
