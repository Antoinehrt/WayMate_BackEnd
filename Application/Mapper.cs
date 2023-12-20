using Application.UseCases.Address.Dtos;
using Application.UseCases.Authentication.Dtos;
using Application.UseCases.Booking.Dtos;
using Application.UseCases.Car.Dtos;
using Application.UseCases.Trip.Dtos;
using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.Driver.Dto;
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
        
        //Trip
        CreateMap<Trip, DtoOutputTrip>();
        CreateMap<DbTrip, DtoOutputTrip>();
        CreateMap<DbTrip, Trip>();
                
        //Car
        CreateMap<Booking, DtoOutputBooking>();
        CreateMap<DbBooking, DtoOutputBooking>();
        CreateMap<DbBooking, Booking>();
        
        //Car
        CreateMap<Car, DtoOutputCar>();
        CreateMap<DbCar, DtoOutputCar>();
        CreateMap<DbCar, Car>();
        
        //User
        CreateMap<User, DtoOutputUser>();
        CreateMap<DbUser, DtoOutputUser>();
        CreateMap<DbUser, User>();
        CreateMap<DbUser, DtoOutputUser>();
        
        
        //Admin
        CreateMap<DbUser, DtoOutputAdmin>();
        
        //Passenger
        CreateMap<DbUser, DtoOutputPassenger>();
        
        //Driver
        CreateMap<DbUser, DtoOuputDriver>();
        
        //Authentication
        CreateMap<bool, DtoOutputLogin>();
        CreateMap<bool, DtoOutputRegistration>();
        


    }
}