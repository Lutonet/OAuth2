using AutoMapper;
using Microsoft.Extensions.Localization;
using OAuth2DataAccess.DataAccess;
using OAuth2DataAccess.Models;
using OAuth2DataAccess.SQLAccess;
using OAuth2I18n.Middlewares;
using OAuth2I18n.Models;
using OAuth2I18n.Services;
using OAuth2Identity;
using OAuth2Identity.Controlers;
using OAuth2Identity.Models;
using OAuth2Identity.Services;
using OAuth2Web.Helpers;
using OAuth2Web.Models;
using Serilog;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserModel, UserPublicModel>();
    cfg.CreateMap<RegisterModel, IdentityUser>();
});

var mapper = config.CreateMapper();

var builder = WebApplication.CreateBuilder(args);
I18nConfigurationModel I18nSettings = await new I18nSettingsController().Load();
IdentityConfiguration IdentityConfiguration = await new IdentitySettingsController().Load();
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration));
// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddSingleton(mapper);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddLocalization();
builder.Services.AddSingleton(I18nSettings);
builder.Services.AddSingleton(IdentityConfiguration);
builder.Services.AddTransient<I18nMiddleware>();
builder.Services.AddTransient<IStringLocalizerFactory, JsonStringLocalizerFactory>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ISQLDataAccess, SQLDataAccess>();
builder.Services.AddTransient<IUserHelpers, UserHelpers>();
builder.Services.AddSingleton<IUserData, UserData>();

builder.Services.AddTransient<IUserService, UserService>();

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

app.UseRequestLocalization();
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