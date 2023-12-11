using Application;
using Application.UseCases.Address;
using Application.UseCases.Authentication;
using Application.UseCases.Car;
using Application.UseCases.Users.Admin;
using Application.UseCases.Users.User;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.Car;
using Infrastructure.Ef.Users.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Mapper));

builder.Services.AddDbContext<WaymateContext>(a => a.UseSqlServer(
    builder.Configuration.GetConnectionString("db"))
);

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();


//Use Case Address
builder.Services.AddScoped<UseCaseCreateAddress>();
builder.Services.AddScoped<UseCaseFetchAllAddress>();
builder.Services.AddScoped<UseCaseFetchAddressById>();
builder.Services.AddScoped<UserCaseFetchUserByEmail>();
builder.Services.AddScoped<UseCaseDeleteAddress>();
builder.Services.AddScoped<UseCaseUpdateAddress>();

//Use Case Car
builder.Services.AddScoped<UseCaseCreateCar>();
builder.Services.AddScoped<UseCaseFetchAllCar>();
builder.Services.AddScoped<UseCaseFetchCarById>();
builder.Services.AddScoped<UseCaseDeleteCar>();
builder.Services.AddScoped<UseCaseUpdateCar>();

//Use Case User
builder.Services.AddScoped<UseCaseFetchAllUser>();
builder.Services.AddScoped<UseCaseFetchUserById>();
builder.Services.AddScoped<UseCaseDeleteUser>();
builder.Services.AddScoped<UseCaseUpdateUser>();

//Use Case Admin
builder.Services.AddScoped<UseCaseCreateAdmin>();
builder.Services.AddScoped<UseCaseFetchAllAdmin>();
builder.Services.AddScoped<UseCaseUpdateAdmin>();

//Use Case Passenger
builder.Services.AddScoped<UseCaseCreatePassenger>();

//Use Case Driver

//Use Case Authentication
builder.Services.AddScoped<UseCaseLogin>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", policyBuilder =>
        policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Dev");

app.UseAuthorization();

app.MapControllers();

app.Run();