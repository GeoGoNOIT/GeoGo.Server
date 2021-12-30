using GeoGo.Server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDatabase(builder.Configuration)
    .AddDatabaseDeveloperPageExceptionFilter()
    .AddIdentity()
    .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
    .AddApplicationServices()
    .AddSwagger()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseSwaggerUI()
    .UseRouting()
    .UseCors(options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints => endpoints.MapControllers())
    .ApplyMigrations();

app.Run();
