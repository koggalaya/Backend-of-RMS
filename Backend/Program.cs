using Backend.Core.AutoMapperConfig;
using Backend.Core.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//DB Configuration // //after creating app setting connection string move to hear to build the builder//

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("local"));
});

//auto mapper configeration :use this after creating core/automapper configuration class

builder.Services.AddAutoMapper(typeof(AutoMapperConfigProfile));

builder.Services   // because of in swagger when create its shows as arrey 
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});//>> aftr fsh contollers 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
