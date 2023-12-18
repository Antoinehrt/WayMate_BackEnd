using System.Text;
using Application;
using Application.Services.TokenJWT;
using Application.UseCases.Address;
using Application.UseCases.Authentication;
using Application.UseCases.Car;
using Application.UseCases.Trip;
using Application.UseCases.Users.Admin;
using Application.UseCases.Users.Driver;
using Application.UseCases.Users.Passenger;
using Application.UseCases.Users.User;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.Car;
using Infrastructure.Ef.Trip;
using Infrastructure.Ef.Users.Admin;
using Infrastructure.Ef.Users.Driver;
using Infrastructure.Ef.Users.Passenger;
using Infrastructure.Ef.Users.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


//Repository
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//Token
builder.Services.AddScoped<TokenService>();

//Use Case Address
builder.Services.AddScoped<UseCaseCreateAddress>();
builder.Services.AddScoped<UseCaseFetchAllAddress>();
builder.Services.AddScoped<UseCaseFetchAddressById>();
builder.Services.AddScoped<UseCaseDeleteAddress>();
builder.Services.AddScoped<UseCaseUpdateAddress>();
builder.Services.AddScoped<UseCaseFetchIdByAddress>();

//Use Case Trip
builder.Services.AddScoped<UseCaseFetchAllTrip>();

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
builder.Services.AddScoped<UserCaseFetchUserByEmail>();

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

//JWT configuration
var jwtKey = builder.Configuration.GetSection("JWT:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
        options.Events = new JwtBearerEvents {
            OnMessageReceived = context => {
                context.Token = context.Request.Cookies["WayMateToken"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddCors(options => {
    options.AddPolicy("Dev", policyBuilder =>
        policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
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