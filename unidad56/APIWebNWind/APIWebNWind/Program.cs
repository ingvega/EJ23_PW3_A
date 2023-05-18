using Microsoft.EntityFrameworkCore;
using APIWebNWind.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("NorthwindDB"))
);

builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(politica => politica.WithOrigins("http://localhost:5231"));
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
