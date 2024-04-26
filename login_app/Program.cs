using login_app.Data;
using login_app.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))); builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();
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

app.UseRouting();

app.UseCors(policy => policy
    .WithOrigins(new[] { "http://localhost:3000" , "http://localhost:8000", "http://localhost:4200", "http://localhost:5173" })
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
