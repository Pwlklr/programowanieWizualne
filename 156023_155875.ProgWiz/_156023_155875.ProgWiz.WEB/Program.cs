using _156023_155875.ProgWiz.DAOSQL;
using _156023_155875.ProgWiz.INTERFACES;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var dllPath = builder.Configuration["DaoSettings:Path"];
var className = builder.Configuration["DaoSettings:Class"];

var assembly = System.Reflection.Assembly.LoadFrom(dllPath);
var type = assembly.GetType(className);
var daoInstance = Activator.CreateInstance(type) as IDataAccessObject;

builder.Services.AddSingleton(daoInstance);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
