using System.Net;
using System.Net.Http.Headers;
using Scan2Dine.Mvc.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(name: "Scan2Dine.WebApi",
    configureClient: options =>
    {
        options.DefaultRequestVersion = HttpVersion.Version30;
        options.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;

        options.BaseAddress = new Uri("http://localhost:5215/");
        options.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(
                mediaType: "application/json", quality: 1.0));
    });

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession(); // Enable Session
app.UseMiddleware<AuthMiddleware>(); // enable authentication middleware

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=ProductList}");

app.Run();