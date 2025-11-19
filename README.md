# WayMate — Back-end

**WayMate is the back-end for a final-year project of a carpooling (ridesharing) web application. This repository implements the REST API, business logic, and data persistence layer for user management, trip offers, bookings, and vehicle management using Clean Architecture principles.**

Table of contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Architecture](#project-architecture)
- [Quick Start](#quick-start)
- [Development](#development)
- [API Documentation](#api-documentation)
- [Database](#database)

## Overview

- **Purpose**: Provide a robust and scalable REST API to support the WayMate carpooling platform, enabling users to create trip offers, search for rides, manage bookings, and maintain user profiles with secure authentication.
- **Intended audience**: Examiners and future maintainers of the final-year project.
- **Frontend repository**: [WayMate_FrontEnd](https://github.com/Antoinehrt/WayMate_FrontEnd)

## Features

- **Authentication & Authorization**
  - JWT-based authentication with cookie support
  - Role-based access control (Admin, Driver, Passenger)
  - Secure password hashing with BCrypt
  - Registration with email/username validation

- **User Management**
  - Complete user lifecycle (CRUD operations)
  - Multi-role user system (Admin, Driver, Passenger)
  - Profile management and customization
  - Role transition capabilities

- **Trip Management**
  - Create, read, update, delete trip offers
  - Search trips by multiple criteria
  - Trip status management
  - Driver-specific trip operations

- **Booking System**
  - Reserve and cancel bookings
  - Real-time booking status updates
  - Passenger booking history
  - Booking validation and conflict prevention

- **Address & Location**
  - Comprehensive address management
  - Location-based trip searching
  - Address validation and normalization

- **Vehicle Management**
  - Car registration and management
  - Vehicle type and fuel type classification
  - Driver-vehicle associations

## Tech Stack

- **Framework**: ASP.NET Core 6.0
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT (JSON Web Tokens)
- **Security**: BCrypt password hashing
- **Documentation**: Swagger/OpenAPI
- **Architecture**: Clean Architecture with CQRS patterns
- **Mapping**: AutoMapper
- **Containerization**: Docker support

## Project Architecture

The project follows Clean Architecture principles with clear separation of concerns:

```bash
/WayMate_BackEnd
├── Api/                          # Presentation Layer
│   ├── Controllers/             # REST API endpoints
│   │   ├── AddressController.cs
│   │   ├── AuthenticationControllers.cs
│   │   ├── BookingController.cs
│   │   ├── CarController.cs
│   │   ├── TripController.cs
│   │   └── Users/               # User management endpoints
│   │       ├── AdminController.cs
│   │       ├── DriverController.cs
│   │       ├── PassengerController.cs
│   │       └── UserController.cs
│   ├── Program.cs               # Application entry point
│   ├── appsettings.json         # Configuration
│   └── Dockerfile               # Container configuration
├── Application/                  # Application Layer
│   ├── Services/                # Application services
│   │   └── TokenJWT/           # JWT token management
│   ├── UseCases/               # Business use cases
│   │   ├── Address/            # Address operations
│   │   ├── Authentication/     # Auth operations
│   │   ├── Booking/           # Booking operations
│   │   ├── Car/               # Vehicle operations
│   │   ├── Trip/              # Trip operations
│   │   ├── Users/             # User management
│   │   └── Utils/             # Common interfaces
│   └── Mapper.cs               # AutoMapper configuration
├── Domain/                      # Domain Layer
│   ├── Entities/               # Domain entities
│   │   ├── Address.cs
│   │   ├── Booking.cs
│   │   ├── Car.cs
│   │   ├── Trip.cs
│   │   └── User.cs
│   └── Enums/                  # Domain enumerations
│       ├── CarType.cs
│       ├── FuelType.cs
│       └── UserType.cs
├── Infrastructure/              # Infrastructure Layer
│   ├── Ef/                     # Entity Framework
│   │   ├── WaymateContext.cs   # Database context
│   │   ├── DbEntities/         # Database entities
│   │   ├── Address/            # Address repository
│   │   ├── Authentication/     # Auth services
│   │   ├── Booking/           # Booking repository
│   │   ├── Car/               # Car repository
│   │   ├── Trip/              # Trip repository
│   │   └── Users/             # User repositories
└── Tests/                       # Test Layer
    ├── UserTests.cs            # Unit tests
    └── Usings.cs               # Test configurations
```

### Architecture Layers

1. **API Layer**: Controllers and HTTP-specific logic
2. **Application Layer**: Use cases, DTOs, and business orchestration
3. **Domain Layer**: Core business entities and rules
4. **Infrastructure Layer**: Data access, external services, and frameworks

## Quick Start

### Prerequisites

- **.NET SDK 6.0** or higher
- **SQL Server** (LocalDB, Express, or full version)
- **Docker** (optional, for containerized database)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/Antoinehrt/WayMate_BackEnd.git
   cd WayMate_BackEnd
   ```

2. **Configure the database connection**

   Update the connection string in `Api/appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "db": "Server=(localdb)\\mssqllocaldb;Database=WayMateDB;Trusted_Connection=true;"
     }
   }
   ```

3. **Configure JWT settings**

   Update JWT configuration in `Api/appsettings.json`:

   ```json
   {
     "JWT": {
       "Key": "your-super-secret-jwt-key-here",
       "Issuer": "WayMate",
       "Audience": "WayMate-Users"
     }
   }
   ```

4. **Set up the database**

   ```bash
   # Run database migrations (if using EF migrations)
   dotnet ef database update --project Infrastructure --startup-project Api

   # Or execute the SQL scripts
   # Execute WayMate.sql and WayMateInsert.sql in your SQL Server
   ```

5. **Restore dependencies and run**

   ```bash
   # Restore NuGet packages
   dotnet restore

   # Run the application
   dotnet run --project Api
   ```

6. **Access the API**

   - **Swagger UI**: `https://localhost:7000/swagger`
   - **API Base URL**: `https://localhost:7000/api`

## Development

### Running in Development Mode

```bash
# Run with hot reload
dotnet watch run --project Api

# Run tests
dotnet test

# Build solution
dotnet build
```

### Docker Support

```bash
# Build Docker image
docker build -t waymate-backend .

# Run with Docker Compose (if available)
docker-compose up -d
```

## API Documentation

The API follows RESTful conventions and provides comprehensive Swagger documentation.

### Authentication Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/authentication/register/email` | Register with email |
| POST | `/api/authentication/register/username` | Register with username |
| POST | `/api/authentication/login` | User login |

### User Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/user` | Get all users |
| GET | `/api/user/{id}` | Get user by ID |
| POST | `/api/user` | Create user |
| PUT | `/api/user/{id}` | Update user |
| DELETE | `/api/user/{id}` | Delete user |

### Trip Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/trip` | Get all trips |
| GET | `/api/trip/{id}` | Get trip by ID |
| POST | `/api/trip` | Create trip |
| PUT | `/api/trip/{id}` | Update trip |
| DELETE | `/api/trip/{id}` | Delete trip |

### Booking Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/booking` | Get all bookings |
| GET | `/api/booking/{id}` | Get booking by ID |
| POST | `/api/booking` | Create booking |
| DELETE | `/api/booking/{id}` | Cancel booking |

### Vehicle Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/car` | Get all cars |
| GET | `/api/car/{id}` | Get car by ID |
| POST | `/api/car` | Register car |
| PUT | `/api/car/{id}` | Update car |
| DELETE | `/api/car/{id}` | Remove car |

### Address Management

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/address` | Get all addresses |
| GET | `/api/address/{id}` | Get address by ID |
| POST | `/api/address` | Create address |
| PUT | `/api/address/{id}` | Update address |
| DELETE | `/api/address/{id}` | Delete address |

## Database

The application uses SQL Server with Entity Framework Core for data persistence.

### Key Entities

- **User**: Base user information and authentication
- **Trip**: Carpooling trip offers with route details
- **Booking**: Passenger reservations for trips
- **Car**: Vehicle information for drivers
- **Address**: Location data for trips and users

### Database Scripts

- `WayMate.sql`: Database schema creation
- `WayMateInsert.sql`: Initial data seeding

## Testing

The project includes comprehensive unit tests using xUnit framework.

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test class
dotnet test --filter "ClassName=UserTests"
```