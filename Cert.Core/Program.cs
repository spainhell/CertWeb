using Cert.Common.Services;
using Cert.Core.Components;
using Cert.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddSwaggerGen();       // add Swagger
builder.Services.AddControllers();      // add controllers

builder.Services.AddSingleton<ICertificateService, CertificateRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// add Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Certificates API V1");
    options.RoutePrefix = "swagger"; // Access Swagger at /swagger
});

// add routing for controllers
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();