using Application.UseCases.Address.Dtos;
using Application.UseCases.Authentication.Dtos;
using Application.UseCases.Car.Dtos;
using Application.UseCases.Users.User.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Users;
using Infrastructure.Ef.DbEntities;

namespace Application;

public class Mapper : Profile
{
    public Mapper()
    {
        //Address
        CreateMap<Address, DtoOutputAddress>();
        CreateMap<DbAddress, DtoOutputAddress>();
        CreateMap<DbAddress, Address>();
        
        
        //Car
        CreateMap<Car, DtoOutputCar>();
        CreateMap<DbCar, DtoOutputCar>();
        CreateMap<DbCar, Car>();
        
        //User
        CreateMap<User, DtoOutputUser>();
        CreateMap<DbUser, DtoOutputUser>();
        CreateMap<DbUser, User>();
        
        //Authentication
        CreateMap<bool, DtoOutputLogin>();
        CreateMap<DbUser, DtoOutputRegistration>();
        //A utiliser pour JWT
        //CreateMap<string, DtoOutputLogin>();
        


    }
}