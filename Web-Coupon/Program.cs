using CouponAPI.Models.DTOs;
using CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Web_Coupon.Controllers;
using Web_Coupon.Models;
using Web_Coupon.Services;

namespace Web_Coupon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
            builder.Services.AddScoped<ICouponService, CouponService>();			
			builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            
            StaticDetails.CouponApiBase = builder.Configuration["ServiceUrls:SUT23CouponAPI"];

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
