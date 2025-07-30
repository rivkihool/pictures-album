using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Infrastructure.Data;
using PicturesAlbum.Core.Interfaces;
using PicturesAlbum.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// ��� ������� �� �-DbContext:
builder.Services.AddDbContext<PictureDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddControllers();

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
