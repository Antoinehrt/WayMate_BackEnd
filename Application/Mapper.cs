using Application.UseCases.Address.Dtos;
using Application.UseCases.Car.Dtos;
using AutoMapper;
using Domain.Entities;
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
        
    }
}