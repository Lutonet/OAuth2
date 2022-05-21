using Serilog;
using Serilog.Configuration;
using Microsoft.OpenApi.Models;
using OAuth2I18n.Middlewares;
using OAuth2I18n.Services;
using OAuth2I18n.Models;

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
I18nConfigurationModel I18nSettings = await new I18nSettingsController().Load();
// Add services to the container.
builder.Services.AddMvcCore()
    .AddApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<I18nMiddleware>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddLogging();
builder.Services.AddSingleton(I18nSettings);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Lutonet OAuth2 API",
        Description = "Api documentation for the Authenticator",
        TermsOfService = new Uri("https://lutonet.org/terms"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("mailto://admin@lutonet.org")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://lutonet.org/license")
        }
    });
});

builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<I18nMiddleware>();

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();
app.MapRazorPages();

app.Run();