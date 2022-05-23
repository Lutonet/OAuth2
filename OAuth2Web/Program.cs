using Serilog;
using Serilog.Configuration;
using Microsoft.OpenApi.Models;
using OAuth2I18n.Middlewares;
using OAuth2I18n.Services;
using OAuth2I18n.Models;
using OAuth2DataAccess.DataAccess;
using OAuth2Identity.Controlers;
using OAuth2DataAccess.SQLAccess;
using AutoMapper;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using OAuth2DataAccess.Models;
using System.Reflection;
using OAuth2Web.Models;
using OAuth2Identity.Models;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserModel, UserPublicModel>();
    cfg.CreateMap<RegisterModel, IdentityUser>();
});

var mapper = config.CreateMapper();

var builder = WebApplication.CreateBuilder(args);
I18nConfigurationModel I18nSettings = await new I18nSettingsController().Load();
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration));
// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddSingleton(mapper);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton(I18nSettings);
builder.Services.AddSingleton<I18nMiddleware>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddTransient<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddTransient<IUserData, UserData>();
builder.Services.AddTransient<IChecksData, ChecksData>();
builder.Services.AddTransient<IPasswordTools, PasswordTools>();
builder.Services.AddTransient<IEncrypt, Encrypt>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}
app.UseHsts();
app.UseMiddleware<I18nMiddleware>();

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});

app.UseSwaggerUI();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapRazorPages();

app.Run();