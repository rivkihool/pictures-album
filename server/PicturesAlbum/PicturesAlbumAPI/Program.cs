using Microsoft.EntityFrameworkCore;
using PicturesAlbum.Infrastructure.Data;
using PicturesAlbum.Core.Interfaces;
using PicturesAlbum.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// here add the-DbContext:
builder.Services.AddDbContext<PictureDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddControllers();

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

app.UseCors("AllowReactApp");

app.UseAuthorization();
app.MapControllers();

app.Run();



