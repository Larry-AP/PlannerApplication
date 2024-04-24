using Microsoft.EntityFrameworkCore;
using PlannerApplication.Models;
using PlannerApplication.Data;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Configuring DI
        builder.Services.AddTransient<IUser, User>();
        builder.Services.AddTransient<IChecklist, Checklist>();
        builder.Services.AddTransient<IEvent, Event>();
        builder.Services.AddTransient<IReminders, Reminders>();

        // Configuring DI
        // builder.Services.AddTransient<I>
        
        // Add EF Core DI
        builder.Services.AddDbContext<PlannerApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PlannerApplicationDbContext")));

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
