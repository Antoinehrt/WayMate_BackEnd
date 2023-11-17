using Application;
using Application.UseCases.Address;
using Infrastructure.Ef;
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

//Use Case Address
builder.Services.AddScoped<UseCaseCreateAddress>();
builder.Services.AddScoped<UseCaseFetchAllAddress>();
builder.Services.AddScoped<UseCaseFetchAddressById>();
builder.Services.AddScoped<UseCaseDeleteAddress>();
builder.Services.AddScoped<UseCaseUpdateAddress>();

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