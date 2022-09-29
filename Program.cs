using BookCatalog.Data;
using BookCatalog.Repositories;
using BookCatalog.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var defaultConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(c => c.UseSqlServer(defaultConnectionString));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<BookRepository>();

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
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
