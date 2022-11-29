using BlazingPizza2022.Server.Models;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PizzaStoreContext>();

var app = builder.Build();

var ScopeFactory =
    app.Services.GetRequiredService<IServiceScopeFactory>();
using(var scope = ScopeFactory.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<PizzaStoreContext>();
    if(context.Specials.Count() == 0)
    {
        SeedData.Initialize(context);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
