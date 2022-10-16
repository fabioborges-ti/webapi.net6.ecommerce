using ECommerce.API.Repositories;
using ECommerce.API.Repositories.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Serilog

IWebHostBuilder webHostBuilder = builder.WebHost.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console();
    //.WriteTo.MSSqlServer(context.Configuration["ConnectionString:db"], sinkOptions: new MSSqlServerSinkOptions { AutoCreateSqlTable = true, TableName = "LogAPI" });
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
