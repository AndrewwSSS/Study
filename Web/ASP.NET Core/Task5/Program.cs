using Microsoft.EntityFrameworkCore;
using Task5.Pages.Entities;

var builder = WebApplication.CreateBuilder(args);



string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FilmsContext>(options => options.UseSqlServer(connection));


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();