using ECommerce.API.Database;
using ECommerce.API.Repositories;
using ECommerce.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

#region Context

builder.Services.AddDbContext<ECommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});

#endregion

#region Serilog

IWebHostBuilder webHostBuilder = builder.WebHost.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console()
        .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("db"), sinkOptions: new MSSqlServerSinkOptions { AutoCreateSqlTable = true, TableName = "LogAPI" });
});

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region IoC

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
