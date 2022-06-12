using eTickets.DAL;
using eTickets.DTL;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Post services to the container
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Post DbContext to container
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnectionString"));

// Post Repo
builder.Services.AddScoped<IGenRepo<Actor, int>, GenRepo<Actor, int>>();
builder.Services.AddScoped<IGenRepo<Movie, int>, GenRepo<Movie, int>>();
builder.Services.AddScoped<IGenRepo<Producer, int>, GenRepo<Producer, int>>();
builder.Services.AddScoped<IGenRepo<Cinema, int>, GenRepo<Cinema, int>>();



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
    pattern: "{controller=Movies}/{action=Index}/{id?}");

// Seed Database
AppDbInitializer.Seed(app);

app.Run();
