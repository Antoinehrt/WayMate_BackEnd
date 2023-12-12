using Application.UseCases.Address.Dtos;
using Application.UseCases.Authentication.Dtos;
using Application.UseCases.Car.Dtos;
using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.Passenger.Dto;
using Application.UseCases.Users.User.Dto;
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
        
        //Admin
        CreateMap<DbUser, DtoOutputAdmin>();
        
        //Passenger
        CreateMap<DbUser, DtoOutputPassenger>();
        
        //Authentication
        CreateMap<bool, DtoOutputLogin>();
        //A utiliser pour JWT
        //CreateMap<string, DtoOutputLogin>();
        


    }
}