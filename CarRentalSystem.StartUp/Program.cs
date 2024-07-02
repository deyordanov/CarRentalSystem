using CarRentalSystem.Application;
using CarRentalSystem.Domain;
using CarRentalSystem.Infrastructure;
using CarRentalSystem.StartUp;
using CarRentalSystem.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddWebComponents()
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddDomain();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Initialize();

app.Run();