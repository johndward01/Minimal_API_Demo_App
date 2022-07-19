using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbConnection>(s =>
{
    IDbConnection conn = new MySqlConnection(config.GetConnectionString("bestbuy"));
    conn.Open();
    return conn;
});

builder.Services.AddTransient<IProductRepo, ProductRepo>();
builder.Services.AddCors(options =>                         // CORS = Cross Open Resource Sharing   
{                                                   // Opens up the Api to not just limit the callers to a specific domain or individual URL
    options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World");
//app.MapGet("/", (ProductRepo repo) => repo.GetProducts());

app.Run();

