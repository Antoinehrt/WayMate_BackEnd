using Application;
using Application.UseCases.Address;
using Application.UseCases.Authentication;
using Application.UseCases.Car;
using Application.UseCases.Users.Admin;
using Application.UseCases.Users.Driver;
using Application.UseCases.Users.Passenger;
using Application.UseCases.Users.User;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.Car;
using Infrastructure.Ef.Users.Admin;
using Infrastructure.Ef.Users.Driver;
using Infrastructure.Ef.Users.Passenger;
using Infrastructure.Ef.Users.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

//Controllers

//Repository
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
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
builder.Services.AddScoped<UseCaseCreateUser>();
builder.Services.AddScoped<UseCaseUpdateUser>();
builder.Services.AddScoped<UseCaseDeleteUser>();

//Use Case Admin
builder.Services.AddScoped<UseCaseCreateAdmin>();
builder.Services.AddScoped<UseCaseUpdateAdmin>();

//Use Case Passenger
builder.Services.AddScoped<UseCaseCreatePassenger>();
builder.Services.AddScoped<UseCaseUpdatePassenger>();

//Use Case Driver
builder.Services.AddScoped<UseCaseCreateDriver>();
builder.Services.AddScoped<UseCaseUpdateDriver>();

//Use Case Authentication
builder.Services.AddScoped<UseCaseLogin>();
builder.Services.AddScoped<UseCaseRegistrationEmail>();
builder.Services.AddScoped<UseCaseRegistrationUsername>();


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