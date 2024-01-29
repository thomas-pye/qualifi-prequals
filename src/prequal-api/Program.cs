using Services.Interfaces;
using Services;
using efmodels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Hand rolled DI, with more time I would use a DI framework or target folders
builder.Services.AddScoped<IPrequalificationService, PrequalificationService>();

// [TODO] Not done this before...Injecting the context into the service
builder.Services.AddDbContext<Context>(options => options.UseSqlite()); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();