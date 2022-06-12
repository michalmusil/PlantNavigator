using Microsoft.EntityFrameworkCore;
using PlantNavigator.API.DbContexts;
using PlantNavigator.API.Repositories;
using PlantNavigator.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();//.AddXmlDataContractSerializerFormatters(); - if I ever want to return XML as well

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// USING THE BUILTIN DEPENDENCY INJECTION
//builder.Services.AddTransient<ISomeInterface, ImplementationOfInterface>();
//builder.Services.AddScoped<ISomeInterface, ImplementationOfInterface>();
//builder.Services.AddSingleton<ISomeInterface, ImplementationOfInterface>();

// Adding Entity Framework reference to work with SQLEXPRESS from connection string in appsettings.json
builder.Services.AddDbContext<PlantNavigatorContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Adding Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// CUSTOM DI FOR REPOSITORIES ETC.
builder.Services.AddScoped<IPlantsRepository, PlantsRepository>();
builder.Services.AddScoped<IClassificationsRepository, ClassificationsRepository>();
builder.Services.AddScoped<ISoilsRepository, SoilsRepository>();










var app = builder.Build();











// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();
